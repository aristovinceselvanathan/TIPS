using System.Windows;
using TImerApp.Pages;

namespace TImerApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            LogInOrSignUp.Content = new Login(this);
        }
    }
}
