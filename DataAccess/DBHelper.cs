using System.Configuration;
using System.Data.SqlClient;

namespace RodjendanProjekat.DataAccess
{
    public static class DBHelper
    {
        public static SqlConnection GetConnection()
        {
            string cs = ConfigurationManager.ConnectionStrings["RodjendaniDB"].ConnectionString;
            return new SqlConnection(cs);
        }
    }
}