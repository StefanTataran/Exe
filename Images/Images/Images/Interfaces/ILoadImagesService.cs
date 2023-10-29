using Images.Models;
using MvvmHelpers;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Images.Interfaces
{
    public interface ILoadImagesService
    {
        Task<ObservableRangeCollection<ImageModel>> LoadImages(int? page=null, int? limit = null);
    }
}
