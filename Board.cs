using System;

namespace BA
{
    class Board
    {
        public int dimX, dimY;
        public int size;
        public Cell[] BoardCells;
        public Cell[] Next;
        public Board(int x,int y)
        {
            try 
            { 
            if(x>0) dimX = x;
            else dimX = 51;
            if(y>0)dimY = y;
            else dimY = 81;
            size = x*y;
            BoardCells = new Cell[size];
            Next = new Cell[size];
            }
            catch (Exception e) {Console.WriteLine(e.Message); BoardCells = new Cell[0]; Next = new Cell[0];}
        }
        public void StartupConfig(List<int> StartupCells)
        {
            for (int i = 0; i < BoardCells.Length; i++)
            {

                bool b = false;
                foreach(int val in StartupCells)
                {
                    if(i == val) b=true;
                }
                if(b) BoardCells[i] = new Cell(true);
                else BoardCells[i] = new Cell(false);
            }
        }
        public Cell[] CalculateNextBoard()
        {   
            bool up, down, left, right, 
            upleft, upright, downleft, downright;

            for(int i = 0; i < BoardCells.Length; i++)
            {
                try{up = BoardCells[i-dimX].active;}
                catch{up = false;}
                try{down = BoardCells[i+dimX].active;}
                catch{down = false;}
                try{left = BoardCells[i-1].active;}
                catch{left = false;}
                try{right = BoardCells[i+1].active;}
                catch{right = false;}
                try{upleft = BoardCells[i-dimX-1].active;}
                catch{upleft = false;}
                try{upright = BoardCells[i-dimX+1].active;}
                catch{upright = false;}
                try{downleft = BoardCells[i+dimX-1].active;}
                catch{downleft = false;}
                try{downright = BoardCells[i+dimX+1].active;}
                catch{downright = false;}

                if(i%dimX == 0) left = false;
                if(i%dimX == dimX -1) right = false;


                Next[i] = 
                BoardCells[i].ReturnNewCell(up,down,left,right,
                upleft,upright,downleft,downright);
            }

            return Next;
        }
        public void Update()
        {
            for(int i = 0; i < BoardCells.Length; i++)
            {
                BoardCells[i].active = Next[i].active;
                BoardCells[i].currentColor = Next[i].currentColor;
                BoardCells[i].type = Next[i].type;
            }
        }
        public void PrintBoard()
        {
            Console.Clear();
            for(int i = 0; i < BoardCells.Length; i++)
            {
                Console.ForegroundColor = BoardCells[i].currentColor;
                string c = BoardCells[i].type;
                if (BoardCells[i].active) Console.Write(c);
                else Console.Write(" ");
                if(i%dimX == dimX-1) Console.WriteLine();
            }
        }
    }
}