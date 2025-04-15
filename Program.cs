
using Microsoft.EntityFrameworkCore;
using StrategyGame.Data;

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
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.MapGet("/", () => Results.Redirect("/swagger"))
                .ExcludeFromDescription();

            app.Run();
        }
    }
}
