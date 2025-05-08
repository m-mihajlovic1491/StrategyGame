
using Microsoft.EntityFrameworkCore;
using StrategyGame.Data;
using System;

namespace StrategyGame
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            builder.Services.AddDbContext<StrategyGameContext>(o => o.UseSqlServer(
                builder.Configuration.GetConnectionString("DatabaseConnection")));

            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            

            var app = builder.Build();

            // Configure the HTTP request pipeline.

            //TODO: move this logic to Yaml pipeline

            using (var scope = app.Services.CreateScope())
            {
                var dbContext = scope.ServiceProvider.GetRequiredService<StrategyGameContext>();

                var pendingMigrations = dbContext.Database.GetPendingMigrations();
                if (pendingMigrations.Any() && app.Environment.IsProduction()) 
                {
                    Console.WriteLine("Applying pending migrations...");
                    dbContext.Database.Migrate();
                }
                else
                {
                    Console.WriteLine("No pending migrations.");
                }
            }


            app.UseSwagger();
            app.UseSwaggerUI();
            

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.MapGet("/", () => Results.Redirect("/swagger"))
                .ExcludeFromDescription();

            app.Run();
        }
    }
}
