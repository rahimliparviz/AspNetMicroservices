using System.Data;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Npgsql;

namespace Discount.API.Extensions
{
    public static class HostExtensions
    {
        public static IHost MigrateDb<TContext>(this IHost host, int retry = 0)
        {
            int retryForAvailability = retry;

            using var scope = host.Services.CreateScope();
            var services = scope.ServiceProvider;
            var connection = (NpgsqlConnection)services.GetRequiredService<IDbConnection>();
            var logger = services.GetRequiredService<ILogger<TContext>>();

            try
            {
                logger.LogInformation("Migrating postresql database.");

                
                connection.Open();

                using var command = new NpgsqlCommand
                {
                    Connection = connection, CommandText = "DROP TABLE IF EXISTS Coupon"
                };

                command.ExecuteNonQuery();

                command.CommandText = @"CREATE TABLE Coupon(Id SERIAL PRIMARY KEY, 
                                                                ProductName VARCHAR(24) NOT NULL,
                                                                Description TEXT,
                                                                Amount INT)";
                command.ExecuteNonQuery();

                command.CommandText = "INSERT INTO Coupon(ProductName, Description, Amount) VALUES('At', 'Heyvandidaa', 15);";
                command.ExecuteNonQuery();
                
                command.CommandText = "INSERT INTO Coupon(ProductName, Description, Amount) VALUES('IPhone X', 'IPhone Discount', 150);";
                command.ExecuteNonQuery();

                command.CommandText = "INSERT INTO Coupon(ProductName, Description, Amount) VALUES('Samsung 10', 'Samsung Discount', 100);";
                command.ExecuteNonQuery();

                logger.LogInformation("Migrated postresql database.");
                
                connection.Close();
            }
            catch (NpgsqlException ex)
            {
                logger.LogError(ex, "An error occurred while migrating the postresql database");

                if (retryForAvailability < 50)
                {
                    retryForAvailability++;
                    System.Threading.Thread.Sleep(2000);
                    MigrateDb<TContext>(host, retryForAvailability);
                }
            }

            return host;
        }
    }
}