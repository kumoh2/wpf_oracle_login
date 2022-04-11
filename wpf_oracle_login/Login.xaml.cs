﻿using System;
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
            string CmdString = string.Format("SELECT PWD FROM Z_USR_MAST_REC"
                                            +"WHERE USR_ID = '{0}'",id_textbox);
            using (OracleConnection conn = new OracleConnection(ConString))
            {
                OracleCommand cmd = new OracleCommand(CmdString, conn);
                conn.Open();

                if (id_textbox.Text == "" || pw_textbox.Text == "")
                {
                    MessageBox.Show("ID 또는Password를입력하세요...");
                    return;
                }

                using (OracleDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        if (pw_textbox.Text != reader["pwd"].ToString())
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