using Salary_Calculator.Data;
namespace Salary_Calculator.Pages
{    
    public partial class CalculatorDAO 
    {
        public static string status = "Failed";
        public static string EmployeeName = null;
        public static string Statement = "";
        public static void Connection()
        {
            SalaryCalculator.DatabaseConnectionOpen();
        }
        public static void ADD()
        {
            SqlData.OUTPUT(Statement);
        }
        public static void REMOVE()
        {
            SqlData.OUTPUT(Statement);
        }
        public static void READ()
        {
            SqlData.INPUT(Statement);
        }
    }
}
