using Microsoft.EntityFrameworkCore;
using Project.EFCore.Infrastructure;
using ToDoList.Application.Context;

namespace ToDoList
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            if (builder.Environment.IsDevelopment())
            {
                builder.Services.AddDbContext<IToDoListDbContext, ToDoListDbContext>(options =>
                {
                    options.UseSqlServer(builder.Configuration.GetConnectionString("ToDoListDbDev"));
                });
            }

            var app = builder.Build();

            using (var scope = app.Services.CreateScope())
            {
                var dbContext = scope.ServiceProvider
                    .GetRequiredService<IToDoListDbContext>();

                if (!dbContext.Database.CanConnect())
                {
                    throw new NotImplementedException("Can't connect to database.");
                }
            }


            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI(c =>
                {
                    c.SwaggerEndpoint("/swagger/v1/swagger.json", "ToDo_List API V1");
                });
            }

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
