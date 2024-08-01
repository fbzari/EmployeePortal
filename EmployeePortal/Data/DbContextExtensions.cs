using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace EmployeePortal.Data
{
    public class DbContextExtensions
    {
        public static void EnsureDatabaseMigrated(IServiceProvider serviceProvider, int retryCount = 5, int delayInSeconds = 5)
        {
            int attempt = 0;
            while (attempt < retryCount)
            {
                try
                {
                    using (var scope = serviceProvider.CreateScope())
                    {
                        var dbContext = scope.ServiceProvider.GetRequiredService<MVCDemoDbContext>();
                        dbContext.Database.Migrate();
                        return; // Exit the loop if migration succeeds
                    }
                }
                catch (SqlException)
                {
                    attempt++;
                    if (attempt >= retryCount)
                    {
                        throw; // Re-throw the exception if the maximum number of retries is reached
                    }
                    Thread.Sleep(delayInSeconds * 1000); // Wait before retrying
                }
            }
        }
    }
}
