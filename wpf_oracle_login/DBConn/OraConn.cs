using Oracle.ManagedDataAccess.Client;

namespace wpf_oracle_login.DBConn
{
    class OraConn
    {
        private static readonly string uid = "scott";
        private static readonly string password = "tiger";
        private static string server = "localhost";

        public void get_conn()
        {
            string ConString  = $"Data Source={server}" + 
                                $"User ID={uid};" +
                                $"Password={password}";

            using OracleConnection conn = new OracleConnection(ConString);
        }
    }
}
