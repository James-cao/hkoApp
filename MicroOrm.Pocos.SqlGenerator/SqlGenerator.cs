using MicroOrm.Pocos.SqlGenerator.Attributes;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace MicroOrm.Pocos.SqlGenerator
{
    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    public class SqlGenerator<TEntity> : ISqlGenerator<TEntity> where TEntity : new()
    {
        #region Constructors

        /// <summary>
        /// 
        /// </summary>
        public SqlGenerator()
        {
            this.LoadEntityMetadata();
        }

        private void LoadEntityMetadata()
        {
            var entityType = typeof(TEntity);

            var aliasAttribute = entityType.GetCustomAttribute<StoredAs>();
            var schemeAttribute = entityType.GetCustomAttribute<Scheme>();
            this.TableName = aliasAttribute != null ? aliasAttribute.Value : entityType.Name;
            this.Scheme = schemeAttribute != null ? schemeAttribute.Value : "dbo";

            //Load all the "primitive" entity properties
            IEnumerable<PropertyInfo> props = entityType.GetProperties().Where(p => p.PropertyType.IsValueType || p.PropertyType.Name.Equals("String", StringComparison.InvariantCultureIgnoreCase));

            //Filter the non stored properties
            this.BaseProperties = props.Where(p => !p.GetCustomAttributes<NonStored>().Any()).Select(p => new PropertyMetadata(p));

            //Filter key properties
           // this.KeyProperties = props.Where(p => p.GetCustomAttributes<KeyProperty>().Any()).Select(p => new PropertyMetadata(p));
            this.KeyProperties = props.Where(p => p.GetCustomAttributes<KeyProperty>().Any()).Select(p => new PropertyMetadata(p));

            //Use identity as key pattern
            var identityProperty = props.SingleOrDefault(p => p.GetCustomAttributes<KeyProperty>().Any(k => k.Identity));
            this.IdentityProperty = identityProperty != null ? new PropertyMetadata(identityProperty) : null ;

            //Status property (if exists, and if it does, it must be an enumeration)
            var statusProperty = props.FirstOrDefault(p => p.PropertyType.IsEnum && p.GetCustomAttributes<StatusProperty>().Any());

            if (statusProperty != null)
            {
                this.StatusProperty = new PropertyMetadata(statusProperty);
                var statusPropertyType = statusProperty.PropertyType;
                var deleteOption = statusPropertyType.GetFields().FirstOrDefault(f => f.GetCustomAttribute<Deleted>() != null);

                if (deleteOption != null)
                {
                    var enumValue = Enum.Parse(statusPropertyType, deleteOption.Name);

                    if (enumValue != null)
                        this.LogicalDeleteValue = Convert.ChangeType(enumValue, Enum.GetUnderlyingType(statusPropertyType));
                }
            }
        }

        #endregion

        #region Properties

        /// <summary>
        /// 
        /// </summary>
        public bool IsIdentity
        {
            get
            {
                return this.IdentityProperty != null;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public bool LogicalDelete
        {
            get
            {
                return this.StatusProperty != null;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public string TableName { get; private set; }

        /// <summary>
        /// 
        /// </summary>
        public string Scheme { get; private set; }

        /// <summary>
        /// 
        /// </summary>
        public PropertyMetadata IdentityProperty { get; private set; }

        /// <summary>
        /// 
        /// </summary>
        public IEnumerable<PropertyMetadata> KeyProperties { get; private set; }

        /// <summary>
        /// 
        /// </summary>
        public IEnumerable<PropertyMetadata> BaseProperties { get; private set; }

        /// <summary>
        /// 
        /// </summary>
        public PropertyMetadata StatusProperty { get; private set; }

        /// <summary>
        /// 
        /// </summary>
        public object LogicalDeleteValue { get; private set; }

        #endregion

        #region Query generators

        /// <summary>
        ///  
        /// </summary>
        /// <returns></returns>
        public virtual string GetInsert()
        {
            //Enumerate the entity properties
            //Identity property (if exists) has to be ignored
            IEnumerable<PropertyMetadata> properties = (this.IsIdentity ?
                                                        this.BaseProperties.Where(p => !p.Name.Equals(this.IdentityProperty.Name, StringComparison.InvariantCultureIgnoreCase)) :
                                                        this.BaseProperties).ToList();

            string columNames = string.Join(", ", properties.Select(p => string.Format("{1}", this.TableName, p.ColumnName)));
            string values = string.Join(", ", properties.Select(p => string.Format(":{0}", p.Name)));

            var sqlBuilder = new StringBuilder();
            sqlBuilder.AppendFormat("INSERT INTO {1} {2} {3} ",
                                    this.Scheme,
                                    this.TableName,
                                    string.IsNullOrEmpty(columNames) ? string.Empty : string.Format("({0})", columNames),
                                    string.IsNullOrEmpty(values) ? string.Empty : string.Format(" VALUES ({0})", values));

            //If the entity has an identity key, we create a new variable into the query in order to retrieve the generated id
            if (this.IsIdentity)
            {
                sqlBuilder.AppendLine("DECLARE @NEWID NUMERIC(38, 0)");
                sqlBuilder.AppendLine("SET	@NEWID = SCOPE_IDENTITY()");
                sqlBuilder.AppendLine("SELECT @NEWID");
            }

            return sqlBuilder.ToString();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public virtual string GetUpdate(TEntity instance)
        {
            var properties = this.BaseProperties.Where(p => !this.KeyProperties.Any(k => k.Name.Equals(p.Name, StringComparison.InvariantCultureIgnoreCase)));

            Type t = instance.GetType();
            PropertyInfo prop = t.GetProperty("ID");
            object list = prop.GetValue(instance);

            var sqlBuilder = new StringBuilder();
            sqlBuilder.AppendFormat("UPDATE {1} SET {2} WHERE {3}",
                                    this.Scheme,
                                    this.TableName,
                                    string.Join(", ", properties.Select(p => string.Format("{1} = :{2}", this.TableName, p.ColumnName, p.Name))),
                                    "ID=" + Convert.ToInt32(list));
            
            return sqlBuilder.ToString();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public virtual string GetUpdate()
        {
            var properties = this.BaseProperties.Where(p => !this.KeyProperties.Any(k => k.Name.Equals(p.Name, StringComparison.InvariantCultureIgnoreCase)));

            var sqlBuilder = new StringBuilder();
            sqlBuilder.AppendFormat("UPDATE {1} SET {2} WHERE {3}",
                                    this.Scheme,
                                    this.TableName,
                                    string.Join(", ", properties.Select(p => string.Format("{1} = :{2}", this.TableName, p.ColumnName, p.Name))),
                                    string.Join(" AND ", this.KeyProperties.Select(p => string.Format("{1} = :{2}", this.TableName, p.ColumnName, p.Name))));

            return sqlBuilder.ToString();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public virtual string GetSelectAll(string tableName)
        {
            return this.GetSelect(new { },tableName);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="filters"></param>
        /// <returns></returns>
        public virtual string GetSelect(object filters,string tableName)
        {
            //Projection function
            Func<PropertyMetadata, string> projectionFunction = (p) =>
            {
                if (!string.IsNullOrEmpty(p.Alias))
                    return string.Format("{0} AS {1}",  p.ColumnName, p.Name);

                return string.Format("{0}",  p.ColumnName);
            };

            var temp = this.BaseProperties.Select(projectionFunction);
            
            var sqlBuilder = new StringBuilder();
            sqlBuilder.AppendFormat("SELECT {0} FROM {1}",
                                    string.Join(", ", this.BaseProperties.Select(projectionFunction)),
                                    tableName);

            //Properties of the dynamic filters object
            var filterProperties = filters.GetType().GetProperties().Select(p => p.Name);
            bool containsFilter = (filterProperties != null && filterProperties.Any());

            if (containsFilter)
                sqlBuilder.AppendFormat(" WHERE {0} ", this.ToWhere(filterProperties));

            //Evaluates if this repository implements logical delete
            if (this.LogicalDelete)
            {
                if (containsFilter)
                    sqlBuilder.AppendFormat(" AND {1} != {2}",
                                            this.TableName,
                                            this.StatusProperty.Name,
                                            this.LogicalDeleteValue);
                else
                    sqlBuilder.AppendFormat(" WHERE {1} != {2}",
                                            this.TableName,
                                            this.StatusProperty.Name,
                                            this.LogicalDeleteValue);
            }

            return sqlBuilder.ToString();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public virtual string GetDelete()
        {
            var sqlBuilder = new StringBuilder();

            if (!this.LogicalDelete)
            {
                sqlBuilder.AppendFormat("DELETE FROM {1} WHERE {2}",
                                        this.Scheme,
                                        this.TableName,
                                        string.Join(" AND ", this.KeyProperties.Select(p => string.Format("{1} = :{2}", this.TableName, p.ColumnName, p.Name))));

            }
            else
                sqlBuilder.AppendFormat("UPDATE {1} SET {2} WHERE {3}",
                                    this.Scheme,
                                    this.TableName,
                                    string.Format("{1} = {2}", this.TableName, this.StatusProperty.ColumnName, this.LogicalDeleteValue),
                                    string.Join(" AND ", this.KeyProperties.Select(p => string.Format("{1} = :{2}", this.TableName, p.ColumnName, p.Name))));


            return sqlBuilder.ToString();
        }

        /// <summary>
        /// Gets the function table select.
        /// </summary>
        /// <param name="filters">The filters.</param>
        /// <param name="tableName">Name of the table.</param>
        /// <returns></returns>
        public virtual string GetFnTableSelect(object queryParameters,object filters, string tableName)
        {
            //Projection function
            Func<PropertyMetadata, string> projectionFunction = (p) =>
            {
                if (!string.IsNullOrEmpty(p.Alias))
                    return string.Format("{0} AS {1}", p.ColumnName, p.Name);

                return string.Format("{0}", p.ColumnName);
            };

            var temp = this.BaseProperties.Select(projectionFunction);

            var sqlBuilder = new StringBuilder();
            sqlBuilder.AppendFormat("SELECT {0} FROM TABLE({1}",
                string.Join(", ", this.BaseProperties.Select(projectionFunction)),
                tableName);

            //Properties of the dynamic parameters object
            if (queryParameters != null)
            {
                var queryParameterProperties =(IEnumerable<string>)queryParameters;
                bool containsParameter = (queryParameterProperties != null && queryParameterProperties.Any());

                if (containsParameter)
                    sqlBuilder.AppendFormat(" ({0} ", this.AddFnParams(queryParameterProperties) + "))");
            }

            //Properties of the dynamic filter object
            if (filters != null)
            {
                var type = filters.GetType();
                var props = type.GetProperties();
                var pairs = props.Select(x => x.Name + "=" + x.GetValue(filters, null)).ToArray();

                bool containsFilter = (pairs.Any());

                if (containsFilter)
                    sqlBuilder.AppendFormat("WHERE " + this.ToFnWhere(pairs));
            }
            
            return sqlBuilder.ToString();
        }

        #endregion

        #region Private utility

        /// <summary>
        /// Adds 
        /// </summary>
        /// <param name="properties"></param>
        /// <returns></returns>
        private string ToWhere(IEnumerable<string> properties)
        {
            return string.Join(" AND ", properties.Select(p => {

                var propertyMetadata = this.BaseProperties.FirstOrDefault(pm => pm.Name.Equals(p, StringComparison.InvariantCultureIgnoreCase));

                if(propertyMetadata != null)
                    return string.Format("{1} = :{2}", this.TableName, propertyMetadata.ColumnName, propertyMetadata.Name);

                return string.Format("{1} = :{2}", this.TableName, p, p);

            }));
        }

        /// <summary>
        /// Insert parameters for table function select query creation.
        /// </summary>
        /// <param name="properties">The properties.</param>
        /// <returns></returns>
        private string AddFnParams(IEnumerable<string> properties)
        {
            return string.Join(" , ", properties.Select(p =>
            {

                var propertyMetadata = this.BaseProperties.FirstOrDefault(pm => pm.Name.Equals(p, StringComparison.InvariantCultureIgnoreCase));

                if (propertyMetadata != null)
                    return string.Format(":{2}", this.TableName, propertyMetadata.ColumnName, propertyMetadata.Name);

                return string.Format(":{2}", this.TableName, p, p);

            }));
        }

        /// <summary>
        /// Where for table function select query creation.
        /// </summary>
        /// <param name="properties">The properties.</param>
        /// <returns></returns>
        private string ToFnWhere(IEnumerable<string> properties)
        {

            return string.Join(" AND ", properties.Select(p =>
            {

                var propertyMetadata = this.BaseProperties.FirstOrDefault(pm => pm.Name.Equals(p, StringComparison.InvariantCultureIgnoreCase));

                if (propertyMetadata != null)
                    return string.Format("{1} = :{2}", this.TableName, propertyMetadata.ColumnName, propertyMetadata.Name);

                return string.Format("{1} = :{1}", this.TableName, p.Split('=')[0], p);

            }));


            //return string.Join(" AND ", properties.Select(p =>
            //{
            //    return string.Format("{0}", p.ToDictionary(),p.ToDictionary());
            //}));
        }

        #endregion
    }
}
