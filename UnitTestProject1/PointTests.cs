using GeneralUtilities;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestProject1
{
    [TestClass]
    public class PointTests
    {
        [TestMethod]
        public void InstantiationTest1()
        {
            var point = new Point2();

            Assert.AreEqual(0, point.X);
            Assert.AreEqual(0, point.Y);
        }

        [TestMethod]
        public void InstantiationTest2()
        {
            Point2 point = Point2.Create(1, 1);

            Assert.AreEqual(1, point.X);
            Assert.AreEqual(1, point.Y);
        }
    }
}