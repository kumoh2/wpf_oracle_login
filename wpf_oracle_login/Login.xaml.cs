using System;
using System.Collections.Generic;
using System.Data;
using Oracle.ManagedDataAccess.Client;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace WpfApp1
{
    /// <summary>
    /// Page1.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class Login : Window
    {
        public Login()
        {
            InitializeComponent();
        }

        private void Login_conn()
        {
            string ConString = "Data Source=localhost;User ID=scott;Password=tiger";
            string CmdString = string.Format("SELECT * FROM Z_USR_MAST_REC"); ;
            using (OracleConnection conn = new OracleConnection(ConString))
            {
                OracleCommand cmd = new OracleCommand(CmdString, conn);
                conn.Open();
                using (OracleDataReader reader = cmd.ExecuteReader())
                {
                    //// Always call Read before accessing data.
                    //String s = "";
                    //while (reader.Read())
                    //{
                    //    s += reader[0].ToString();
                    //    MessageBox.Show(s);
                    //}
                }
            }
        }

        private void Login_Button_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            Login_conn();
        }

        private void Exit_Button_Click(object sender, System.Windows.RoutedEventArgs e)
        {

        }

        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return)
            {
                Login_conn();
            }
        }
    }
}