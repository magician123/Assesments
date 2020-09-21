using System;
using System.Diagnostics;

namespace GameOfLife.UI
{
    static class Program
    {
        public static void Main()
        {
            try
            {
                Stopwatch stopwatch = new Stopwatch();
                Grid grid = new Grid();
                Engine engine = new Engine(grid);

                Console.WriteLine("Welcome to the Game of life");
                Console.Write("Set your grid rows ");
                int rows = Int32.Parse(Console.ReadLine());
                Console.Write("Set your grid columns ");
                int columns = Int32.Parse(Console.ReadLine());
                Console.Clear();

                grid.InitializeGrid(rows, columns);
                int NumberOfRepetiotions = 10000;

                engine.DisplayGrid(grid.GridLayout);

                stopwatch.Start();

                while (NumberOfRepetiotions > 0)
                {
                    var newGridLayout = engine.GetNextGeneration(grid.GridLayout);
                    grid.GridLayout = newGridLayout;

                    engine.DisplayGrid(newGridLayout);

                    NumberOfRepetiotions--;
                }

                stopwatch.Stop();

                Console.ReadKey();

            }
            catch (Exception)
            {

                throw;
            }
            
        }

    }
   
}






       
   

