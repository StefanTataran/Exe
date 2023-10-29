using Images.Interfaces;
using Images.Services;
using Images.ViewModels;
using Images.ViewModels.AppBaseViewModels;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Essentials;

namespace Images.ConfigurationServices
{
    public static class Startup
    {
        public static IServiceProvider ServiceProvider { get; set; }

        public static void Init()
        {
            var host = new HostBuilder().ConfigureHostConfiguration(c=>
            {
                c.AddCommandLine(new string[] { $"ContentRoot={FileSystem.AppDataDirectory}" });
            })
                .ConfigureServices((x) =>
            {
                ConfigureServices(x);
            }).Build();

            ServiceProvider = host.Services;
        }

        static void ConfigureServices(IServiceCollection services)
        {
            #region ViewModel
            services.AddSingleton<AppBaseViewModel>();
            services.AddSingleton<MainPageViewModel>();
            #endregion ViewModel

            #region Services
            services.AddSingleton<IHttpClientService, HttpClientService>();
            services.AddSingleton<ILoadImagesService, LoadImagesService>();
            #endregion Services

            services.AddHttpClient<IHttpClientService, HttpClientService>();
        }
    }
}
