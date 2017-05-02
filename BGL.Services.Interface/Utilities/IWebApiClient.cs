using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace BGL.Services.Interface.Utilities
{
    public interface IWebApiClient
    {
        Task<T> GetAsync<T>(string url);
    }
}
