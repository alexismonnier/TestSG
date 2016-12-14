using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BowlingGame;

namespace BowlingGameTest
{
    [TestClass]
    public class GameTest
    {
        //private TestContext TestContextInstance;
        //public TestContext TestContext
        //{
        //    get { return TestContextInstance; }
        //    set { TestContextInstance = value; }
        //}

        private Game g;

        [TestInitialize]
        public void Initialize()
        {
            g = new Game();
        }

        [TestCleanup]
        public void Cleanup()
        {
            g = null;
        }

        [TestMethod]
        public void TestAll0()
        {
            MultipleRolls(20, 0);
            Assert.AreEqual(0, g.Score());
        }

        [TestMethod]
        public void TestAll1()
        {
            MultipleRolls(20, 1);
            Assert.AreEqual(20, g.Score());
        }

        [TestMethod]
        public void TestSpare()
        {
            g.Roll(5);
            g.Roll(5);
            g.Roll(3);
            MultipleRolls(17, 0);

            Assert.AreEqual(16, g.Score());
        }

        [TestMethod]
        public void TestStrike()
        {
            g.Roll(10);
            g.Roll(3);
            g.Roll(4);
            MultipleRolls(16, 0);

            Assert.AreEqual(24, g.Score());
        }

        [TestMethod]
        public void TestPerfectGame()
        {
            MultipleRolls(12, 10);

            Assert.AreEqual(300, g.Score());
        }

        [TestMethod]
        public void TestNormalGame()
        {
            g.Roll(1);
            g.Roll(2);

            g.Roll(3);
            g.Roll(4);

            g.Roll(5);
            g.Roll(5); //spare

            g.Roll(7);
            g.Roll(2);

            g.Roll(10); //strike

            g.Roll(2);
            g.Roll(3);

            g.Roll(3);
            g.Roll(4);

            g.Roll(2);
            g.Roll(1);

            g.Roll(9);
            g.Roll(1); //spare

            g.Roll(4);
            g.Roll(6); //spare

            g.Roll(10); //strike

            Assert.AreEqual(100, g.Score());
        }

        private void MultipleRolls(int rolls, int pins)
        {
            for (int i = 0; i < rolls; i++)
            {
                g.Roll(pins);
            }
        }

    }
}
