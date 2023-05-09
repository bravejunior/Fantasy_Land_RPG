using Fantasy_Land_Web_Api.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiClient.Interfaces
{
    public interface ICustomHttpClient
    {
        Task<HttpResponseMessage> GetAsync(string requestUri);
    }
}
