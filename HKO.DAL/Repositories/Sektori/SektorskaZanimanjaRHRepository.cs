using HKO.DAL.Interfaces.Sektori;
using HKO.Models.Sektori;
using MicroOrm.Pocos.SqlGenerator;
using Oracle.ManagedDataAccess.Client;

namespace HKO.DAL.Repositories.Sektori
{
    public class SektorskaZanimanjaRHRepository : DataRepository<SektorskaZanimanjaRH>,
        ISektorskaZanimanjaRHRepository
    {
        //NOTE: Because this is a "Dependency Injection Oriented Package"
        //we need to pass the database connection and the SQL Generator as parameters
        public SektorskaZanimanjaRHRepository(OracleConnection connection,
            ISqlGenerator<SektorskaZanimanjaRH> sqlGenerator)
            : base(connection, sqlGenerator)
        {
        }
    }
}
