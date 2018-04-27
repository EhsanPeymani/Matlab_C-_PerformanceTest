using FI.DDS.Client.Controllers;

namespace GasBubble.DataLayer
{
    public interface IDdsClient
    {
        BaseDdsModel Schemes { get; set; }
        ClientOutputSchemeController ProviderController { get; set; }
        ClientInputSchemeController RequesterController { get; set; }
    }
}