namespace HKO.DAL
{
    public static class Configuration
    {
        private static string _connectionString;

        public static string GetConnectionString()
        {
            if (string.IsNullOrEmpty(_connectionString))
            {
                //_connectionString =
                //    "Data Source=(DESCRIPTION = (ADDRESS_LIST = (ADDRESS = (PROTOCOL = TCP)(HOST = 10.76.15.180)(PORT = 1521)))(CONNECT_DATA =(SID = oradb)));Persist Security Info=True;User ID=smartview;Password=!smart3";


                _connectionString =
                    "Data Source=(DESCRIPTION = (ADDRESS_LIST = (ADDRESS = (PROTOCOL = TCP)(HOST = 10.76.15.180)(PORT = 1521)))(CONNECT_DATA =(SID = oradb)));Persist Security Info=True;User ID=ph;Password=ph";

            }

            return _connectionString;
        }
    }
}
