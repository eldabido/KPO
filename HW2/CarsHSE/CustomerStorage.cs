namespace CarShowroom
{
    public class CustomerStorage : ICustomersProvider
    {
        private List<Customer> _customers = new List<Customer>();

        public void AddCustomer(Customer customer)
        {
            _customers.Add(customer);
        }

        public List<Customer> GetCustomers()
        {
            return _customers;
        }
    }
}
