namespace PinnacleSample
{
    /// <summary>
    /// Extracted from PartInvoiceController,
    /// so that CustomerRepositoryDB and PartInvoiceRepositoryDB is no longer
    /// a dependency of PartInvoiceController.
    /// </summary>
    public class DBConnection : IPersistanceConnection
    {
        public Customer GetCustomer(string customerName)
        {
            CustomerRepositoryDB _CustomerRepository = new CustomerRepositoryDB();
            Customer _Customer = _CustomerRepository.GetByName(customerName);
            return _Customer;
        }

        public void AddPartInvoice(PartInvoice partInvoice)
        {
            PartInvoiceRepositoryDB _PartInvoiceRepository = new PartInvoiceRepositoryDB();
            _PartInvoiceRepository.Add(partInvoice);
        }
    }
}
