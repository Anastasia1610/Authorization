﻿using System;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Authorization
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        string _login = "Anastasia";
        string _password = "12345";

        public class Account
        {
            private string login;
            private string password;

            public Account(string login, string password)
            {
                this.login = login;
                this.password = password;
            }

            public string Login
            {
                get
                {
                    return login;
                }
                set
                {
                    bool flag = false;
                    if (login.Length > 4 && login.Length < 16)
                    {
                        string simbols = "-;%&*()!#$^~";
                        for (int i = 0; i < simbols.Length; i++)
                            if (login.Contains(simbols[i]))
                            {
                                flag = true;
                                break;
                            }
                        if (!flag)
                            login = value;
                    }
                    else
                        flag = true;    
                        
                    if(flag) login = "undefinded";
                }
            }

            public string Password
            {
                get
                {
                    return password;
                }
                set
                {
                    password = value;
                }
            }
        }


        private void LoginBtn_Click(object sender, RoutedEventArgs e)
        {

            MessageBoxResult res = MessageBoxResult.Yes;
            if (Login.Text == _login && Password.Password == _password)
            {
                //Success auntification
                MessageBox.Show("Succesfully", "Authorization", MessageBoxButton.OK);
            }
            else
            {
                res = MessageBox.Show("Unsuccessfully\nTry again", "Authorization", MessageBoxButton.YesNo);

                if (res == MessageBoxResult.Yes)
                {
                    Login.Text = "";
                    Password.Password = "";
                }
                else
                {
                    // переход на предыдущую страницу
                }
            }


        }
    }
}
