namespace Apartment.Business
{
    public static class Startup
    {
        public static void PassConnectionString(string connectionString)
        {
            EFData.Startup.PassConnectionString(connectionString);
        }
    }
}