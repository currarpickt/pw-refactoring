namespace PinnacleSample
{
    /// <summary>
    /// Different IPersistanceConnection implementations
    /// can be used in production code and unit test code.
    /// </summary>
    public interface IPersistanceConnection
    {
        Customer GetCustomer(string customerName);
        void AddPartInvoice(PartInvoice partInvoice);
    }
}
