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

        private List<Account> accounts = new List<Account>() { new Account("Anastasia@gmail.com", "Anastasia1610") };

        public class Account
        {
            private string login;
            private string password;

            public Account(string log, string pswrd)
            {
                Login = log;
                Password = pswrd;
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

                    if (value.Contains("@gmail.com"))
                        value = value.Replace("@gmail.com", "");
                    else
                        flag = true;

                    if (value.Length >= 4 && value.Length <= 16)
                    {
                        string simbols = "-;%&*()!#$^~";
                        for (int i = 0; i < simbols.Length; i++)
                            if (value.Contains(simbols[i]))
                            {
                                flag = true;
                                break;
                            }
                        if (!flag)
                            login = value + "@gmail.com";
                    }
                    else
                        flag = true;

                    if (flag) login = "undefinded";
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
                    if (value.Length >= 8 && value.Length <= 16)
                    {
                        flag = true;
                        string simbols = "-;%&*()!#$^~";
                        string nums = "01234567890";
                        string alphUpper = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";

                        foreach (var item in simbols)
                            if (value.Contains(item))
                            {
                                flag = false;
                                break;
                            }

                        if (flag)
                        {
                            flag = false;
                            foreach (var item in nums)
                                if (value.Contains(item))
                                {
                                    flag = true;
                                    break;
                                }

                            if (flag)
                            {
                                flag = false;
                                foreach (var item in alphUpper)
                                    if (value.Contains(item))
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
            bool flag = false;
            foreach (var item in accounts)
            {
                if (LoginField.Text == item.Login)
                {
                    if (PasswordField.Password.ToString() == item.Password)
                    {
                        MessageBox.Show("Succesfully", "Authorization", MessageBoxButton.OK);
                        flag = true;
                    }
                }
            }

            if (!flag)
            {
                MessageBoxResult res = MessageBox.Show("Unsuccessfully\nTry again", "Authorization", MessageBoxButton.YesNo);

                if (res == MessageBoxResult.Yes)
                {
                    LoginField.Text = "";
                    PasswordField.Password = "";
                }
                else
                {
                    // переход на предыдущую страницу
                }
            }
        }

        private void RegistrationBtn_Click(object sender, RoutedEventArgs e)
        {
            if (LoginField.Text == "" || PasswordField.Password == "")
            {
                MessageBox.Show("Unsuccesfully", "Registration", MessageBoxButton.OK);
            }
            else
            {
                Account newAcc = new Account(LoginField.Text, PasswordField.Password);

                if (newAcc.Login == "undefinded" && newAcc.Password == "000")
                {
                    bool alreadyRegistered = false;
                    foreach (var item in accounts)
                    {
                        if (LoginField.Text.ToString() == item.Login.ToString())
                        {
                            MessageBox.Show("This account is already registered", "Registration", MessageBoxButton.OK);
                            alreadyRegistered = true;
                            break;
                        }
                    }

                    if (!alreadyRegistered)
                    {
                        accounts.Add(newAcc);
                        MessageBox.Show("This account successfuly regastered", "Registration", MessageBoxButton.OK);
                        LoginField.Text = "";
                        PasswordField.Password = "";
                    }
                }
            }
        }
    }
}
