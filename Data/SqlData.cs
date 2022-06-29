using Salary_Calculator.Pages;
using System.Data.SqlClient;

namespace Salary_Calculator.Data
{
    public partial class SqlData
    {
        private static string connectionString = @"workstation id=TaxCalculator.mssql.somee.com;packet size=4096;user id=F1R3BUL_SQLLogin_1;pwd=r8gf2b94o4;data source=TaxCalculator.mssql.somee.com;persist security info=False;initial catalog=TaxCalculator";
        public static string Statement = "";
        public static string DataOutput = "";
        public static string ConnectionTest()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    connection.Close();
                    return "Connection Success";
                }
            }
            catch
            {
                return "Connection Error";

            }
        }
        public static void OUTPUT(string statement)
        {
            Statement = statement;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                CalculatorDAO.status = "Connection Success";
                string CheckIfExists = "SELECT * FROM dbo.Employees WHERE Name= '" + CalculatorDAO.EmployeeName + "'";
                SqlCommand sqlCommand = new SqlCommand(CheckIfExists, connection);
                var reader = sqlCommand.ExecuteReader();
                if(reader.HasRows)
                {
                    reader.Close();
                    CalculatorDAO.status = "Error: Employee already exists";               
                }
                else
                {
                    reader.Close();
                    CalculatorDAO.status = "Successfuly added!";
                    sqlCommand = new SqlCommand(Statement, connection);
                    reader = sqlCommand.ExecuteReader();
                    reader.Close();
                }
                connection.Close();
            }
        }
        public static void INPUT(string statement)
        {
            Statement = statement;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                CalculatorDAO.status = "Connection Success";
                SqlCommand sqlCommand = new SqlCommand(Statement, connection);
                SqlDataReader reader = sqlCommand.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        if (reader.FieldCount <= 3)
                        {
                            List<string> value = new List<string>() { reader.GetValue(0).ToString(), reader.GetValue(1).ToString().Trim(), reader.GetValue(2).ToString().Trim() };
                            string[] arr = string.Join(" ", value).ToString().Split();
                            CalculatorDAO.EmployeeName = arr[1];
                            SalaryCalculator.Salary = arr[2];
                        }
                        else
                        { 
                        List<string> value = new List<string>() { reader.GetValue(0).ToString(), reader.GetValue(1).ToString().Trim(), reader.GetValue(2).ToString().Trim(), reader.GetValue(3).ToString().Trim(), reader.GetValue(4).ToString() };
                        string[] arr = string.Join(" ", value).ToString().Split();
                            SalaryCalculator.MinSalary = arr[1];
                            SalaryCalculator.IncomeTax = arr[2];
                            SalaryCalculator.InsuranceTax = arr[3];
                            SalaryCalculator.InsuranceMaxTax = arr[4];

                    }
                    }
                    CalculatorDAO.status = "Employee found";
                }
                else
                {
                    CalculatorDAO.status = "Employee not found";
                }
                reader.Close();
                connection.Close();
            }
        }
    }
}
