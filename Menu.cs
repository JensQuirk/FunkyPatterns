using System;

namespace BA
{
    class Menu
    {
        public ConsoleColor MenuColor1, MenuColor2;
        public int xVal,yVal;
        public static bool Run;
        public Menu()
        {
            xVal = 51;
            yVal = 31;
            MenuColor1 = ConsoleColor.Red;
            MenuColor2 = ConsoleColor.Cyan;
        }
        public void RunMenu()
        {
            bool runMainMenu = true;
            while (runMainMenu)
            {
                PrintMainMenu();
                ConsoleKey choice = Console.ReadKey().Key;
                if(choice == ConsoleKey.A) PrintColorChanger();
                else if (choice == ConsoleKey.S) ChangeXDimention();
                else if (choice == ConsoleKey.D) ChangeYDimention();
                else if (choice == ConsoleKey.Spacebar){ runMainMenu = false; Run = true;}
                else if (choice == ConsoleKey.Q){ runMainMenu = false; Run = false;}
            }
        }

        private void PrintMainMenu()
        {
            Console.Clear();

            Console.ForegroundColor = MenuColor1;
            Console.Write("|──────────────────────────────────────|\n");
            Console.Write("|"); ChangeColor(); 
            Console.Write(" *Do not utilize this program if you  "); ChangeColor();
            Console.Write("│\n│"); ChangeColor();
            Console.Write("  suffer from epeleptic attacks*      "); ChangeColor();
            Console.Write("│\n|──────────────────────────────────────|\n|"); ChangeColor();
            Console.Write(" This program works best if you       "); ChangeColor();
            Console.Write("|\n|"); ChangeColor();
            Console.Write(" maximize you console window and dont "); ChangeColor();
            Console.Write("|\n|"); ChangeColor();
            Console.Write(" let the board dimentions exceed the  "); ChangeColor();
            Console.Write("|\n|"); ChangeColor();
            Console.Write(" dimentions of your console window.   "); ChangeColor();
            Console.Write("|\n|──────────────────────────────────────|\n");
            Console.Write("|                                      │\n|"); ChangeColor();
            Console.Write(" a - Change the colorscheme           "); ChangeColor();
            Console.Write("|\n│                                      │\n|"); ChangeColor();
            Console.Write($" s - Set X-dimention (current: {xVal})   "); ChangeColor();
            if(xVal<100 && xVal>=10) Console.Write(" "); else if (xVal<10) Console.Write("  ");
            Console.Write("|\n│                                      │\n|"); ChangeColor();
            Console.Write($" d - Set Y-dimention (current: {yVal})   "); ChangeColor();
            if(yVal<100 && yVal>=10) Console.Write(" "); else if (yVal<10) Console.Write("  ");
            Console.Write("|\n│                                      │\n|"); ChangeColor();
            Console.Write(" space - Start simulation             "); ChangeColor();
            Console.Write("|\n│                                      │\n|"); ChangeColor();
            Console.Write(" q - Exit                             "); ChangeColor();
            Console.Write("|\n│                                      │\n");
            Console.Write("|──────────────────────────────────────|");
        }
        private void PrintColorChanger()
        {
            Console.Clear();

            Console.ForegroundColor = MenuColor1;
            Console.Write("|──────────────────────────────────────|\n");
            Console.Write("|                                      │\n|"); ChangeColor();
            Console.Write(" a - Red/Cyan                         "); ChangeColor();
            Console.Write("|\n|                                      │\n|"); ChangeColor();
            Console.Write(" s - Yellow/Green                     "); ChangeColor();
            Console.Write("|\n|                                      │\n|"); ChangeColor();
            Console.Write(" d - Magenta/Blue                     "); ChangeColor();
            Console.Write("|\n|                                      │\n");
            Console.Write("|──────────────────────────────────────|");
            while (true)
            {
                ConsoleKey keyPressed = Console.ReadKey(true).Key;
                if(keyPressed == ConsoleKey.A) {MenuColor1=ConsoleColor.Red; MenuColor2=ConsoleColor.Cyan; break;}
                else if(keyPressed == ConsoleKey.S) {MenuColor1=ConsoleColor.Yellow; MenuColor2=ConsoleColor.Green; break;}
                else if(keyPressed == ConsoleKey.D) {MenuColor1=ConsoleColor.Magenta; MenuColor2=ConsoleColor.Blue; break;}
            }
        }
        private void ChangeXDimention()
        {
            Console.Clear();
            Console.ForegroundColor = MenuColor2;
            while (true)
            {
                try{
                Console.WriteLine("Enter x-dimention: (Should be odd number)");
                xVal = Convert.ToInt32(Console.ReadLine()); break; }
                catch {Console.WriteLine("Invalid input. Try again.");}
            }
        }
        private void ChangeYDimention()
        {
            Console.Clear();
            Console.ForegroundColor = MenuColor2;
            while (true)
            {
                try{
                Console.WriteLine("Enter y-dimention: (Should not equal x-dimention)");
                yVal = Convert.ToInt32(Console.ReadLine()); }
                catch {Console.WriteLine("Invalid input. Try again.");}

                if (yVal!=xVal) break;
                else Console.WriteLine("y-dimention can not be equal to x-dimention. Try agian.");
            }
        }
        private void ChangeColor()
        {
            if(Console.ForegroundColor==MenuColor1)
                Console.ForegroundColor = MenuColor2;
            else
                Console.ForegroundColor = MenuColor1;
        }
        
    }
}