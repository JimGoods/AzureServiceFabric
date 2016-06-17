using System;
using System.ServiceModel;
using System.Threading.Tasks;

namespace WcfClient
{
    class Program
    {
        static void Main(string[] args)
        {
            do
            {
                TryCallService("http://localhost:8321/WcfServiceEndpoint");
                TryCallService("http://localhost:8321/WcfServiceEndpoint/Calculator");
                TryCallService("http://localhost:8321/WcfServiceEndpoint/Calculator.svc");
                TryCallService("http://localhost:8321/Calculator");
                TryCallService("http://localhost:8321/Calculator.svc");
            } while (string.IsNullOrEmpty(Console.ReadLine()));
        }

        private static void TryCallService(string baseUrl)
        {
            try
            {
                Console.WriteLine(baseUrl);
                Console.WriteLine("-----------");
                CallService(baseUrl);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            Console.WriteLine("-----------");
        }

        private static void CallService(string baseUrl)
        {
            var address = new EndpointAddress(baseUrl);
            int result;
            using (var factory = new ChannelFactory<ICalculator>(new BasicHttpBinding(), address))
            {
                var channel = factory.CreateChannel();
                //var awaiter = channel.Add(1, 1).GetAwaiter();
                //result = awaiter.GetResult();
                result = channel.Add(1, 1);
            }
            Console.WriteLine("result={0}", result);
        }
    }

    [ServiceContract]
    public interface ICalculator
    {
        [OperationContract]
        int Add(int value1, int value2);

        [OperationContract]
        Task<int> AddAsync(int value1, int value2);
    }
}
