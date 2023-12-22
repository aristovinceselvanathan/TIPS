using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Navigation;
using TimerApp;
using TimerApp.AuthenticationServer;

namespace TImerApp.Pages
{
    /// <summary>
    /// Interaction logic for SignUp.xaml
    /// </summary>
    public partial class SignUp : Page
    {
        public SignUp()
        {
            InitializeComponent();
        }

        private async void SignUp_Click(object sender, RoutedEventArgs e)
        {
            bool isValidLogin = true;
            if(!Validator.ValidateUserName(UserName.Text))
            {
                Notfication.Content = "Invalid Username";
                await Task.Delay(1000);
                isValidLogin = false;
            }
            if(!Validator.ValidateEmail(Email.Text))
            {
                Notfication.Content = "Invalid Email - Please enter valid email";
                await Task.Delay(1000);
                isValidLogin = false;
            }
            if(!Password.Password.Equals(ConfirmPassword.Password) && !Validator.ValidatePassword(Password.Password))
            {
                Notfication.Content = "Invalid Password - Should contain more than 8 characters";
                await Task.Delay(1000);
                isValidLogin = false;
            }
            if(isValidLogin)
            {
                Notfication.Foreground = Brushes.Green;
                Notfication.Content = "User Registered Successful";
                await Task.Delay(1000);
                Notfication.Foreground = Brushes.Red;
                Authenticator authenticator = new Authenticator();
                authenticator.Register(UserName.Text, Email.Text, Password.Password);
            }
            Notfication.Content = "";
            NavigationService.GoBack();
        }

        private void LogIn_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }
    }
}
