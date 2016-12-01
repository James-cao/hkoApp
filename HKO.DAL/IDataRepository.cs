using System.Collections.Generic;

namespace HKO.DAL
{
    /// <summary>
    ///     Interface for DataRepository
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    public interface IDataRepository<TEntity> where TEntity : new()
    {
        #region Sync

        /// <summary>
        /// </summary>
        /// <returns></returns>
        IEnumerable<TEntity> GetAll(string tableName);

        /// <summary>
        /// SELECT with where clause.
        /// </summary>
        /// <param name="tableName">Name of the table.</param>
        /// <param name="filters">The filters.</param>
        /// <returns></returns>
        IEnumerable<TEntity> GetWhere(string tableName, object filters);

        /// <summary>
        /// Gets the first.
        /// </summary>
        /// <param name="tableName">Name of the table.</param>
        /// <param name="filters">The filters.</param>
        /// <returns></returns>
        TEntity GetFirst(string tableName, object filters);

        /// <summary>
        /// Inserts the specified instance.
        /// </summary>
        /// <param name="instance">The instance.</param>
        /// <returns></returns>
        bool Insert(TEntity instance);

        /// <summary>
        /// </summary>
        /// <param name="instance"></param>
        /// <returns></returns>
        bool Update(TEntity instance);

        /// <summary>
        /// Calls stored Oracle DB function
        /// </summary>
        /// 
        /// <returns></returns>
        IEnumerable<TEntity> OracleFunctionCursor(string oracleFunctionName, OracleDynamicParameters fnParameters);

        #endregion

    }
}