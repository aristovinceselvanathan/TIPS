using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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

namespace RevoluteRectangle
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        int userEnteredRows = 5;
        int userEnteredColumns = 5;
        int currentColumn = 0;
        int currentRow = 0;
        Grid RectangleGrid;
        bool forwardStart = true;
        bool reverseStart = false;
        bool start = true;

        public MainWindow()
        {
            InitializeComponent();
            CreateGrid();
        }

        public void CreateGrid()
        {
            RectangleGrid = GridSpace;
            RectangleGrid.RowDefinitions.Clear();
            RectangleGrid.ColumnDefinitions.Clear();
            for (int i = 0; i < userEnteredRows; i++)
            {
                RowDefinition rowDefinition = new RowDefinition();
                RectangleGrid.RowDefinitions.Add(rowDefinition);
            }
            for (int j = 0; j < userEnteredColumns; j++)
            {
                ColumnDefinition columnDefinition = new ColumnDefinition();
                RectangleGrid.ColumnDefinitions.Add(columnDefinition);
            }
        }
        public async void MoveRectangleForward()
        {
            bool repeatA = true;
            bool repeatB = true;
            var grid = GridSpace;
            while (forwardStart)
            {
                await Task.Delay(100);
                int currentColumn = Grid.GetColumn(rectangle);
                int currentRow = Grid.GetRow(rectangle);
                if (currentColumn < userEnteredColumns - 1 && currentRow == 0 && repeatA)
                {
                    this.currentColumn++;
                    Grid.SetColumn(rectangle, this.currentColumn);
                }
                else if (currentRow < userEnteredRows - 1 && this.currentColumn == userEnteredColumns - 1 && repeatB)
                {
                    currentRow++;
                    Grid.SetRow(rectangle, currentRow);
                }
                else if (currentColumn < userEnteredColumns && currentRow == userEnteredRows - 1 && this.currentColumn != 0)
                {
                    this.currentColumn--;
                    Grid.SetColumn(rectangle, this.currentColumn);
                    repeatA = false;
                }
                else if (currentRow < userEnteredRows && this.currentColumn == 0 && currentRow != 0)
                {
                    currentRow--;
                    Grid.SetRow(rectangle, currentRow);
                    repeatB = false;
                }
                if (currentRow == 0 && currentColumn == 0)
                {
                    repeatA = true;
                    repeatB = true;
                }
            }
        }
        public async void MoveRectangleReserve()
        {
            bool repeatA = true;
            bool repeatB = true;
            var grid = GridSpace;
            int currentColumn = Grid.GetColumn(rectangle);
            int currentRow = Grid.GetRow(rectangle);
            while (reverseStart)
            {
                await Task.Delay(100);
                if (currentRow < userEnteredRows - 1 && currentColumn == 0 && repeatA)
                {
                    currentRow++;
                    Grid.SetRow(rectangle, currentRow);
                }
                else if (currentColumn < userEnteredColumns - 1 && currentRow == userEnteredRows - 1 && repeatB)
                {
                    currentColumn++;
                    Grid.SetColumn(rectangle, currentColumn);
                }
                else if (currentRow < userEnteredRows && currentColumn == userEnteredColumns - 1 && currentRow != 0)
                {
                    currentRow--;
                    Grid.SetRow(rectangle, currentRow);
                    repeatA = false;
                }
                else if (currentColumn < userEnteredColumns && currentRow == 0 && currentColumn != 0)
                {
                    currentColumn--;
                    Grid.SetColumn(rectangle, currentColumn);
                    repeatB = false;
                }
                if(currentRow == 0 &&  currentColumn == 0)
                {
                    repeatA = true;
                    repeatB = true;
                }
            }
        }

        public void MoveRectangle()
        {
            if (reverseStart)
            {
                reverseStart = true;
                forwardStart = false;
                MoveRectangleReserve();
            }
            else if (forwardStart)
            {
                reverseStart = false;
                forwardStart = true;
                MoveRectangleForward();
            }
            else
            {
                reverseStart = false;
                forwardStart = false;
            }
        }
        private async void Start_Click(object sender, RoutedEventArgs e)
        {
            if (int.TryParse(Rows.Text, out userEnteredRows))
            {
                if (int.TryParse(Columns.Text, out userEnteredColumns))
                {
                    if (Move.Content.Equals("Start"))
                    {
                        currentColumn = 0;
                        currentRow = 0;
                        forwardStart = false;
                        reverseStart = false;
                        await Task.Delay(1000);
                        Grid.SetRow(rectangle, currentRow);
                        Grid.SetColumn(rectangle, currentColumn);
                        if (forwardStart)
                        {
                            start = true;
                        }
                        if (reverseStart)
                        {
                            start = false;
                        }
                        Move.Content = "Start";
                        Movement.Content = "Movement";
                        if (RectangleGrid.RowDefinitions.Count != userEnteredRows || RectangleGrid.ColumnDefinitions.Count != userEnteredColumns)
                        {
                            MessageBox.Show("Successfully Created Grid");
                        }
                        if (start)
                        {
                            forwardStart = true;
                            Movement.Content = "Movement";
                        }
                        else
                        {
                            reverseStart = true;
                            Movement.Content = "Forward";
                        }
                        MoveRectangle();
                        Move.Content = "Stop";
                        CreateGrid();
                    }
                    else if (Move.Content.Equals("Stop"))
                    {
                        if (forwardStart)
                        {
                            start = true;
                        }
                        if (reverseStart)
                        {
                            start = false;
                        }
                        forwardStart = false;
                        reverseStart = false;
                        MoveRectangle();
                        Move.Content = "Start";
                    }

                }
                else
                {
                    MessageBox.Show("Invalid Columns");
                }
            }
            else
            {
                MessageBox.Show("Invalid Rows");
            }
        }

        private void Movement_Click(object sender, RoutedEventArgs e)
        {
            if (Movement.Content.Equals("Movement"))
            {
                reverseStart = true;
                forwardStart = false;
                MoveRectangleReserve();
                Movement.Content = "Forward";
            }
            else if (Movement.Content.Equals("Forward"))
            {
                reverseStart = false;
                forwardStart = true;
                MoveRectangleForward();
                Movement.Content = "Movement";
            }
        }
    }
}
