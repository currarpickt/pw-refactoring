namespace PinnacleSample
{
    /// <summary>
    /// Different IPartAvailabilityServiceClient implementations
    /// can be used in production code and unit test code.
    /// </summary>
    public interface IPartAvailabilityServiceClient
    {
        int GetAvailability(string stockCode);
    }
}
