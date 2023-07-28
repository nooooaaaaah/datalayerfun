using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using WNBOT.Tests.Scripts;

namespace WNBOT
{
    class Program
    {
        static void Main(string[] args)
        {
            ServiceProvider serviceProvider = new ServiceCollection()
                .AddDbContext<DatabaseContext>(options =>
                    options.UseSqlite("Data Source=Database/database.db"))
                .BuildServiceProvider();

            // Resolve the DatabaseContext from the container
            using (var dbContext = serviceProvider.GetRequiredService<DatabaseContext>())
            {
                new TestScript(dbContext);
            }

            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }
    }
}
