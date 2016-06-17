using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace WcfClient
{
    public class SoapClient
    {
        readonly string baseUrl;

        public SoapClient(string baseUrl)
        {
            this.baseUrl = baseUrl;
        }

        public TResult Execute<TServiceContract, TResult>(Func<TServiceContract, TResult> serviceContract)
            where TServiceContract : class
        {
            var address = new EndpointAddress(baseUrl);
            TResult result;
            using (var factory = new ChannelFactory<TServiceContract>(new BasicHttpBinding(), address))
            {
                var channel = factory.CreateChannel();
                result = serviceContract(channel);
            }
            return result;
        }
    }

}
