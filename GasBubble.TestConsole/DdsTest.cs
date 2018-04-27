using System.Collections.Generic;
using GasBubble.BusinessLayer;

namespace GasBubble.TestConsole
{
    public class DdsTest
    {
        public static void CreateClient()
        {
            var client = new Client(Properties.Settings.Default.ServerName, Properties.Settings.Default.ClientName);
            client.Connect();

            var r = new List<double>() {12, 45, 56, 78};

            client.UpdateProvidedVariables(r);

        }
    }
}
