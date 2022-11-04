using System.Data;
using System.Data.SqlClient;

namespace WpfAppZone.Classes
{
    public class DBConnection
    {
        SqlConnection sqlConnection = new SqlConnection(@"Data Source=DESKTOP-CS7ATDQ\SQLEXPRESS;Initial Catalog=ZCompany;Integrated Security=True");

        public void oppenConnection()
        {
            if (sqlConnection.State == System.Data.ConnectionState.Closed)
                sqlConnection.Open();
        }

        public void closeConnection()
        {
            if (sqlConnection.State == System.Data.ConnectionState.Open)
                sqlConnection.Close();
        }

        public SqlConnection getConnection()
        {
            return sqlConnection;
        }

       }
}
 
