using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GameOfLife.Helpers
{
    [TestClass]
    public class EnginehelperTests
    {
        EngineHelper engineHelper;

        [TestInitialize]
        public void SetUp()
        {
            engineHelper = new EngineHelper();
            
            
        }
        [TestMethod]
        public void GetStatus_CellAlive_ReturnsAlive()
        {
            var result = engineHelper.GetStatus(1);

            Assert.AreEqual(1,result);
        }

        [TestMethod]
        public void GetStatus_CellDead_ReturnsDead()
        {
            var result = engineHelper.GetStatus(0);

            Assert.AreEqual(0, result);
        }

        [TestMethod]
        public void GetNeighbours_WhenCalled_ReturnsValue()
        {
            var result = engineHelper.GetNeighbours(TestArray(),2,2,1,1);

            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(int));
        }
        [TestMethod]
        public void ComputeNextGeneration_WhenCalled_ReturnsNewCellWithNewState()
        {
            var result = engineHelper.ComputeNextGeneration(TestArray(),1,1,2,2);

            Assert.AreNotSame(TestArray(), result);
        }

        [TestMethod]
        public void ComputeNextGeneration_CurrentCellAliveAndNeighbourLessThanTwo_ReturnDead()
        {
            int[,] cell = new int[,] { { 0, 0, 0, 0 }, { 1, 1, 1, 1 }, { 0, 0, 0, 0 } };

            var result = engineHelper.ComputeNextGeneration(cell, cell[1, 1], 1, 1, 1);

            Assert.AreEqual(0, result[0, 0]);
        }

        [TestMethod]
        public void ComputeNextGeneration_CurrentCellAliveAndNeighbourGreaterThanThree_ReturnDead()
        {
            int[,] cell = new int[,] { { 0, 0, 0, 0 }, { 1, 1, 1, 1 }, { 0, 0, 0, 0 } };

            var result = engineHelper.ComputeNextGeneration(cell, cell[1, 1], 4, 1, 1);

            Assert.AreEqual(0, result[0, 0]);
        }

        [TestMethod]
        public void ComputeNextGeneration_CurrentCellDeadAndAliveNeigboursEqualThree_ReturnAlive()
        {
            int[,] cell = new int[,] { { 0, 0, 0, 0 }, { 1, 1, 1, 1 }, { 0, 0, 0, 0 } };

            var result = engineHelper.ComputeNextGeneration(cell, cell[1, 0], 3, 1, 1);

            Assert.AreEqual(1, result[1, 1]);
        }
        int[,] TestArray()
        {
            return new int[,] { { 0, 0, 0, 0 }, { 1, 1,1,1},
                                { 0, 0, 0, 0 }, { 1, 1, 1, 1 }
                              };
        }

    }
}
