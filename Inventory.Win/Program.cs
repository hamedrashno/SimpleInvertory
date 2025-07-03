using Inventory.Application.Db;
using Inventory.Application.Services;
using Inventory.Win.Forms.Product;
using Microsoft.Extensions.DependencyInjection;

namespace Inventory.Win
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {

            ApplicationConfiguration.Initialize();
            var services = new ServiceCollection();
            ConfigureServices(services);
            using (var serviceProvider = services.BuildServiceProvider())
            {
                var loginForm = serviceProvider.GetRequiredService<MainForm>();
                System.Windows.Forms.Application.Run(loginForm);
            }
        }


        private static void ConfigureServices(IServiceCollection services)
        {
            // Register your services
            services.AddScoped<ProductService>();
            services.AddScoped<UnitService>();
            services.AddScoped<CategoryService>();
            services.AddScoped<UserService>();
            services.AddScoped<InvoiceService>();
            services.AddScoped<StockTransactionService>();
            services.AddScoped<TransactionTypeService>();
            services.AddScoped<UserService>();
            services.AddScoped<WarehouseService>();

            services.AddDbContext<AppDbContext>();
            // Register your forms
            services.AddScoped<MainForm>();
            services.AddScoped<ProductListForm>();
        }
    }
}