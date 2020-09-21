using GameOfLife.Helpers;
using GameOfLife.Interfaces;
using System;
using System.Text;
using System.Threading;

namespace GameOfLife
{
    public class Engine
    {
        #region Fields
       
        private IGrid _grid;
        private EngineHelper engineHelper;
        #endregion

        #region Constructors
        public Engine(IGrid grid)
        {
            _grid = grid;

            engineHelper = new EngineHelper();
        }
        #endregion
        #region Methods 
        public int[,] GetNextGeneration(int[,] currentGrid)
        {
            var nextGeneration = new int[_grid.Rows, _grid.Columns];

            for (var row = 1; row < _grid.Rows - 1; row++)
                for (var column = 1; column < _grid.Columns - 1; column++)
                {
                    var aliveNeighbours = 0;

                    for (var i = -1; i <= 1; i++)
                    {
                        for (var j = -1; j <= 1; j++)
                        {
                            aliveNeighbours += engineHelper.GetNeighbours(currentGrid, row, column, i, j);
                        }
                    }

                    var currentCell = currentGrid[row, column];
                    aliveNeighbours -= engineHelper.GetStatus(currentCell);

                    nextGeneration = engineHelper.ComputeNextGeneration(nextGeneration,currentCell, aliveNeighbours, row, column);
                    
                }
            return nextGeneration;
        }   
        public void DisplayGrid(int[,] grid)
        {
            var stringBuilder = new StringBuilder();
            for (var row = 0; row < _grid.Rows; row++)
            {
                for (var column = 0; column < _grid.Columns; column++)
                {
                    var cell = grid[row, column];
                    stringBuilder.Append(engineHelper.GetStatus(cell));
                }
                stringBuilder.Append("\n");
            }

            Console.CursorVisible = false;
            Console.SetCursorPosition(0, 0);
            Console.Write(stringBuilder.ToString());
            Thread.Sleep(500);

        }
        
        #endregion
    }
}
