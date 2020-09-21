using GameOfLife.Interfaces;
using System;
using System.Security.Cryptography;

namespace GameOfLife
{
    public class Grid : IGrid
    {
        #region Fields
        private int[,] _array;
        private int[,] _gridLayout;
        private int _columns;
        private int _rows;
        #endregion

        #region Constructor
        public Grid()
        {
            _array = new int[0, 0];
        }
        #endregion

        #region Properties
        public int Rows
        {
            get { return _rows; }
            set { _rows = value; }
        }
        public int Columns
        {
            get { return _columns; }
            set { _columns = value; }
        }
        public int[,] Array
        {
            get { return _array; }
            set { _array = value; }
        }
        public int[,] GridLayout
        {
            get { return _gridLayout; }
            set { _gridLayout = value; }
        }
        #endregion

        #region Methods
        public void CreateGrid(int rows, int columns)
        {
            if (rows <= 1 || columns <= 1)
            {
                throw new ArgumentException("Rows and Columns should be greater than 1");
            }

            InitializeGrid(rows, columns);

        }
        public void InitializeGrid(int rows, int columns)
        {
            _array = new int[rows, columns];

            for (int i = 0; i < _array.GetLength(0); i++)
            {
                for (int j = 0; j < _array.GetLength(1); j++)
                {
                    _array[i, j] = RandomNumberGenerator.GetInt32(0, 2);
                }

            }

            _gridLayout = _array;
            _rows = rows;
            _columns = columns;
            
        }
        
        #endregion
    }
}
