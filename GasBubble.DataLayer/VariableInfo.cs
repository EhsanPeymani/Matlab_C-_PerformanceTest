using System;
using System.Collections.Generic;
using FI.DDS.Models;
using FI.Family.Metrics;

namespace GasBubble.DataLayer
{
    public class VariableInfo
    {
        public List<Guid> Guids;
        public List<string> VarNames;
        public List<DDSValueType> Types;
        public List<Group> UnitGroups;

        public VariableInfo()
        {
            this.Guids = new List<Guid>();
            this.VarNames = new List<string>();
            this.Types = new List<DDSValueType>();
            this.UnitGroups = new List<Group>();
        }
    }
}
