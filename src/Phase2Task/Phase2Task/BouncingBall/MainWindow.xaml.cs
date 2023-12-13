using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace BouncingBall
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Random rnd = new Random();
        double ballHeight = 80;
        double ballWidth = 80;
        double ballHeightMov = 0;
        double ballWidthMov = 0;
        double ballPosX = 0;
        double ballPosY = 0;
        double movPosX = -10;
        double movPosY = -15;

        public MainWindow()
        {
            InitializeComponent();
            InitializeBall();
            MoveBall();
        }
        public void InitializeBall()
        {
            ballPosX = ball.Margin.Left;
            ballPosY = ball.Margin.Top;
            ball.Margin = new Thickness(ballPosX, ballPosY, 0, 0);
        }
        public async void MoveBall()
        {
            while (true)
            {
                await Task.Delay(1);
                if (ballPosX <= 0 || ball.Width + ballPosX >= CurrentGrid.ActualWidth)
                {
                    movPosX = ballPosX <= 0 ? Math.Abs(movPosX) : -Math.Abs(movPosX);
                    ballHeightMov = ballPosX <= 0 ? 0: -20;
                    ball.Fill = new SolidColorBrush(Color.FromRgb((byte)rnd.Next(1, 255), (byte)rnd.Next(1, 255), (byte)rnd.Next(1, 255)));

                }
                if (ballPosY <= 0 || ball.Height + ballPosY >= CurrentGrid.ActualHeight)
                {
                    movPosY = ballPosY <= 0 ? Math.Abs(movPosY) : -Math.Abs(movPosY);
                    ballWidthMov = ballPosY <= 0 ? 0 : -20;
                    ball.Fill = new SolidColorBrush(Color.FromRgb((byte)rnd.Next(1, 255), (byte)rnd.Next(1, 255), (byte)rnd.Next(1, 255)));
                }
                if (ballHeight <= 80)
                {
                    ballHeight += 5;
                }
                else if (ballWidth <= 80)
                {
                    ballWidth += 5;
                }
                ball.Height = ballHeight - ballHeightMov;
                ball.Width = ballWidth - ballWidthMov;
                ballPosX += movPosX;
                ballPosY += movPosY;
                ball.Margin = new Thickness(ballPosX, ballPosY, 0, 0);
            }
        }

        private void CurrentGrid_MouseMove(object sender, MouseEventArgs e)
        {
            CurrentGrid.Background = new SolidColorBrush(Color.FromRgb((byte)rnd.Next(1, 255), (byte)rnd.Next(1, 255), (byte)rnd.Next(1, 255)));
        }
    }
}