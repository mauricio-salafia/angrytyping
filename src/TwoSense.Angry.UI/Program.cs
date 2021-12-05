using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Extensions.DependencyInjection;
using TwoSense.Angry.Application.Services;
using TwoSense.Angry.Infrastructure.Services;

namespace TwoSense.Angry.UI
{
    static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            System.Windows.Forms.Application.SetHighDpiMode(HighDpiMode.SystemAware);
            System.Windows.Forms.Application.EnableVisualStyles();
            System.Windows.Forms.Application.SetCompatibleTextRenderingDefault(false);

            var services = new ServiceCollection();
            ConfigureServices(services);
            using (ServiceProvider serviceProvider = services.BuildServiceProvider())
            {
                var formSendEmail = serviceProvider.GetRequiredService<FrmSendEmail>();
                System.Windows.Forms.Application.Run(formSendEmail);
            }
        }

        private static void ConfigureServices(ServiceCollection services)
        {
            services.AddScoped<IAngryDetectionService, AngryDetectionService>();
            services.AddScoped<FrmSendEmail>();
        }
    }
}
