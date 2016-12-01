using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HKO.DAL;
using Oracle.ManagedDataAccess.Client;

namespace HKO.BLL
{
    public class BaseManager
    {
        public static OracleConnection SqlCon = new OracleConnection(Configuration.GetConnectionString());
    }
}
