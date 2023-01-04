using FigureArea;

namespace TestFigureArea
{
    [TestClass]
    public class UnitTestCircle
    {
        private const double precision = 0.001;
        [TestMethod]
        public void TestCircle1()
        {
            var figure = Circle.Create(5.5);
            Assert.IsNotNull(figure);
        }
        [TestMethod]
        public void TestCircle2()
        {
            Assert.ThrowsException<ArgumentException>(() => Circle.Create(-2.1));
            Assert.ThrowsException<ArgumentException>(() => Circle.Create(0));
        }
        [TestMethod]
        public void TestCircle3()
        {
            var figure = Circle.Create(5.5);
            var area = figure.Calc();
            Assert.IsTrue(Math.Abs(95.033 - area) < precision);
        }
    }
}