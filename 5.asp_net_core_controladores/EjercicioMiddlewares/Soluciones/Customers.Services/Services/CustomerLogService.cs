namespace Customers.Services.Services
{
    public class CustomerLogService : ICustomerLogService
    {
        private readonly Dictionary<int, int> _customersLogDictionary;

        public CustomerLogService() 
        {
            _customersLogDictionary = new Dictionary<int, int>();
        }

        public void AddCustomerLog(int customerId)
        {
            if (_customersLogDictionary.ContainsKey(customerId)) 
            {
                _customersLogDictionary[customerId] = _customersLogDictionary[customerId] + 1;
            }
            else 
            {
                _customersLogDictionary.Add(customerId, 1);
            }
        }

        public int GetCustomerAccessLog(int customerId)
        {
            if (_customersLogDictionary.ContainsKey(customerId))
            {
                return _customersLogDictionary[customerId];
            }
            else
            {
                return 0;
            }
        }
    }
}
