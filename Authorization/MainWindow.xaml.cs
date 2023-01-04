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

        List<Account> accounts = new List<Account>(); 

        public class Account
        {
            private string login;
            private string password;

            public Account(string login, string password)
            {
                Login = login;
                Password = password;
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

                    if(login.Contains("@gmail.com"))
                        login = login.Replace("@gmail.com", "");
                    else
                        flag = true;

                    if (login.Length >= 4 && login.Length <= 16)
                    {
                        string simbols = "-;%&*()!#$^~";
                        for (int i = 0; i < simbols.Length; i++)
                            if (login.Contains(simbols[i]))
                            {
                                flag = true;
                                break;
                            }
                        if (!flag)
                            login = value + "@gmail.com";
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
                    bool flag = false;
                    if (password.Length >= 8 && password.Length <= 16)
                    {
                        flag = true;   
                        string simbols = "-;%&*()!#$^~";
                        string nums = "01234567890";
                        string alphUpper = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";

                        foreach (var item in simbols)
                            if(password.Contains(item))
                            {
                                flag = false;
                                break;
                            }
                        
                        if(flag)
                        {
                            flag = false;
                            foreach (var item in nums)
                                if(password.Contains(item))
                                {
                                    flag = true;
                                    break;
                                }
                            
                            if(flag)
                            {
                                flag=false; 
                                foreach (var item in alphUpper)
                                    if(password.Contains(item))
                                    {
                                        flag = true;
                                        break;
                                    }
                            }
                        }
                    }
                    if (flag)
                        password = value;
                    else
                        password = "000";
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

        private void RegistrationBtn_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
