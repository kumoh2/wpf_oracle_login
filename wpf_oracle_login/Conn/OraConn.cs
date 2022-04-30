using Oracle.ManagedDataAccess.Client;

namespace wpf_oracle_login.Conn
{
    internal class OraConn
    {
        private static readonly string uid = "scott";
        private static readonly string password = "tiger";
        private static string server = "localhost";


        private void get_conn()
        {


           string ConString  = $"Data Source=localhost;" + 
                   $"User ID={uid};" +
                   $"Password={password}";

            string cmdString = "SELECT PWD FROM Z_USR_MAST_REC" + " " +
                               $"WHERE USR_ID = ''";
            using OracleConnection conn = new OracleConnection(ConString);
            OracleCommand cmd = new OracleCommand(cmdString, conn);
            conn.Open();

        }


    }
}
