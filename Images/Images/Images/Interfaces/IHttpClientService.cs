using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Images.Interfaces
{
    public interface IHttpClientService
    {
        Task<string> GetDataAsync(Uri uri);
    }
}
