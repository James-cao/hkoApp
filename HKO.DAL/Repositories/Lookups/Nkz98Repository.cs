using HKO.DAL.Interfaces.Lookups;
using HKO.Models.Lookups;
using MicroOrm.Pocos.SqlGenerator;
using Oracle.ManagedDataAccess.Client;

namespace HKO.DAL.Repositories.Lookups
{
    public class Nkz98Repository : DataRepository<Nkz98>, INkz98Repository
    {
        //NOTE: Because this is a "Dependency Injection Oriented Package"
        //we need to pass the database connection and the SQL Generator as parameters
        public Nkz98Repository(OracleConnection connection, ISqlGenerator<Nkz98> sqlGenerator)
            : base(connection, sqlGenerator)
        {
        }
    }
}
