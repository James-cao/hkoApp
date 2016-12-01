using HKO.DAL.Interfaces.Sektori;
using HKO.Models.Sektori;
using MicroOrm.Pocos.SqlGenerator;
using Oracle.ManagedDataAccess.Client;

namespace HKO.DAL.Repositories.Sektori
{
    public class ObuhvatSektoraRepository : DataRepository<ObuhvatSektora>,
        IObuhvatSektoraRepository
    {
        //NOTE: Because this is a "Dependency Injection Oriented Package"
        //we need to pass the database connection and the SQL Generator as parameters
        public ObuhvatSektoraRepository(OracleConnection connection,
            ISqlGenerator<ObuhvatSektora> sqlGenerator)
            : base(connection, sqlGenerator)
        {
        }
    }
}
