using System.Reflection;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using Restoran.Models;
using Restoran.Services;
using Restoran.Services.Implementation;

namespace Restoran
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddRazorPages();

            // builder.Services.AddSingleton<IRestorauntService, RestaurantSersice>();
            // builder.Services.AddSingleton<IMenuItemServices, MenuItemServices>();

            builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory());
            builder.Host.ConfigureContainer<ContainerBuilder>(containerBilder =>
            {
                containerBilder.RegisterType<MenuItemServices>().As<IMenuItemServices>().InstancePerLifetimeScope();
                containerBilder.RegisterType<RestaurantServices>().As<IRestorauntServices>().InstancePerLifetimeScope();
                containerBilder.RegisterType<EmployeServices>().As<IEmployeesServices>().InstancePerLifetimeScope();
                // Assembly assembly = typeof(Program).Assembly;                
                // containerBilder.RegisterAssemblyTypes(assembly)
                //                    .Where(t => t.Name.EndsWith("Services"))
                //                    .AsImplementedInterfaces()
                //                    .InstancePerLifetimeScope();

            }
            );

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapRazorPages();

            app.Run();
        }
    }
}
