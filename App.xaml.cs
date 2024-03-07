using FinalProjectSwd.Models;
using FinalProjectSwd.Repositorys;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace FinalProjectSwd
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        ServiceProvider provider;
        public App()
        {
            ServiceCollection services = new ServiceCollection();
            Configure(services);
            provider = services.BuildServiceProvider();
        }

        public void Configure(ServiceCollection services)
        {
            services.AddSingleton<MainWindow>();
            services.AddDbContext<CafeSystemContext>(option =>
            {
                var config = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json").Build();
                string connectionString = config.GetConnectionString("value");
                option.UseSqlServer(connectionString);
            });
            services.AddSingleton<IAreaRepository,  AreaRepository>();
            services.AddSingleton<IAttendanceDayRepository, AttendanceDayRepository>();
            services.AddSingleton<ICommodityCategoryRepository, CommodityCategoryRepository>();
            services.AddSingleton<ICommodityRepository, CommodityRepository>();
            services.AddSingleton<ICustomerRepository, CustomerRepository>();
            services.AddSingleton<IEmployeeRepository, EmployeeRepository>();
            services.AddSingleton<IOrderRepository, OrderRepository>();
            services.AddSingleton<IOrderDetailRepository, OrderDetailRepository>();
            services.AddSingleton<IPositionRepository, PositionRepository>();
            services.AddSingleton<ISigningSalaryRepository, SigningSalaryRepository>();
            services.AddSingleton<ITableRepository, TableRepository>();
            services.AddSingleton<IWorkingTimeRepository, WorkingTimeRepository>();
        }
        private void OnStartup(object sender, StartupEventArgs e)
        {
            var mainWindow = provider.GetService<MainWindow>();
            mainWindow.Show();

        }
    }
}
