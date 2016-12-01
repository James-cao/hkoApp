﻿using HKO.DAL.Interfaces.Sektori;
using HKO.Models.Sektori;
using MicroOrm.Pocos.SqlGenerator;
using Oracle.ManagedDataAccess.Client;

namespace HKO.DAL.Repositories.Sektori
{
    public class SektorRadnaSnagaRepository : DataRepository<SektorRadnaSnaga>,
        ISektorRadnaSnagaRepository
    {
        //NOTE: Because this is a "Dependency Injection Oriented Package"
        //we need to pass the database connection and the SQL Generator as parameters
        public SektorRadnaSnagaRepository(OracleConnection connection,
            ISqlGenerator<SektorRadnaSnaga> sqlGenerator)
            : base(connection, sqlGenerator)
        {
        }
    }
}
