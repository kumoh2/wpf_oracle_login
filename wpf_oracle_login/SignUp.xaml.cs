using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Oracle.ManagedDataAccess.Client;

namespace wpf_oracle_login
{
    /// <summary>
    /// SignUp.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class SignUp : Window
    {
        string ConString = "Data Source=localhost;User ID=scott;Password=tiger";

        private void Login_conn()
        {

            string cmdString = "SELECT PWD FROM Z_USR_MAST_REC" + " " + 
                               $"WHERE USR_ID = ''";
            using OracleConnection conn = new OracleConnection(ConString);
            OracleCommand cmd = new OracleCommand(cmdString, conn);
            conn.Open();

        }

        public SignUp()
        {
            InitializeComponent();
        }
    }
}
