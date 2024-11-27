using EX_10_2;

namespace TaxTests
{
    [TestClass]
    public class TaxCalculatorTests
    {
        private TaxCalculator _taxCalculator;

        [TestInitialize]
        public void Setup()
        {
            _taxCalculator = new TaxCalculator();
        }

        [TestMethod]
        public void Test_AddMonthlyIncome_CalculatesYearlySalaryCorrectly()
        {
            _taxCalculator.AddMonthlyIncome(100);
            Assert.AreEqual(1200, _taxCalculator.GetYearlySalary());
        }

        [TestMethod]
        public void Test_AddYearlyIncome_CalculatesMonthlySalaryCorrectly()
        {
            _taxCalculator.AddYearlyIncome(1200);
            Assert.AreEqual(100, _taxCalculator.GetMonthlySalary());
        }

        [TestMethod]
        public void Test_GetYearlyTaxFreeAmount_Under14400()
        {
            _taxCalculator.AddYearlyIncome(14000);
            Assert.AreEqual(7848, _taxCalculator.GetYearlyTaxFreeAmount());

            _taxCalculator.AddYearlyIncome(0);
            Assert.AreEqual(7848, _taxCalculator.GetYearlyTaxFreeAmount());
        }

        [TestMethod]
        public void Test_GetYearlyTaxFreeAmount_Between14400And25200()
        {
            _taxCalculator.AddYearlyIncome(20000);
            Assert.AreEqual(3778.67, _taxCalculator.GetYearlyTaxFreeAmount(), 0.02);

            _taxCalculator.AddYearlyIncome(25199);
            Assert.AreEqual(0.73, _taxCalculator.GetYearlyTaxFreeAmount(), 0.02);


        }

        [TestMethod]
        public void Test_GetYearlyTaxFreeAmount_Over25200()
        {
            _taxCalculator.AddYearlyIncome(26000);
            Assert.AreEqual(0, _taxCalculator.GetYearlyTaxFreeAmount());

            _taxCalculator.AddYearlyIncome(500000);
            Assert.AreEqual(0, _taxCalculator.GetYearlyTaxFreeAmount());

        }

        [TestMethod]
        public void Test_GetMonthlyTaxFreeAmount()
        {
            _taxCalculator.AddYearlyIncome(20000);
            Assert.AreEqual(314.89, _taxCalculator.GetMonthlyTaxFreeAmount(), 0.02);
        }
    }
}