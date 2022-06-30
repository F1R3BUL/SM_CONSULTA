using Salary_Calculator.Data;
namespace Salary_Calculator.Pages
{    
    public partial class CalculatorDAO 
    {
        public static string status = "Failed";
        public static string RegisterStatus = "Waiting for information";
        public static string CalculateStatus = "Waiting for information";
        public static string TaxStatus = "Waiting for information";
        public static string EmployeeName = null;
        public static string Statement = "";
        public static void ADD()
        {
            SqlData.OUTPUT(Statement);
        }
        public static void CHANGE()
        {
            SqlData.UPDATE(Statement);
        }
        public static void ADDTAX()
        {
            SqlData.TAXOUTPUT(Statement);
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
