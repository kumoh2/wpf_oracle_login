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
using static wpf_oracle_login.DBConn.OraConn;


namespace wpf_oracle_login
{
    /// <summary>
    /// SignUp.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class SignUp : Window
    {
        get_conn();

        string cmdString = "SELECT PWD FROM Z_USR_MAST_REC" + " " +
                           $"WHERE USR_ID = ''";

        public SignUp()
        {
            InitializeComponent();
        }
    }
}
