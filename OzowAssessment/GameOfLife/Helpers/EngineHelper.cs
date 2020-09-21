namespace GameOfLife.Helpers
{
    public class EngineHelper
    {
        private const int ALIVE = 1;
        private const int DEAD = 0;

        public int GetStatus(int cell)
        {
            return (cell == ALIVE) ? 1 : 0;
        }
           
        public int GetNeighbours(int[,] currentGrid, int row, int column, int i, int j)
        {
            return (currentGrid[row + i, column + j] == 1) ? 1 : 0;
               
        }

        public int[,] ComputeNextGeneration(int[,] currentGeneration, int currentCell, int aliveNeighbours, int row, int column)
        {

            if (currentCell == ALIVE && aliveNeighbours < 2)
            {
                currentGeneration[row, column] = DEAD;
            }

            else if (currentCell == ALIVE && aliveNeighbours > 3)
            {
                currentGeneration[row, column] = DEAD;
            }

            else if (currentCell == DEAD && aliveNeighbours == 3)
            {
                currentGeneration[row, column] = ALIVE;
            }

            else
            {
                currentGeneration[row, column] = currentCell;
            }

            return currentGeneration;
        }
    }
}
