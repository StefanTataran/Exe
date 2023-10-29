using Images.AppEnvironmnets;
using Images.ConfigurationServices;
using Images.ViewModels;
using System;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Images
{
    public partial class App : Application
    {
        #region ServiceInstances
        private MainPageViewModel MainPageVM => Startup.ServiceProvider.GetService<MainPageViewModel>();
        #endregion ServiceInstances

        public App()
        {
            Startup.Init();

            if (VersionTracking.IsFirstLaunchEver)
            {
                MainPageVM.WelcomeMessage = true;
            }
            InitializeComponent();

            MainPage = new MainPage();

        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
