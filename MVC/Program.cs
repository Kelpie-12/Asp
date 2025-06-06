using System.Reflection;
using Autofac;
using Autofac.Extensions.DependencyInjection;

namespace MVC
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddControllersWithViews();
            builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory());
            builder.Host.ConfigureContainer<ContainerBuilder>(cont =>
            {
                Assembly assembly = typeof(Program).Assembly;
                cont.RegisterAssemblyTypes(assembly)
                                    .Where(t => t.Name.EndsWith("Services"))
                                    .AsImplementedInterfaces()
                                    .SingleInstance();
            });

            var app = builder.Build();
            app.UseStaticFiles();
            app.MapControllers();
            //app.MapControllerRoute("default", "{controller=Home}/{action=Index}/{id?}");
            //app.MapControllerRoute("calc", "{controller=Calc}/{action=Index}/{id?}");
            //app.MapControllerRoute("review", "{controller=Review}/{action=Index}/{id?}");
            //app.MapGet("/", () => "Hello World!");

            app.Run();
        }
    }
}
