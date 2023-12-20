namespace TechnicalMaintenanceMiddleware_Sample.Configurations
{
    /// <summary>
    /// Configuration for technical work (IOptions pattern)
    /// </summary>
    public class TechnicalWorkConfiguration
    {
        // Represents whether technical work is currently in progress
        public bool IsTechnicalWorkInProgress { get; set; }
    }
}