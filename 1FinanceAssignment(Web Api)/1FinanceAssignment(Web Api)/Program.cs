using _1FinanceAssignment_Web_Api_.Configurations;
using _1FinanceAssignment_Web_Api_.ContextLayered;
using _1FinanceAssignment_Web_Api_.Repository;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;

namespace _1FinanceAssignment_Web_Api_
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            string? conn = builder.Configuration.GetConnectionString("AppConn");
            builder.Services.AddDbContext<ProductDbContext>(o => o.UseSqlServer(conn));
            builder.Services.AddScoped<IProductRepository, ProductRepository>();
            builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddAutoMapper(typeof(MapConfig));

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