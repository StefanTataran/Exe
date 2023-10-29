using MvvmHelpers;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Essentials;

namespace Images.ViewModels.AppBaseViewModels
{
    public class AppBaseViewModel : BaseViewModel
    {
        #region PropertyDeclaration
        private bool isInternetAvailable;
        protected bool isActionRunning = false;
        #endregion PropertyDeclaration

        #region PropertyAccessor
        public bool IsInternetAvailable
        {
            get => isInternetAvailable;
            set => isInternetAvailable = value;
        }
        #endregion PropertyAccessor
        #region Constructor
        public AppBaseViewModel()
        {
            Connectivity.ConnectivityChanged += Connectivity_Changed;
            if(Connectivity.NetworkAccess != NetworkAccess.Internet)
                IsInternetAvailable = false;
            else
                IsInternetAvailable= true;
        }
        ~AppBaseViewModel()
        {
            Connectivity.ConnectivityChanged += Connectivity_Changed;
        }
        #endregion Constructor

        #region Methods
        private void Connectivity_Changed(object sender, ConnectivityChangedEventArgs e)
        {
            if(e.NetworkAccess != NetworkAccess.Internet)
                IsInternetAvailable = false;
            else
                IsInternetAvailable = true;
        }
        #endregion Methods
    }
}
