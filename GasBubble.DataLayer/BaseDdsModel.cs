using System;
using System.Collections.Generic;
using System.Linq;
using FI.DDS.Models;

namespace GasBubble.DataLayer
{
    public class BaseDdsModel
    {
        private readonly string _clientName;
        private readonly Dictionary<SchemeType, Guid> _guids = new Dictionary<SchemeType, Guid>();

        public Scheme ProviderScheme { get; set; }
        public Scheme RequesterScheme { get; set; }

        public BaseDdsModel(string clientName)
        {
            this._clientName = clientName;
            this._guids.Add(SchemeType.Provider, new Guid("486651F4-CAC6-446A-8D0D-131C3C934275"));
            this._guids.Add(SchemeType.Requester, new Guid("1D7E2BB4-D3A1-4C5D-B21B-1D8FC5AEDB30"));

            this.ProviderScheme = new Scheme(clientName, this._guids[SchemeType.Provider]);
            this.RequesterScheme = new Scheme(clientName, this._guids[SchemeType.Requester]);
        }

        public void SetGuids(SchemeType type, Guid guid)
        {
            this._guids[type] = guid;
        }

        public void RedefineModel()
        {
            this.ProviderScheme = new Scheme(this._clientName, this._guids[SchemeType.Provider]);
            this.RequesterScheme = new Scheme(this._clientName, this._guids[SchemeType.Requester]);
        }

        public void AddVariables(SchemeType type, BaseDdsVariables variables)
        {
            switch (type)
            {
                case SchemeType.Provider:
                    foreach (var ddsVariable in variables.Variables)
                    {
                        this.ProviderScheme.AddVariable(ddsVariable);
                    }
                    break;
                case SchemeType.Requester:
                    foreach (var ddsVariable in variables.Variables)
                    {
                        this.RequesterScheme.AddVariable(ddsVariable);
                    }
                    break;
            }
        }

        public void AddVariables(BaseDdsVariables providedVariables, BaseDdsVariables requesterVariables)
        {
            this.AddVariables(SchemeType.Provider, providedVariables);
            this.AddVariables(SchemeType.Requester, requesterVariables);
        }

        public void UpdateProvidedVariables(List<double> variables)
        {
            for (int i = 0; i < variables.Count; i++)
            {
                this.ProviderScheme.GetVariable(i).Value = (double)variables[i];
            }
        }
    }
}
