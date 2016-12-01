using HKO.DAL.Interfaces.Sektori;
using HKO.Models.Sektori;
using MicroOrm.Pocos.SqlGenerator;
using Oracle.ManagedDataAccess.Client;

namespace HKO.DAL.Repositories.Sektori
{
    public class DobRepository : DataRepository<DobSektor>,
        IDobRepository
    {
        //NOTE: Because this is a "Dependency Injection Oriented Package"
        //we need to pass the database connection and the SQL Generator as parameters
        public DobRepository(OracleConnection connection,
            ISqlGenerator<DobSektor> sqlGenerator)
            : base(connection, sqlGenerator)
        {
        }
    }
}
