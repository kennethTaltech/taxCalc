

namespace EX_10_2
{
    public class TaxCalculator
    {

        public static void Main(string[] args){}

        // Private fields for storing monthly and yearly salaries
        private double _monthlySalary;
        private double _yearlySalary;

        // Method for setting yearly salary based on monthly income
        public void AddMonthlyIncome(double monthly)
        {
            _monthlySalary = monthly;
            _yearlySalary = _monthlySalary * 12;
        }

        // Method for setting monthly salary based on yearly income
        public void AddYearlyIncome(double yearly)
        {
            _yearlySalary = yearly;
            _monthlySalary = _yearlySalary / 12;
        }

        // Getters for yearly and monthly salaries
        public double GetYearlySalary() => _yearlySalary;
        public double GetMonthlySalary() => _monthlySalary;

        // Calculate the yearly tax-free amount based on Estonian tax rules
        public double GetYearlyTaxFreeAmount()
        {
            if (_yearlySalary < 14400)
            {
                return 7848;
            }
            else if (_yearlySalary <= 25200)
            {
                
                return 7848.00 - (7848.00 / 10800.00) * (_yearlySalary - 14400.00);
            }
            else
            {
                return 0;
            }
        }

        // Calculate the monthly tax-free amount
        public double GetMonthlyTaxFreeAmount()
        {
            return GetYearlyTaxFreeAmount() / 12;
        }

        // Print the result in a nicely formatted way
        public void FindTaxFreeAmount()
        {
            Console.WriteLine($"If yearly salary is {_yearlySalary}, then the monthly tax-free amount is {GetMonthlyTaxFreeAmount():0.00} euros and the yearly tax-free amount is {GetYearlyTaxFreeAmount():0.00} euros");
        }
    }
}
