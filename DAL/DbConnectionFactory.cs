
using Microsoft.Data.SqlClient;

namespace QuanLySinhVien.DAL
{
    public static class DbConnectionFactory
    {
        private const string ConnectionString =
            @"Server=ltnc;Database=QuanLySinhVien;Integrated Security=True;Encrypt=True;TrustServerCertificate=True;";

        public static SqlConnection CreateConnection()
        {
            return new SqlConnection(ConnectionString);
        }
    }
}

