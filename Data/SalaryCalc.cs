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
    public static void DatabaseConnectionOpen()
    {
        SqlData.ConnectionTest();
    }
    public static void Calculate(string salary)
    {
        double value = Math.Round(double.Parse(salary), 2);
        value = 3100;
        if (value >= 1000)
        {
            value = value - (value * 0.1 + value * 0.15); 
            Math.Round(value, 2);
            SalaryCalculator.Salary = salary.ToString();
        }
        else
        {
            SalaryCalculator.Salary = salary.ToString();
        }
    }
}
