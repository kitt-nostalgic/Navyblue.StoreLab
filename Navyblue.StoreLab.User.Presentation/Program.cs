using System.Reflection;
using MediatR;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.EntityFrameworkCore;
using Navyblue.StoreLab.User.Application.Commands.UserRegister;
using Navyblue.StoreLab.User.Domain;
using Navyblue.StoreLab.User.Domain.Events;
using Navyblue.StoreLab.User.Infrastructure;
using Serilog;

namespace Navyblue.StoreLab.User.Presentation
{
    public class Program
    {
        public static void Main(string[] args)
        {
            WebApplicationBuilder builder = WebApplication.CreateBuilder(args);


            //// Build a customized MVC implementation, without using the default AddMvc(), instead use AddMvcCore().
            //// https://github.com/aspnet/Mvc/blob/dev/src/Microsoft.AspNetCore.Mvc/MvcServiceCollectionExtensions.cs

            //builder.Services
            //    .AddMvcCore(options =>
            //    {
            //        options.RequireHttpsPermanent = true; // does not affect api requests
            //        options.RespectBrowserAcceptHeader = true; // false by default
            //        //options.OutputFormatters.RemoveType<HttpNoContentOutputFormatter>();

            //        //remove these two below, but added so you know where to place them...
            //        options.OutputFormatters.Add(new YourCustomOutputFormatter());
            //        options.InputFormatters.Add(new YourCustomInputFormatter());
            //    })
            //    //.AddApiExplorer()
            //    //.AddAuthorization()
            //    .AddFormatterMappings()
            //    //.AddCacheTagHelper()
            //    //.AddDataAnnotations()
            //    //.AddCors()
            //    .AddJsonFormatters(); // JSON, or you can build your own custom one (above)


            // Add services to the container.

            builder.Services.AddControllers(options =>
            {
                options.OutputFormatters.RemoveType<TextOutputFormatter>();
                options.OutputFormatters.RemoveType<HttpNoContentOutputFormatter>();
                //options.InputFormatters.Insert(0, new VcardInputFormatter());
                //options.OutputFormatters.Insert(0, new VcardOutputFormatter());
            });
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddAutoMapper(typeof(UserProfile));
            builder.Services.AddMediatR(msc => msc.RegisterServicesFromAssembly(typeof(Program).GetTypeInfo().Assembly));
            builder.Services.AddTransient(typeof(IRequestHandler<UserRegisterCommand, int>), typeof(UserRegisterCommandHandler));
            builder.Services.AddTransient(typeof(IRepository<>), typeof(Repository<>));
            builder.Services.AddTransient<IEventBus, EventBus>();

            // configure strongly typed settings object
            builder.Services.Configure<AppSettings>(builder.Configuration.GetSection("AppSettings"));
            // configure DI for application services
            builder.Services.AddScoped<IUserService, UserService>();

            builder.Services.AddDbContext<StoreLabDbContext>(options => options.UseSqlServer("Server=localhost;uid=sa;password=Aa123456;database=bbs;TrustServerCertificate=true"));
            builder.Services.AddScoped<IDbContext, StoreLabDbContext>();

            Log.Logger = new LoggerConfiguration().
                ReadFrom.Configuration(builder.Configuration)
                .Enrich.FromLogContext()
                .CreateLogger();

            builder.Host.UseSerilog(Log.Logger);

            WebApplication app = builder.Build();


            app.UseSerilogRequestLogging();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();

            // global cors policy
            app.UseCors(x => x
                .AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader());

            // custom jwt auth middleware
            app.UseMiddleware<JwtMiddleware>();

            app.MapControllers();

            app.Run();
        }
    }
}