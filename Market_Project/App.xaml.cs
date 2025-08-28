using Market_Project.Data;
using Microsoft.Extensions.DependencyInjection;
using System.Configuration;
using System.Data;
using System.Windows;
using Microsoft.EntityFrameworkCore;
using Market_Project.Services.Interfaces;
using Market_Project.Services.Implementations;
using Market_Project.ViewModels;
using Market_Project.Views;

namespace Market_Project
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static IServiceProvider ServiceProvider { get; private set; }

        protected override void OnStartup(StartupEventArgs e)
        {

            base.OnStartup(e);
           
            var services = new ServiceCollection();
            ConfigureServices(services);

            ServiceProvider = services.BuildServiceProvider();
            var mainWindow = ServiceProvider.GetRequiredService<MainWindow>();
            mainWindow.Show();
        }

        private void ConfigureServices(IServiceCollection services)
        {
            // DbContext
            services.AddDbContext<AppDbContext>(options =>
               options.UseSqlServer("Server=DESKTOP-E1FNJ59\\SQLEXPRESS;Database=MarketDB;Trusted_Connection=True;TrustServerCertificate=True;"));

            // Services
            services.AddTransient(typeof(IGenericService<>), typeof(GenericService<>));
            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<ICategoryService, CategoryService>();
            services.AddScoped<IUnitService, UnitService>();

            // ViewModels
            services.AddTransient<ProductListViewModel>();
            services.AddTransient<CategoriesViewModel>();
            services.AddTransient<UnitsViewModel>();

            // Views
            services.AddTransient<MainWindow>();
            services.AddTransient<ProductList>();
            services.AddTransient<Categories>();
            services.AddTransient<Units>();
        }
    }

}
