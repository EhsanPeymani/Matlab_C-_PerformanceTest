using System.Collections.Generic;
using FI.DDS.Client.Controllers;
using GasBubble.DataLayer;

namespace GasBubble.BusinessLayer
{
    public class Client : IDdsClient
    {
        public readonly string ClientName;
        public readonly string ServerName;
        public BaseDdsModel Schemes { get; set; }
        public ClientOutputSchemeController ProviderController { get; set; }
        public ClientInputSchemeController RequesterController { get; set; }

        public Client(string serverName, string clientName)
        {
            ClientName = clientName;
            ServerName = serverName;
        }

        public void Connect()
        {
            var initVariables = new InitializeVariables();
            var providedVariables = new BaseDdsVariables(initVariables.ProvidedVariablesInfo);
            var requestedVariables = new BaseDdsVariables(initVariables.RequestedVariablesInfo);

            var schemes = new BaseDdsModel(this.ClientName);
            schemes.AddVariables(providedVariables, requestedVariables);

            var client = new DdsClient(this.ServerName, schemes);

            this.Schemes = client.Schemes;
            this.ProviderController = client.ProviderController;
            this.RequesterController = client.RequesterController;
        }

        public void UpdateProvidedVariables(List<double> modelOutput)
        {
            this.Schemes.UpdateProvidedVariables(modelOutput);
        }

    }
}
