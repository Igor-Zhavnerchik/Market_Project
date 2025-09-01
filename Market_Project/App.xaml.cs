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
            // User Context
            services.AddSingleton<IActiveUserContext, ActiveUserContext>();

            // DbContext
            services.AddDbContext<AppDbContext>(options =>
               options.UseSqlServer("Server=DESKTOP-E1FNJ59\\SQLEXPRESS;Database=MarketDB;Trusted_Connection=True;TrustServerCertificate=True;"));

            // Services
            services.AddTransient(typeof(IGenericService<>), typeof(GenericService<>));
            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<ICategoryService, CategoryService>();
            services.AddScoped<IUnitService, UnitService>();

            // ViewModels
            services.AddSingleton<ProductListViewModel>();
            services.AddSingleton<CategoriesViewModel>();
            services.AddSingleton<UnitsViewModel>();

            // Views
            services.AddTransient<MainWindow>();
            services.AddTransient<ProductList>();
            services.AddTransient<Categories>();
            services.AddTransient<Units>();

            // Add Forms
            services.AddTransient<CategoryAddForm>();
            services.AddTransient<ProductAddForm>();
            services.AddTransient<UnitAddForm>();
        }
    }

}
