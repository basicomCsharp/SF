using Practices;
namespace Practices.Test
{
    /// <summary>
    /// �������� ����� ��� Practices.Calculator
    /// </summary>
    [TestFixture]
    public class CalculatorTests
    {
        [SetUp]
        public void Setup()
        {
        }
        /// <summary>
        /// ���� ��� ������ ��������
        /// </summary>
        [Test]
        public void Additional_MustRetirnCorrectValue()
        {
            Calculator calc = new Calculator();
            Assert.That(calc.Additional(123, 321) == 444);
        }
        /// <summary>
        /// ���� ��� ������ ��������
        /// </summary>
        [Test]
        public void Additional_MustRetirnNotCorrectValue()
        {
            Calculator calc = new Calculator();
            Assert.That(calc.Additional(123, 321) != 4);
        }
        /// <summary>
        /// ���� ��� ������ ���������
        /// </summary>
        [Test]
        public void Subtraction_MustReturnCorrectValue()
        {
            Calculator calc = new Calculator();
            Assert.That(calc.Subtraction(333, 10) == 323);
        }
        /// <summary>
        /// ���� ��� ������ ���������
        /// </summary>
        [Test]
        public void Subtraction_MustReturnNotCorrectValue()
        {
            Calculator calc = new Calculator();
            Assert.That(calc.Subtraction(333, 10) != 333);
        }
        /// <summary>
        /// ���� ��� ������ �������
        /// </summary>
        [Test]
        public void Division_MustReturnCorrectValue()
        {
            Calculator calc = new Calculator();
            Assert.That(calc.Division(777, 10) == 77);
        }
        /// <summary>
        /// ���� ��� ������ �������
        /// </summary>
        [Test]
        public void Division_MustReturnNotCorrectValue()
        {
            Calculator calc = new Calculator();
            Assert.That(calc.Division(777, 10) != 7);
        }
        /// <summary>
        /// ���� ��� ������ ������� ��� �������� 0 
        /// </summary>
        [Test]
        public void Division_MustThrowException()
        {
            var calc = new Calculator();
            Assert.Throws<DivideByZeroException>(() => calc.Division(1, 0));
        }
    }
}