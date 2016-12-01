using HKO.DAL.Interfaces.Sektori;
using HKO.Models.Sektori;
using MicroOrm.Pocos.SqlGenerator;
using Oracle.ManagedDataAccess.Client;

namespace HKO.DAL.Repositories.Sektori
{
    public class ZaposlenostBrojRepository : DataRepository<ZaposlenostBroj>,
        IZaposlenostBrojRepository
    {
        //NOTE: Because this is a "Dependency Injection Oriented Package"
        //we need to pass the database connection and the SQL Generator as parameters
        public ZaposlenostBrojRepository(OracleConnection connection,
            ISqlGenerator<ZaposlenostBroj> sqlGenerator)
            : base(connection, sqlGenerator)
        {
        }
    }
}
