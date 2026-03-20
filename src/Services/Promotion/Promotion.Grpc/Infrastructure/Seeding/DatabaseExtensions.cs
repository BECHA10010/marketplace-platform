namespace Promotion.Grpc.Infrastructure.Seeding;

public static class DatabaseExtensions
{
    public static async Task SeedAsync<T>(this IDbConnection connection, ILogger<T> logger, int maxRetries = 5)
    {
        var delay = TimeSpan.FromSeconds(1);
        Exception? lastException = default;
        
        logger.LogInformation("Starting database seeding. Max retries: {Retries}", maxRetries);
        
        for (int attempt  = 1; attempt <= maxRetries; attempt ++)
        {
            try
            {
                logger.LogDebug("Database seeding attempt {Attempt}", attempt);
                
                if (connection.State != ConnectionState.Open)
                {
                    logger.LogDebug("Opening database connection...");
                    connection.Open();
                }
        
                logger.LogDebug("Dropping Promo table");
                const string dropTableSql = "DROP TABLE IF EXISTS Promo";
                await connection.ExecuteAsync(dropTableSql);
        
                logger.LogDebug("Creating Promo table");
                const string createTableSql = """
                                               CREATE TABLE IF NOT EXISTS Promo (
                                                 Id CHAR(36) NOT NULL PRIMARY KEY,
                                                 CatalogItemId VARCHAR(255) NOT NULL,
                                                 Description VARCHAR(255) NOT NULL,
                                                 Value DECIMAL(18,2) NOT NULL
                                               );
                                               """;
                await connection.ExecuteAsync(createTableSql);

                var promos = InitialData.GetInitialPromos;

                logger.LogInformation("Inserting {Count} promo records", promos.Count());
                const string insertSql = """
                                          INSERT INTO Promo (Id, CatalogItemId, Description, Value)
                                          VALUES (@Id, @CatalogItemId, @Description, @Value);
                                          """;
                await connection.ExecuteAsync(insertSql, promos);
    
                logger.LogInformation("Database seeding completed successfully");
                return;
            }
            catch (MySqlException ex) when (attempt < maxRetries)
            {
                lastException = ex;
                
                logger.LogWarning("Seeding database failed on attempt {Attempt}. Retrying...", attempt);
                
                if (connection.State == ConnectionState.Open)
                {
                    connection.Close();
                }
                
                await Task.Delay(delay);
                delay = TimeSpan.FromSeconds(Math.Min(delay.TotalSeconds * 2, 10));
            }
            catch (Exception ex)
            {
                lastException = ex;
                logger.LogError(ex, "Seeding database failed on attempt {Attempt}. Aborting.", attempt);
                break;
            }
        }
        
        throw new InvalidOperationException($"Failed to seed the database after {maxRetries} attempts", lastException);
    }
}