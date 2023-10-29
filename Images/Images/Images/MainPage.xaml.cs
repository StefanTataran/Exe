using Images.ConfigurationServices;
using Images.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Images
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainPage : ContentPage
    {
        private MainPageViewModel MainPageVM => Startup.ServiceProvider.GetService<MainPageViewModel>();
        public MainPage()
        {
            InitializeComponent();
            BindingContext = MainPageVM;
        }

        private async void ScrollImages_ItemAppearing(object sender, ItemVisibilityEventArgs e)
        {
            //var listView = sender as ListView;
            //if(listView.RowHeight != MainPageVM.ImageHeight)
            //{
            //    listView.RowHeight = (int)MainPageVM.ImageHeight;
            //}
            if(e.Item == MainPageVM.Images.Last())
            {
                await MainPageVM.LoadNextImages();
            }
        }
    }
}