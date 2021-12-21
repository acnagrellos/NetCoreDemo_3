namespace Customers.Services.Services
{
    public interface ICustomerLogService
    {
        void AddCustomerLog(int customerId);
        int GetCustomerAccessLog(int customerId);
    }
}
