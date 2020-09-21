using GameOfLife.Interfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;

namespace GameOfLife
{
    [TestClass]
    public class GridTests
    {
        Grid grid;
        int[,] testData;

        [TestInitialize]
        public void SetUp()
        {
            testData = TestArray();

            var mockGrid = new Mock<IGrid>();
            mockGrid.Setup(grid => grid.InitializeGrid(10, 10));

            grid = new Grid();
        }

        [TestMethod]
        public void InitializeGrid_WhenCalled_InitializedTheGrid()
        {
            grid.InitializeGrid(TestArray().GetUpperBound(0), TestArray().GetUpperBound(1));

            Assert.AreEqual(2, grid.Array.GetUpperBound(0));
            Assert.AreEqual(2, grid.Array.GetUpperBound(1));
        }



        [DataTestMethod]
        [DataRow(1, 2)]
        [DataRow(2, 1)]
        [ExpectedException(typeof(ArgumentException))]
        public void CreateGrid_RowsOrColumsLessThanTwo_ThrowAgumentException(int row, int column)
        {
            grid.CreateGrid(row, column);
        }

        int[,] TestArray()
        {
            return new int[,] { { 0, 0, 0, 0 }, { 1, 1,1,1},
                                { 0, 0, 0, 0 }, { 1, 1, 1, 1 }
                              };
        }
    }
}
