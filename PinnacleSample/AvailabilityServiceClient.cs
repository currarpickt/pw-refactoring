namespace PinnacleSample
{
    /// <summary>
    /// Extracted from PartInvoiceController,
    /// so that PartAvailabilityServiceClient is no longer
    /// a dependency of PartInvoiceController.
    /// </summary>
    public class AvailabilityServiceClient : IPartAvailabilityServiceClient
    {
        public int GetAvailability(string stockCode)
        {
            using (PartAvailabilityServiceClient _PartAvailabilityService = new PartAvailabilityServiceClient())
            {
                int _Availability = _PartAvailabilityService.GetAvailability(stockCode);
                return _Availability;
            }
        }
    }
}
