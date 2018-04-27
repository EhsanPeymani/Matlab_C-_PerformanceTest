using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FI.DDS.Client.Controllers;

namespace GasBubble.DataLayer
{
    public class DdsClient : IDdsClient
    {
        public BaseDdsModel Schemes { get; set; }
        public ClientOutputSchemeController ProviderController { get; set; }
        public ClientInputSchemeController RequesterController { get; set; }

        public DdsClient(string serverName, BaseDdsModel schemes)
        {
            this.Schemes = schemes;
            this.ProviderController = new ClientOutputSchemeController(schemes.ProviderScheme);
            this.RequesterController = new ClientInputSchemeController(schemes.RequesterScheme);

            var serverUrl = "http://" + serverName + "/DDSServer";

            this.ProviderController.Connect(serverUrl);
            this.RequesterController.Connect(serverUrl);
        }
    }
}
