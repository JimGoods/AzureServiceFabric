using System.ServiceModel;
using System.Threading.Tasks;

namespace WcfService
{
    [ServiceContract]
    public interface ICalculator
    {
        [OperationContract]
        int Add(int value1, int value2);

        [OperationContract]
        Task<int> AddAsync(int value1, int value2);
    }

    public class Calculator : ICalculator
    {
        public int Add(int value1, int value2)
        {
            return value1 + value2;
        }

        public async Task<int> AddAsync(int value1, int value2)
        {
            return value1 + value2;
        }
    }
}