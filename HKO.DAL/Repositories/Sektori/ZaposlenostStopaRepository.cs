using HKO.DAL.Interfaces.Sektori;
using HKO.Models.Sektori;
using MicroOrm.Pocos.SqlGenerator;
using Oracle.ManagedDataAccess.Client;

namespace HKO.DAL.Repositories.Sektori
{
    public class ZaposlenostStopaRepository : DataRepository<ZaposlenostStopa>,
        IZaposlenostStopaRepository
    {
        //NOTE: Because this is a "Dependency Injection Oriented Package"
        //we need to pass the database connection and the SQL Generator as parameters
        public ZaposlenostStopaRepository(OracleConnection connection,
            ISqlGenerator<ZaposlenostStopa> sqlGenerator)
            : base(connection, sqlGenerator)
        {
        }
    }
}
