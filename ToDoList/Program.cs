using Microsoft.EntityFrameworkCore;
using Project.EFCore.Infrastructure;
using System.Reflection;
using ToDoList.Application.Context;
using ToDoList.Application.Services;

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
            builder.Services.AddSwaggerGen(options =>
            {
                //Add Xml comments to swagger JSON Schema
                var xmlFileName = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFileName));
            });

            //Add IToDoTaskService to DI system
            builder.Services.AddScoped<IToDoTaskService, ToDoTaskService>();

            if (builder.Environment.IsDevelopment())
            {
                builder.Services.AddDbContext<IToDoListDbContext, ToDoListDbContext>(options =>
                {
                    options.UseSqlServer(builder.Configuration.GetConnectionString("ToDoListDbDev"));
                });
            }

            var app = builder.Build();

            //Creates the dbContext scope
            using (var scope = app.Services.CreateScope())
            {
                //Gets the dbContext service to check if the connection was successful
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
