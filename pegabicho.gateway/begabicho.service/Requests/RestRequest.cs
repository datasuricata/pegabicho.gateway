using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace begabicho.service.Requests
{
    public class RestRequest
    {
        private string baseUrl;

        public RestRequest(string baseUrl)
        {
            this.baseUrl = baseUrl;
        }

        #region [ Task Async ]

        public async Task<T> Get<T>(string uri, string token = "")
        {
            var request = new DataRequest<T>(baseUrl);
            var result = await request.Get(uri, token);

            return result;
        }

        public async Task<T> GetById<T>(string uri, string id, string token = "")
        {
            var request = new DataRequest<T>(baseUrl);
            var result = await request.GetById(uri, id, token);

            return result;
        }

        public async Task<T> Post<T>(string uri, object command, string token = "")
        {
            var request = new DataRequest<T>(baseUrl);
            var result = await request.Post(uri, command, token);

            return result;
        }

        public async Task<T> Put<T>(string uri, object command, string token = "")
        {
            var request = new DataRequest<T>(baseUrl);
            var result = await request.Put(uri, command, token);

            return result;
        }

        public async Task PostAnonymous<T>(string uri, object command, string token = "")
        {
            var request = new DataRequest<T>(baseUrl);
            await request.PostAnonymous(uri, command);

        }

        public async Task<T> GetEnderecoByCep<T>(string uri, string cep, string token = "")
        {
            var request = new DataRequest<T>(baseUrl);
            var result = await request.GetEnderecoByCep(uri, cep, token);

            return result;
        }

        #endregion
    }
}
