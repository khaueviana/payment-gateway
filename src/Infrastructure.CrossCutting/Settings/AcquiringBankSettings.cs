namespace Infrastructure.CrossCutting.Settings
{
    using Infrastructure.CrossCutting.Interfaces;

    public class AcquiringBankSettings : IAcquiringBankSettings
    {
        public string BaseUrl { get; set; }
    }
}
