using Salary_Calculator.Pages;

namespace Salary_Calculator.Data;
public class SalaryCalculator
{
    public static double MinSalary = 0;
    public static double InsuranceMaxTax = 0;
    public static double IncomeTax = 0;
    public static double InsuranceTax = 0;
    public static string Salary = null;
    public static void Calculate(string salary)
    {
        CalculatorDAO.Statement = "SELECT * FROM dbo.Taxes WHERE id=(SELECT max(id) FROM dbo.Taxes);";
        CalculatorDAO.READ();
        double MinSal = MinSalary;
        double Insurance = InsuranceTax/100;
        double Income = IncomeTax/100;
        double InsuranceMax = InsuranceMaxTax;
        double sal = Math.Round(double.Parse(salary), 2);
        double value;
        if (sal >= MinSal)
        {
            double insvalue = Math.Round(double.Parse(salary), 2);
            if (insvalue >= InsuranceMax)
            {
                value = sal - ((sal - 1000) * Income);
                insvalue = sal - ((InsuranceMax - MinSal) * Insurance);
                sal = sal - (value + insvalue);
            }
            else
            {
                insvalue = sal - (sal * Insurance);
                value = sal - (((sal - 1000) * Income) + insvalue);
                sal = sal - (value + insvalue);
            }
            SalaryCalculator.Salary = Math.Abs(Math.Round(sal, 2)).ToString();
        }
        else
        {
        }
    }
}
