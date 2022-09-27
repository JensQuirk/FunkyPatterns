using System;

namespace BA
{
    class Cell
    {
        public bool active;
        public ConsoleColor currentColor;
        public static ConsoleColor color1, color2;
        public string type;
        public Cell(bool act, ConsoleColor col, string typ)
        {
            active = act;
            currentColor = col;
            type = typ;
        }
        public Cell(bool act, ConsoleColor a, ConsoleColor b)
        {
            active = act;
            color1 = a;
            color2 = b;
            type = "#";
        }
        public Cell(bool act)
        {
            active = act;
            currentColor = ConsoleColor.Gray;
            type = "#";
        }

        public Cell ReturnNewCell(bool up, bool down, bool left, bool right,
        bool upleft, bool upright, bool downleft, bool downright)
        {
            int i = 0;
            if(up) i++;
            if(down) i++;
            if(left) i++;
            if(right) i++;
            if(upleft) i+=0;
            if(upright) i+=0;
            if(downleft) i+=0;
            if(downright) i+=0;
            
            if (i==1)
            {
                return new Cell(true, color2,"x");
            }
            if (i==3)
            {
                return new Cell(true, color1,"x");
            }
            else
            {
                return new Cell(false);
            }
        }
    }
}