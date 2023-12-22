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
using TimerApp.FileOperation;
using TimerApp.Models;

namespace TimerApp.Pages
{
    /// <summary>
    /// Interaction logic for ForgotPassword.xaml
    /// </summary>
    public partial class ForgotPassword : Page
    {
        public ForgotPassword()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            /*Send Email*/
            OTP.IsEnabled = true;
            Password.IsEnabled = true;
            ConfirmPassword.IsEnabled = true;
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {

        }
    }
}
