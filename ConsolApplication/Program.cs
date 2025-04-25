using Microsoft.Extensions.DependencyInjection;
namespace ConsolApplication
{
    interface IDatabase
    {
        void SaveOrder();
    }
    interface ILogger
    {
        public void Log(string message);
    }
    class Logger:ILogger
    {
        public void Log(string message)
        {
            Console.WriteLine(message);
        }
    }
    class PostDatabase:IDatabase
    {
        
        public void SaveOrder()
        {
            Console.WriteLine("Database: Processing order...");
        }
    }
    class OrderService
    {

        private readonly ILogger _logger;
        private readonly IDatabase _database;
        public OrderService(ILogger logger, IDatabase database)
        {
            _logger = logger;
            _database = database;
        }
        public void ProcessOrder()
        {
            _logger.Log("message");
            _database.SaveOrder();
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            IServiceCollection services = new ServiceCollection();
            services.AddSingleton<IDatabase, PostDatabase>();
            services.AddSingleton<ILogger, Logger>();           
            services.AddSingleton<OrderService>();
            IServiceProvider serviceProvider = services.BuildServiceProvider();
            OrderService orderService = serviceProvider.GetRequiredService<OrderService>();
            orderService.ProcessOrder();

            //OrderService orderService = new OrderService(new Logger(),new Database());
            //orderService.ProcessOrder();

        }
    }
}
