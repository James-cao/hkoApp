using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using Dapper;
using MicroOrm.Pocos.SqlGenerator;
using Oracle.ManagedDataAccess.Client;


namespace HKO.DAL
{
    /// <summary>
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    public abstract class DataRepository<TEntity> : DataConnection, IDataRepository<TEntity> where TEntity : new()
    {
        #region Constructors

        /// <summary>
        /// </summary>
        /// <param name="connection"></param>
        protected DataRepository(OracleConnection connection, ISqlGenerator<TEntity> sqlGenerator)
            : base(connection)
        {
            SqlGenerator = sqlGenerator;
        }

        #endregion

        #region Properties

        protected ISqlGenerator<TEntity> SqlGenerator { get; private set; }

        #endregion

        #region Repository sync base actions

        /// <summary>
        ///     Get All entites
        /// </summary>
        /// <returns></returns>
        public virtual IEnumerable<TEntity> GetAll(string tableName)
        {
            var sql = SqlGenerator.GetSelectAll(tableName);
            return Connection.Query<TEntity>(sql);
        }

        /// <summary>
        ///     Select with WHERE parameters
        /// </summary>
        /// <param name="filters"></param>
        /// <param name="tableName"></param>
        /// <returns></returns>
        public virtual IEnumerable<TEntity> GetWhere(string tableName,object filters)
        {
            var sql = SqlGenerator.GetSelect(filters, tableName);
            return Connection.Query<TEntity>(sql, filters);
        }

        /// <summary>
        ///     Get first record from table
        /// </summary>
        /// <param name="filters"></param>
        /// <param name="tableName"></param>
        /// <returns></returns>
        public virtual TEntity GetFirst(string tableName,object filters)
        {
            return GetWhere(tableName, filters).FirstOrDefault();
        }

        /// <summary>
        ///     Insert new entity
        /// </summary>
        /// <param name="instance"></param>
        /// <returns></returns>
        public virtual bool Insert(TEntity instance)
        {
            var added = false;
            var sql = SqlGenerator.GetInsert();

            if (SqlGenerator.IsIdentity)
            {
                var newId = Connection.Query<decimal>(sql, instance).Single();
                added = newId > 0;

                if (added)
                {
                    var newParsedId = Convert.ChangeType(newId, SqlGenerator.IdentityProperty.PropertyInfo.PropertyType);
                    SqlGenerator.IdentityProperty.PropertyInfo.SetValue(instance, newParsedId);
                }
            }
            else
            {
                added = Connection.Execute(sql, instance) > 0;
            }

            return added;
        }

        /// <summary>
        ///     Update entity
        /// </summary>
        /// <param name="instance">TEntity</param>
        /// <returns></returns>
        public virtual bool Update(TEntity instance)
        {
            var sql = SqlGenerator.GetUpdate(instance);
            return Connection.Execute(sql, instance) > 0;
        }

        /// <summary>
        ///     Call stored Oracle DB function with cursor
        /// </summary>
        /// <param name="oracleFunctionName">Name of the function in DB</param>
        /// <param name="fnParameters">Query parameters</param>
        /// <returns></returns>
        public virtual IEnumerable<TEntity> OracleFunctionCursor(string oracleFunctionName,
            OracleDynamicParameters fnParameters)
        {
            //using (IDbConnection cn = Connection)
            //{
              //  var a = cn.ExecuteReader(oracleFunctionName, fnParameters, commandType: CommandType.StoredProcedure);
            //  var a = cn.QuerySingle<TEntity>(oracleFunctionName, param: fnParameters, commandType: CommandType.StoredProcedure);
               // cn.Open();
                var response = Connection.Query<TEntity>(oracleFunctionName, param: fnParameters, commandType: CommandType.StoredProcedure);
               // cn.Close();
                return response;


           // }
        }

        /// <summary>
        ///     Call Oracle table function.
        /// </summary>
        /// <param name="oracleFunctionName">Name of the oracle function.</param>
        ///<param name="fnParameters">SQL query parameters.</param>
        /// <param name="filters">Filters used in WHERE clause.</param>
        /// <returns></returns>
        public virtual IEnumerable<TEntity> OracleFunctionTable(string oracleFunctionName, OracleDynamicParameters fnParameters, object filters)
        {
            //TO DO
            var sql = SqlGenerator.GetFnTableSelect(fnParameters.ParameterNames,filters, oracleFunctionName);

            fnParameters.AddDynamicParams(filters);

            return Connection.Query<TEntity>(sql,fnParameters,null,true,null,CommandType.Text);
         
        }

        #endregion
        
    }
}