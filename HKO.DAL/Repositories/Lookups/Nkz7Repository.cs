using HKO.DAL.Interfaces.Lookups;
using HKO.Models.Lookups;
using MicroOrm.Pocos.SqlGenerator;
using Oracle.ManagedDataAccess.Client;

namespace HKO.DAL.Repositories.Lookups
{
    public class Nkz7Repository : DataRepository<Nkz7>, INkz7Repository
    {
        //NOTE: Because this is a "Dependency Injection Oriented Package"
        //we need to pass the database connection and the SQL Generator as parameters
        public Nkz7Repository(OracleConnection connection, ISqlGenerator<Nkz7> sqlGenerator)
            : base(connection, sqlGenerator)
        {
        }
    }
}
