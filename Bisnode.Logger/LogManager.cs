using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Driver;

namespace Bisnode.Logger
{
    public static class LogManager
    {
        public static void Log()
        {
            MongoClient mongoClient = new MongoClient("server = 127.0.0.1; database = log");
            mongoClient.ListDatabases();
        }
    }
}
