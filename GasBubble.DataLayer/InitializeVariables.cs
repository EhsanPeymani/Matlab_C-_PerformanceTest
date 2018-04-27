using System;
using System.Collections.Generic;
using FI.DDS.Models;
using FI.Family.Metrics;

namespace GasBubble.DataLayer
{
    public class InitializeVariables
    {

        public VariableInfo ProvidedVariablesInfo { get; set; }
        public VariableInfo RequestedVariablesInfo { get; set; }
        
        public InitializeVariables()
        {
            this.ProvidedVariablesInfo = new VariableInfo();
            this.RequestedVariablesInfo = new VariableInfo();

            this.InitializeProvidedVariables();
            this.InitializeRequestedVariables();
        }

        private void InitializeProvidedVariables()
        {
            this.ProvidedVariablesInfo.VarNames = new List<string>()
            {
            "AnnularPrevValvePos",
            "ChokeLinePressure",
            "FlowLiquidChokeOut",
            "FlowGasChokeOut",
            };

            this.ProvidedVariablesInfo.Guids = new List<Guid>()
            {
            new Guid("5076E429-9F01-41ED-A3AE-6C30A4194FFB"),
            new Guid("45817CAD-E517-4E5B-AD14-5EEA8296335B"),
            new Guid("55DB341B-60F6-4054-AAC2-2BB31D5BCFE3"),
            new Guid("663C9FE8-C9D8-4EC5-9960-FA77F0BC75D7"),
            //new Guid("8D15182D-151B-4DFF-9E00-2A115C3A5E8E"),
            //new Guid("A55876A7-6F40-4A2F-98E3-8759B3BDCFC3")
            };

            this.ProvidedVariablesInfo.Types = new List<DDSValueType>()
            {
            DDSValueType.Double,
            DDSValueType.Double,
            DDSValueType.Double,
            DDSValueType.Double,
            //DDSValueType.Double,
            //DDSValueType.Double
            };

            this.ProvidedVariablesInfo.UnitGroups = new List<Group>()
            {
                Group.Unknown,
                Group.Pressure,
                Group.FlowRate,
                Group.FlowRate,
                //Group.Unknown,
                //Group.Unknown
            };
        }

        private void InitializeRequestedVariables()
        {
            this.RequestedVariablesInfo.VarNames = new List<string>()
            {
                "FlowrateBit"
            };

            this.RequestedVariablesInfo.Guids = new List<Guid>()
            {
                new Guid("F7EE4A8B-9302-45BA-98A9-DCCDEED70BE8")
            };

            this.RequestedVariablesInfo.Types = new List<DDSValueType>()
            {
                DDSValueType.Double
            };

            this.RequestedVariablesInfo.UnitGroups = new List<Group>()
            {
                Group.FlowRate
            };
        }
    }
}
