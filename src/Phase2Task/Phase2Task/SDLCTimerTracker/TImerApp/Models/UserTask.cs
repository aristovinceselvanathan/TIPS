using MahApps.Metro.IconPacks;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TImerApp.Models
{
    partial class UserTask : ViewModel
    {
        private TimeSpan _time = TimeSpan.Zero;
        public UserTask()
        {
            Timer = new();
            button = new PackIconMaterial();
            button.Kind = PackIconMaterialKind.Play;
            Timer.Interval = TimeSpan.FromSeconds(1);
            Timer.Tick += Ticker;
        }

        public UserTask(string title, string description, TaskCategory categoryTask)
        {
            Title = title;
            Description = description;
            CategoryTask = categoryTask;
        }

        public string Title { get; set; }

        public string Description { get; set; }

        public TaskCategory CategoryTask { get; set; }

        public DateOnly Date { get; set; }

        public PackIconMaterial button { get; set; }

        private string timer;

        public string TimerValue { get 
            {
                return timer;
            } 
            set
            {
                timer = value;
                OnPropertyChanged(nameof(TimerValue));
            }
        }

        public ObservableCollection<Time> TaskTimer { get; set; }

        System.Windows.Threading.DispatcherTimer Timer;

        public bool IsEnabled
        {
            get
            {
                return Timer.IsEnabled;
            }
        }

        public void StartTimer()
        {
            Timer.Start();
        }

        public void StopTimer()
        {
            Timer.Stop();
        }

        public void Ticker(object sender, EventArgs e)
        {
            if (_time != null)
            {
                // Increase the time by one second
                _time = _time.Add(TimeSpan.FromSeconds(1));

                // This will display the time in "HH:mm:ss" format
                TimerValue = _time.ToString(@"hh\:mm\:ss");
            }
        }
    }
}
