using System;
using System.Windows;
using System.Windows.Input;
using Oracle.ManagedDataAccess.Client;

namespace wpf_oracle_login
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
            string cmdString = "SELECT PWD FROM Z_USR_MAST_REC" + " " + $"WHERE USR_ID = '{id_textbox.Text}'";
            using OracleConnection conn = new OracleConnection(ConString);
            OracleCommand cmd = new OracleCommand(cmdString, conn);
            conn.Open();

            if (id_textbox.Text == "" || pw_textbox.Password == "")
            {
                MessageBox.Show("ID 또는Password를입력하세요...");
                return;
            }

            using OracleDataReader reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                if (pw_textbox.Password != reader["pwd"].ToString())
                {
                    MessageBox.Show("Password가맞지않습니다...");
                    return;
                }
            }
            else
            {
                MessageBox.Show("등록되지않은ID 입니다.");
                return;
            }

            wpf_oracle_login.Login testwindow = new wpf_oracle_login.Login();

            GetWindow(this)?.Close();
            testwindow.ShowDialog();
        }

        private void Login_Button_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            Login_conn();
        }

        private void Exit_Button_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            Environment.Exit(0);
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