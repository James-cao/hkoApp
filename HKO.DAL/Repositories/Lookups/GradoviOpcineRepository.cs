using HKO.DAL.Interfaces.Lookups;
using HKO.Models.Lookups;
using MicroOrm.Pocos.SqlGenerator;
using Oracle.ManagedDataAccess.Client;

namespace HKO.DAL.Repositories.Lookups
{
    public class GradoviOpcineRepository : DataRepository<GradoviOpcine>, IGradoviOpcineRepository
    {
        //NOTE: Because this is a "Dependency Injection Oriented Package"
        //we need to pass the database connection and the SQL Generator as parameters
        public GradoviOpcineRepository(OracleConnection connection, ISqlGenerator<GradoviOpcine> sqlGenerator)
            : base(connection, sqlGenerator)
        {
        }
    }
}
