using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Threading;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly int rows = 10, cols = 10;
        private readonly Image[,] gridImages;
        LinkedList<Key> keys = new();
        private SnakeBoard? board;
        public MainWindow()
        {
            InitializeComponent();
            gridImages = SetupGrid();
        }

        private void StartButton_Click(object sender, RoutedEventArgs e)
        {
            board = new(rows, cols);
            logic();
            
        }
        private async void logic()
        {
            if (board is null)
                return;
            while (true)
            {
                PrintGrid();
                await Task.Delay(250);
                if (keys.Count != 0)
                {
                    board.change_dir(keys.First.Value);
                    keys.RemoveFirst();
                }
                if (board.logic())
                    break;
                Score.Text = $"SCORE: {board.returnScore()}";
            }
        }
        private void W_KeyDown(object sender, KeyEventArgs e)
        {
            if (board is null)
                return;
            if (keys.Count < 3)
                keys.AddLast(e.Key);
        }
        private Image[,] SetupGrid()
        {
            Image[,] images = new Image[rows, cols];
            GameGrid.Rows = rows;
            GameGrid.Columns = cols;

            for (int r = 0; r < rows; ++r)
                for (int c = 0; c < cols; ++c)
                {
                    Image image = new()
                    {
                        Source = Images.Empty
                    };
                    images[r, c] = image;
                    
                    GameGrid.Children.Add(image);
                }
            
            return images;
        }

        private ImageSource ReturnImage(ImageType field)
        {
            switch (field)
            {
                case ImageType.Empty:
                    return Images.Empty;
                case ImageType.Face:
                    return Images.Face;
                case ImageType.Food:
                    return Images.Food;     
            }
            return Images.Body;
        }
     

        private void PrintGrid()
        {
            if (board is null)
                return;
            GameGrid.Children.Clear();
            ImageType[,] Map = board.Return_map();
            for (int r = 0; r < rows; ++r)
                for (int c = 0; c < cols; ++c)
                {
                    Image image = new()
                    {
                        Source = ReturnImage(Map[c, r])
                    };
                    GameGrid.Children.Add(image);
                }
        }
    }
}
