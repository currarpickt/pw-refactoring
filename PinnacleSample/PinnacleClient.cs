namespace PinnacleSample
{
    public class PinnacleClient
    {
        private PartInvoiceController __Controller;

        /// <summary>
        /// Pass production implementation to PartInvoiceController constructor.
        /// </summary>
        public PinnacleClient()
        {
            DBConnection dBConnection = new DBConnection();
            AvailabilityServiceClient availabilityServiceClient = new AvailabilityServiceClient();
            __Controller = new PartInvoiceController(dBConnection, availabilityServiceClient);
        }

        public CreatePartInvoiceResult CreatePartInvoice(string stockCode, int quantity, string customerName)
        {
            return __Controller.CreatePartInvoice(stockCode, quantity, customerName);
        }
    }
}
