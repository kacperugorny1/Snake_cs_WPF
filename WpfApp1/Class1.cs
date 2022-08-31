using System.Threading;
using System.Windows.Input;
namespace WpfApp1
{
    
    internal class SnakeBoard
    {
        //Wymiary
        private readonly int[] board = new int[2];

        private ImageType[,] boardMap; 


        private Snake snake = new();
        private Fruit fruit = new();

        public void change_dir(Key key)
        {
            switch (key)
            {
                case Key.Left:
                    if(snake.direction != Snake.Dir.RIGHT)
                        snake.direction = Snake.Dir.LEFT;
                    break;
                case Key.A:
                    if (snake.direction != Snake.Dir.RIGHT)
                        snake.direction = Snake.Dir.LEFT;
                    break;
                case Key.Right:
                    if (snake.direction != Snake.Dir.LEFT)
                        snake.direction = Snake.Dir.RIGHT;
                    break;
                case Key.D:
                    if (snake.direction != Snake.Dir.LEFT)
                        snake.direction = Snake.Dir.RIGHT;
                    break;
                case Key.W:
                    if (snake.direction != Snake.Dir.BACK)
                        snake.direction = Snake.Dir.FOWARD;
                    break;
                case Key.Up:
                    if (snake.direction != Snake.Dir.BACK)
                        snake.direction = Snake.Dir.FOWARD;
                    break;
                case Key.Down:
                    if (snake.direction != Snake.Dir.FOWARD)
                        snake.direction = Snake.Dir.BACK;
                    break;
                case Key.S:
                    if (snake.direction != Snake.Dir.FOWARD)
                        snake.direction = Snake.Dir.BACK;
                    break;
            }
            return;
        }
        public int returnScore()
        {
            return snake.tail_x.Count * 10;
        }
        public Snake.Dir returnDir()
        {
            return snake.direction;
        }

        public SnakeBoard(int rows, int cols)
        {
            board[0] = rows;
            board[1] = cols;
            fruit.new_location(board[0], board[1], snake);
            boardMap = new ImageType[board[0], board[1]];
            Fill_Map();
        }
        
        private void Fill_Map()
        {
            for (int i = 0; i < board[0]; ++i)
                for (int j = 0; j < board[1]; ++j)
                    boardMap[i, j] = IsHereSmth(i, j);
        }
        public ImageType[,] Return_map()
        {
            Fill_Map();
            return boardMap;
        }
        private ImageType IsHereSmth(int x, int y)
        {
            if (snake.location[0] == x && snake.location[1] == y)
                return ImageType.Face;
            if (fruit.location[0] == x && fruit.location[1] == y)
                return ImageType.Food;
            for (int i = 0; i < snake.tail_x.Count; ++i)
                if (snake.tail_x[i] == x && snake.tail_y[i] == y)
                    return ImageType.Body;
            return ImageType.Empty;
        }


        public bool logic()
        {
            bool finished = false;
                snake.move_snake();
                switch (snake.check_collisions(fruit.location[0], fruit.location[1], board[0], board[1]))
                {
                    case Snake.Collision_type.NOTHING:
                        break;
                    case Snake.Collision_type.FRUIT:
                        fruit.new_location(board[0], board[1], snake);
                        snake.add_tail();
                        break;
                    case Snake.Collision_type.TAIL:
                        finished = true;
                        break;
                    case Snake.Collision_type.WALL:
                        finished = true;
                        break;
                }
            return finished;
            }
        } 
    }
