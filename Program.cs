using BA;

//Do not make us of this program if you suffer from epeleptic attacks.

int x,y,size;
int radius = 1;

Menu.Run = true;
while(Menu.Run)
{
    //Prints the menu
    Menu newMenu = new Menu();
    newMenu.RunMenu();
    x = newMenu.xVal;
    y = newMenu.yVal;
    size = x*y;
    Cell.color1 = newMenu.MenuColor1;
    Cell.color2 = newMenu.MenuColor2;


    Board B = new Board(x,y);
    
    //Finds the best spot to start simulating the pattern
    int midPoint;
    if(y%2 == 1) midPoint = (x*y) / 2;
    else midPoint  = (size+x) / 2;
    
    //Creates an int list containing the index of values of the the startup square
    List<int> startCells = new List<int>();
    for (int i = -radius; i <= radius; i++)
    {
        for (int j = -radius; j <= radius; j++)
        {
            startCells.Add(midPoint-i*x-j);
        }
    }
    B.StartupConfig(startCells);
    
    //Runs program
    if(Menu.Run)
    {
        int time = 0;
        while(time<1000)
        {
            B.PrintBoard();
            B.CalculateNextBoard();
            B.Update();
            Thread.Sleep(100);
            time++;
            if(Console.KeyAvailable)
            {
                if (Console.ReadKey(true).Key == ConsoleKey.Q) break;
            }
        }
    }
    else Console.Clear();
}
