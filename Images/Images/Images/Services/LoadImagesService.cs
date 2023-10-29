using Images.AppEnvironmnets;
using Images.ConfigurationServices;
using Images.Interfaces;
using Images.Models;
using Microsoft.Extensions.DependencyInjection;
using MvvmHelpers;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Images.Services
{
    public class LoadImagesService : ILoadImagesService
    {
        IHttpClientService HttpService => Startup.ServiceProvider.GetService<IHttpClientService>();
        public async Task<ObservableRangeCollection<ImageModel>> LoadImages(int? page = null, int? limit = null)
        {
            string responseJson;

            try
            {
                string uri = AppEnvironmnet.GetImagesListAPI;
                if(page!=null && limit!=null) 
                {
                    uri = uri + $"?page={page}&limit={limit}";
                }
                Uri requestUri = new Uri(uri);
                responseJson = await HttpService.GetDataAsync(requestUri);
            }
            catch (Exception ex)
            {
                return new ObservableRangeCollection<ImageModel>();
            }
            return JsonConvert.DeserializeObject<ObservableRangeCollection<ImageModel>>(responseJson);
        }
    }
}
