using ASS2_PRN3.Models;
using ASS2_PRN3.Repositories;
using System.Text.Json.Serialization;

namespace ASS2_PRN3
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers().AddNewtonsoftJson(options =>
    options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddDbContext<ASS2Context>();
            //builder.Services.AddScoped(typeof(CommonRepository<>), typeof(PublisherRepository));
            builder.Services.AddScoped<AuthorRepository>();
            builder.Services.AddScoped<PublisherRepository>();
            builder.Services.AddScoped<BookRepository>();
            builder.Services.AddScoped(typeof(IRepository<>), typeof(CommonRepository<>));
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

            app.Run();
        }
    }
}
