using FigureArea;

namespace TestFigureArea
{
    [TestClass]
    public class UnitTestTriangle
    {
        private const double precision = 0.001;
        [TestMethod]
        public void TestTriangle1()
        {
            var figure = Triangle.Create(5.5, 4.2, 9.7);
            Assert.IsNotNull(figure);
        }
        [TestMethod]
        public void TestTriangle2()
        {
            Assert.ThrowsException<ArgumentException>(() => Triangle.Create(-2.1, 1, 1));
            Assert.ThrowsException<ArgumentException>(() => Triangle.Create(2, 4, 0));
            Assert.ThrowsException<ArgumentException>(() => Triangle.Create(5.5, 10, 45));
        }
        [TestMethod]
        public void TestTriangle3()
        {
            var figure = Triangle.Create(12, 10, 17);
            var area = figure.Calc();
            Assert.IsTrue(Math.Abs(58.935 - area) < precision);
        }
    }
}