
using Microsoft.Extensions.DependencyInjection;

namespace ConsolApplicationHW
{
    internal class Program
    {
        static void Main(string[] args)
        {
            IServiceCollection services = new ServiceCollection();
            services.AddSingleton<ILogger, ConsoleLogger>();
            services.AddSingleton<IMusic, Classical>();
            services.AddSingleton<MusicPlayer>();
            /*var*/ IServiceProvider servicesProvider = services.BuildServiceProvider();
            servicesProvider.GetRequiredService<MusicPlayer>().PlayMusic();
        }
    }
}
