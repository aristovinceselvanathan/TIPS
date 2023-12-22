using MahApps.Metro.IconPacks;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using System.Windows.Threading;
using TImerApp;
using TImerApp.Models;

namespace TimerApp
{
    /// <summary>
    /// Interaction logic for TaskWindow.xaml
    /// </summary>
    public partial class TaskWindow : Window
    {
        ObservableCollection<UserTask> tasks;
        public TaskWindow(string userName)
        {
            InitializeComponent();
            Username.Text = userName;
            tasks = new ObservableCollection<UserTask>
            {
                new UserTask { Title = "ProjectA", CategoryTask = UserTask.TaskCategory.Work },
                new UserTask { Title = "ProjectB", CategoryTask = UserTask.TaskCategory.Work },
                new UserTask { Title = "ProjectC", CategoryTask = UserTask.TaskCategory.Work },
                new UserTask { Title = "ProjectD", CategoryTask = UserTask.TaskCategory.Work },
            };
            TimerDataGrid.ItemsSource = tasks;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (DockBorder.Width == 200)
            {
                DockBorder.Width = 0;
                Dashboard.VerticalAlignment = VerticalAlignment.Stretch;
            }
            else
            {
                DockBorder.Width = 200;
            }
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            if (Edit.Width == 0)
            {
                Edit.Width = 300;
                DockBorder.Width = 0;
                Title.Text = "";
                Description.Text = "";
                statusComboBox.Text = "";
                taskDatePicker.Text = "";
            }
            else
            {
                Edit.Width = 0;
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            this.Close();
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            
        }

        private void StartorStopButton_Click(object sender, RoutedEventArgs e)
        {
            Button StartOrStopButton = (Button)sender;
            UserTask selectedItem = (UserTask)StartOrStopButton.DataContext;

            if (selectedItem != null)
            {
                if (!selectedItem.IsEnabled)
                {
                    selectedItem.StartTimer();
                    if (StartOrStopButton.Content is PackIconMaterial image)
                    {
                        image.Kind = PackIconMaterialKind.Stop;
                    }
                }
                else
                {
                    if (selectedItem.IsEnabled)
                    {
                        selectedItem.StopTimer();
                        if (StartOrStopButton.Content is PackIconMaterial image)
                        {
                            image.Kind = PackIconMaterialKind.Play;
                        }
                    }
                }
            }
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            Button StartOrStopButton = (Button)sender;
            UserTask selectedItem = (UserTask)StartOrStopButton.DataContext;
            tasks.Remove(selectedItem);
            
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            Button StartOrStopButton = (Button)sender;
            UserTask userTask = StartOrStopButton.DataContext as UserTask;
            if (Edit.Width == 0)
            {
                Edit.Width = 300;
                DockBorder.Width = 0;
                Title.Text = userTask.Title;
                Description.Text = userTask.Description;
                statusComboBox.Text = userTask.CategoryTask.ToString();
                taskDatePicker.Text = userTask.Date.ToString();
            }
            else
            {
                Edit.Width = 0;
            }
        }

        private void UpdateButton_Click(object sender, RoutedEventArgs e)
        {
            UserTask userTask = new UserTask { Title = Title.Text, CategoryTask = UserTask.TaskCategory.Work };
            tasks.Add(userTask);
        }
    }
}
