using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1
{
    internal class Fruit
    {
        public int[] location = new int[2];
        readonly Random rnd = new();
        public Fruit()
        {
        }

        public void new_location(int x, int y, Snake snake)
        { 
            bool go_on = false;
            while (true)
            {
                go_on = false;
                location[0] = rnd.Next(1, x - 1);
                location[1] = rnd.Next(1, y - 1);
                if (location == snake.location)
                    go_on = true;
                for (int i = 0; i < snake.tail_x.Count; i++)
                    if (snake.tail_x[i] == location[0] && snake.tail_y[i] == location[1])
                        go_on = true;
                if (go_on == false)
                    return;
            }
        }

       

    }
}
