using System.ServiceModel;
using System.Threading.Tasks;

namespace WcfService
{
    [ServiceContract]
    public interface ICalculator
    {
        [OperationContract]
        Task<int> Add(int value1, int value2);
    }

    public class Calculator : ICalculator
    {
        public async Task<int> Add(int value1, int value2)
        {
            return 1;
        }
    }
}