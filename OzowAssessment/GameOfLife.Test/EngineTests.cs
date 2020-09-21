using GameOfLife.Interfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace GameOfLife
{
    [TestClass]
    public class MyTestClass
    {
        Engine engine;

        [TestInitialize]
        public void Setup()
        {
            var mockGrid = new Mock<IGrid>();
            mockGrid.Setup(grid => grid.InitializeGrid(10, 10));

            engine = new Engine(mockGrid.Object);
        }

        [TestMethod]
        public void GetNextGeneration_WheCalled_ReturnsNewGeneration()
        {
            var result = engine.GetNextGeneration(TestArray());

            Assert.AreNotSame(TestArray(), result);
        }
        int[,] TestArray()
        {
            return new int[,] { { 0, 0, 0, 0 }, { 1, 1,1,1},
                                { 0, 0, 0, 0 }, { 1, 1, 1, 1 }
                              };
        }

    }
    
}
