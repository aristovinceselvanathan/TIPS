using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using TimerApp;
using TimerApp.AuthenticationServer;

namespace TImerApp.Pages
{
    /// <summary>
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class Login : Page
    {
        MainWindow mainWindow;
        public Login(MainWindow mainWindow)
        {
            this.mainWindow = mainWindow;
            InitializeComponent();
        }

        private async void Login_Click(object sender, RoutedEventArgs e)
        {
            if(!Validator.ValidateUserName(UserName.Text))
            {
                Notfication.Content = "Invalid Username";
                await Task.Delay(1000);
            }
            if(!Validator.ValidatePassword(Password.Password))
            {
                Notfication.Content = "Invalid Password - Should contain more than 8 characters";
                await Task.Delay(1000);
            }
            else
            {
                Authenticator authenticator = new Authenticator();
                int token = authenticator.Authenticate(UserName.Text, Password.Password);
                if(token != 0)
                {
                    Notfication.Foreground = Brushes.Green;
                    Notfication.Content = "User Registered Successful";
                    await Task.Delay(1000);
                    Notfication.Foreground = Brushes.Red;
                }
                else
                {
                    Notfication.Content = "User Doesn't exist - please sign up";
                }
            }
            Notfication.Content = "";
        }

        private void SignUp_Click(object sender, RoutedEventArgs e)
        {
            mainWindow.Title.Text = "Sign Up";
            mainWindow.LogInOrSignUp.Content = new SignUp();
        }
    }

}
