namespace EFData
{
    public class Startup
    {
        private static string _connectionString;
        
        public static void PassConnectionString(string connectionString)
        {
            _connectionString = connectionString;
        }

        public static string GetConnectionString()
        {
            return _connectionString;
        }
    }
}