namespace PinnacleSample
{
    /// <summary>
    /// Extracted PartInvoiceController's dependency to CustomerRepositoryDB, PartAvailabilityServiceClient, and PartInvoiceRepositoryDB.
    /// Now we can do dependency injection through the constructor.
    /// PartInvoiceController no longer care about any concrete implementation,
    /// so we can create a fake implementation for testing.
    /// </summary>
    public class PartInvoiceController
    {
        private IPersistanceConnection Connection;
        private IPartAvailabilityServiceClient ServiceClient;

        /// <summary>
        /// Add dependency injection through the constructor
        /// </summary>
        /// <param name="connection">database connection</param>
        /// <param name="serviceClient">service client</param>
        public PartInvoiceController(IPersistanceConnection connection, IPartAvailabilityServiceClient serviceClient)
        {
            this.Connection = connection;
            this.ServiceClient = serviceClient;
        }

        public CreatePartInvoiceResult CreatePartInvoice(string stockCode, int quantity, string customerName)
        {
            if (string.IsNullOrEmpty(stockCode))
            {
                return new CreatePartInvoiceResult(false);
            }

            if (quantity <= 0)
            {
                return new CreatePartInvoiceResult(false);
            }

            Customer _Customer = Connection.GetCustomer(customerName);

            if (_Customer.ID <= 0)
            {
                return new CreatePartInvoiceResult(false);
            }
            
            int _Availability = ServiceClient.GetAvailability(stockCode);
            if (_Availability <= 0)
            {
                return new CreatePartInvoiceResult(false);
            }

            PartInvoice _PartInvoice = new PartInvoice
            {
                StockCode = stockCode,
                Quantity = quantity,
                CustomerID = _Customer.ID
            };

            Connection.AddPartInvoice(_PartInvoice);

            return new CreatePartInvoiceResult(true);
        }
    }
}
