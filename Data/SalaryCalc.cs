using Salary_Calculator.Pages;
using System.Data.SqlClient;

namespace Salary_Calculator.Data;
public class SalaryCalculator
{
    public static string MinSalary = null;
    public static string InsuranceMaxTax = null;
    public static string IncomeTax = null;
    public static string InsuranceTax = null;
    public static string Salary = null;
    public static void Calculate(string salary)
    {
        CalculatorDAO.Statement = "SELECT * FROM dbo.Taxes WHERE id=(SELECT max(id) FROM dbo.Taxes);";
        CalculatorDAO.READ();
        double MinSal = double.Parse(MinSalary);
        double Insurance = double.Parse(InsuranceTax);
        double Income = double.Parse(IncomeTax);
        double InsuranceMax = double.Parse(InsuranceMaxTax);
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
