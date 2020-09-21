namespace GameOfLife.Interfaces
{
    public interface IGrid
    {
        public int Rows { get; set; }
        public int Columns { get; set; }
        int[,] GridLayout { get; set; }
        void InitializeGrid(int rows, int columns);
        void CreateGrid(int rows, int columns);
        
    }
}
