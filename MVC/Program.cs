using System.Reflection;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using MVC.Data;
using MVC.Services;
using MVC.Services.Implementation;


namespace MVC
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddControllersWithViews();

            builder.Services.AddAuth(builder.Configuration);   

            builder.Services.AddScoped<IUserServices, UserService>();
            builder.Services.AddDbContext<ApplicationDbContext>(options =>
            {
                options.UseSqlServer(builder.Configuration.GetConnectionString("Test"));
            });
            builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory());
            builder.Host.ConfigureContainer<ContainerBuilder>(cont =>
            {
                Assembly assembly = typeof(Program).Assembly;
                cont.RegisterAssemblyTypes(assembly)
                                    .Where(t => t.Name.EndsWith("Services"))
                                    .AsImplementedInterfaces()
                                    .SingleInstance();
            });
            //builder.Host.ConfigureContainer<ContainerBuilder>(cont =>
            //{
            //    Assembly assembly = typeof(Program).Assembly;
            //    cont.RegisterAssemblyTypes(assembly)
            //                        .Where(t => t.Name.EndsWith("Repository"))
            //                        .AsImplementedInterfaces()
            //                        .SingleInstance();
            //});           
            var app = builder.Build();
            app.UseStaticFiles();
            app.MapControllers();

            app.UseAuthentication();
            app.UseAuthorization();

            app.Run();
        }
    }
}
