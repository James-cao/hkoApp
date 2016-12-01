using HKO.DAL.Interfaces.Sektori;
using HKO.Models.Sektori;
using MicroOrm.Pocos.SqlGenerator;
using Oracle.ManagedDataAccess.Client;

namespace HKO.DAL.Repositories.Sektori
{
    public class SektorskaZanimanjaRodoviRepository : DataRepository<SektorskaZanimanjaRodovi>,
        ISektorskaZanimanjaRodoviRepository
    {
        //NOTE: Because this is a "Dependency Injection Oriented Package"
        //we need to pass the database connection and the SQL Generator as parameters
        public SektorskaZanimanjaRodoviRepository(OracleConnection connection,
            ISqlGenerator<SektorskaZanimanjaRodovi> sqlGenerator)
            : base(connection, sqlGenerator)
        {
        }
    }
}
