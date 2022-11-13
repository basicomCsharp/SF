using NUnit.Framework;

namespace Practices.Tests
{
    [TestFixture]
    public class CalculatorTest
    {
        [Test]
        public void Division_MustReturnCorrectValue()
        {
            var calculator = new Calculator();
            Assert.That(calculator.Division(200, 10) == 20);
        }
    }
}