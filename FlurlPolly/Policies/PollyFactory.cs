using Flurl.Http.Configuration;
using Polly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace FlurlPolly.Policies
{
    public class PollyFactory : DefaultHttpClientFactory
    {
        private readonly IAsyncPolicy<HttpResponseMessage> _policy;

        public PollyFactory(IAsyncPolicy<HttpResponseMessage> policy)
        {
            _policy = policy;
        }

        public override HttpMessageHandler CreateMessageHandler()
        {
            return new PollyHandler(_policy)
            {
                InnerHandler = base.CreateMessageHandler()
            };
        }
    }
}
