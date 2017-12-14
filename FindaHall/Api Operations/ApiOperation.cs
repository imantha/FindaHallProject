using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;

namespace FindaHall.Api_Operations
{
    public partial class ApiOperation
    {
        private HttpClient httpClient;

        public ApiOperation(string url)
        {

            httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri(url); //new Uri("http://localhost:49558");
            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            httpClient.MaxResponseContentBufferSize = 2147483647;
        }


    }
}
