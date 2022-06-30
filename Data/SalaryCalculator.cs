using Salary_Calculator.Pages;

namespace Salary_Calculator.Data;
public class SalaryCalculator
{
    public static double MinSalary = 0;
    public static double InsuranceMaxTax = 0;
    public static double IncomeTax = 0;
    public static double InsuranceTax = 0;
    public static double  Salary = 0;
    public static void Calculate(double salary)
    {
        CalculatorDAO.Statement = "SELECT * FROM dbo.Taxes WHERE id=(SELECT max(id) FROM dbo.Taxes);";
        CalculatorDAO.READ();
        double MinSal = MinSalary;
        double Insurance = InsuranceTax/100;
        double Income = IncomeTax/100;
        double InsuranceMax = InsuranceMaxTax;
        double sal = Math.Round(salary, 2);
        double value;
        if (sal > MinSal)
        {
            double insvalue = Math.Round(salary, 2);
            if (insvalue > InsuranceMax)
            {
                value = (sal - MinSal) * Income;
                insvalue = (InsuranceMax - MinSal) * Insurance;
                sal = sal - (value + insvalue);
            }
            else
            {
                insvalue = (sal-MinSal) * Insurance;
                value = (sal - MinSal) * Income;
                sal = sal - (value + insvalue);
            }
            SalaryCalculator.Salary = Math.Abs(Math.Round(sal, 2));
        }
        else
        {
            SalaryCalculator.Salary = Math.Abs(Math.Round(sal, 2));
        }
    }
}
