using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1
{

    internal class Snake
    {

        public enum Dir
        {
            FOWARD = 0,
            BACK = 1,
            LEFT = 2,
            RIGHT = 3
        }

        public enum Collision_type
        {
            NOTHING = 0,
            FRUIT = 1,
            TAIL = 2,
            WALL = 3
        }

        public int[] location = new int[2];
        public List<int> tail_x = new();
        public List<int> tail_y = new();
        public Dir direction = Dir.FOWARD;
        public Snake()
        {
            location[0] = 4;
            location[1] = 4;
        }


        public Collision_type check_collisions(int fx, int fy, int board_x, int board_y)
        {
            //Fruit collision
            if (location[0] == fx && location[1] == fy)
                return Collision_type.FRUIT;

            //Wall collision
            if (location[0] < 0 || location[1] < 0 || location[0] > board_x - 1 || location[1] > board_y - 1)
                return Collision_type.WALL;

            //Tail collision
            for (int i = 0; i < tail_x.Count; i++)
                if (tail_x[i] == location[0] && tail_y[i] == location[1])
                    return Collision_type.TAIL;

            return Collision_type.NOTHING;
        }

        public void move_snake()
        {
            for (int i = tail_x.Count - 1; i > 0; --i)
            {
                tail_x[i] = tail_x[i - 1];
                tail_y[i] = tail_y[i - 1];
            }
            if (tail_y.Count != 0)
            {
                tail_x[0] = location[0];
                tail_y[0] = location[1];
            }
            switch (direction)
            {
                case Dir.FOWARD:                    
                    location[1]--;
                    break;
                case Dir.BACK:
                    location[1]++;
                    break;
                case Dir.LEFT:
                    location[0]--;
                    break;
                case Dir.RIGHT:
                    location[0]++;
                    break;
            }

        }

        public void add_tail()
        {
            if (tail_x.Count == 0)
            {
                tail_x.Add(location[0]);
                tail_y.Add(location[1]);
                return;
            }
            tail_x.Add(tail_x.Last());
            tail_y.Add(tail_y.Last());
        }
    } 
}
