using Images.ConfigurationServices;
using Images.Interfaces;
using Images.Models;
using Images.ViewModels.AppBaseViewModels;
using Microsoft.Extensions.DependencyInjection;
using MvvmHelpers;
using MvvmHelpers.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;
using Command = MvvmHelpers.Commands.Command;

namespace Images.ViewModels
{
    public class MainPageViewModel : AppBaseViewModel
    {
        #region Services
        private ILoadImagesService LoadImagesService => Startup.ServiceProvider.GetService<ILoadImagesService>();
        #endregion Services
        #region PropertyDeclaration
        private bool welcomeMessage = false;
        private int currentPage = 1;
        private const int limit = 30;
        private ObservableRangeCollection<ImageModel> images = new ObservableRangeCollection<ImageModel>();
        #endregion PropertyDeclaration

        #region ProperyAccessor
        public double ImageWidth
        {
            get { 
                if(DeviceInfo.Idiom == DeviceIdiom.Phone)
                {
                    return Application.Current.MainPage.Width > Application.Current.MainPage.Height ? 1.5 * Application.Current.MainPage.Height : Application.Current.MainPage.Width;
                }
                return Application.Current.MainPage!=null?Application.Current.MainPage.Width > Application.Current.MainPage.Height ? 1.5 * Application.Current.MainPage.Height : Application.Current.MainPage.Width:0;
            }
        }
        public double ImageHeight
        {
            get {
                if (DeviceInfo.Idiom == DeviceIdiom.Phone)
                {
                    return Application.Current.MainPage.Width > Application.Current.MainPage.Height ? 0.8 * Application.Current.MainPage.Height : Application.Current.MainPage.Width / 1.5;
                }
                return Application.Current.MainPage != null ? Application.Current.MainPage.Width > Application.Current.MainPage.Height ? 0.8 * Application.Current.MainPage.Height : Application.Current.MainPage.Width / 1.5 : 0;
            }
        }
        public bool WelcomeMessage
        {
            get => welcomeMessage;
            set => SetProperty(ref welcomeMessage, value);
        }
        public ObservableRangeCollection<ImageModel> Images
        {
            get => images;
            set => SetProperty(ref images, value);
        }
        #endregion ProperyAccessor

        #region Commands
        public ICommand OnAppearingCommand => new AsyncCommand(OnAppearing);
        public ICommand OnLayoutChangedCommand => new Command(() =>
        {
        });
        #endregion Commands

        #region Constructor
        #endregion Constructor

        #region Methods
        private async Task OnAppearing()
        {
            if (!IsInternetAvailable || isActionRunning)
                return;
            isActionRunning = true;
            try
            {
                Images = await LoadImagesService.LoadImages();
            }
            catch (Exception ex)
            {
                //log exception
                Console.WriteLine(ex.Message);
            }
            finally { isActionRunning = false;}
        }

        public async Task LoadNextImages()
        {

            if (!IsInternetAvailable || isActionRunning)
                return;
            isActionRunning = true;
            try
            {
                currentPage++;
                var newImages = await LoadImagesService.LoadImages(currentPage,limit);
                Images.AddRange(newImages);
            }
            catch (Exception ex)
            {
                //log exception
                Console.WriteLine(ex.Message);
            }
            finally
            {
                isActionRunning = false;
            }
        }
        #endregion Methods
    }
}
