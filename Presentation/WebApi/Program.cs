
using Application.Interfaces;
using Application.MappersProfiles;
using AutoMapper;
using CarBook.Application.Servicess;
using Persistence.Context;
using Persistence.Repositories;

namespace WebApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddScoped<LibraryContext>();
            builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));



            builder.Services.AddSaveApplicationService(builder.Configuration);

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();


            //builder.Services.AddAutoMapper(typeof(MapperProfile).Assembly);
            //builder.Services.AddAutoMapper(typeof(Application.MappersProfiles.MapperProfile).Assembly);
            var mapperConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new Application.MappersProfiles.MapperProfile());
            });

            IMapper mapper = mapperConfig.CreateMapper();
            builder.Services.AddSingleton(mapper);


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
