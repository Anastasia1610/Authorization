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

        private void LoginBtn_Click(object sender, RoutedEventArgs e)
        {
           
            MessageBoxResult res = MessageBoxResult.Yes;
            if (Login.Text == _login && Password.Password == _password)
            {
                //Переход на другую страницу
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
