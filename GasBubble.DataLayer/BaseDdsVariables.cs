using System;
using System.Collections.Generic;
using System.Linq;
using FI.DDS.Models;
using FI.Family.Metrics;

namespace GasBubble.DataLayer
{
    public class BaseDdsVariables
    {
        private readonly List<Guid> _guids;
        private readonly List<string> _varNames;
        private readonly List<DDSValueType> _types;
        private readonly List<Group> _unitGroups;

        public List<Variable> Variables;
        public BaseDdsVariables(List<string> varNames, List<Guid> guids, List<DDSValueType> types, List<Group> unitGroups)
        {
            _varNames = varNames;
            _guids = guids;
            _types = types;
            _unitGroups = unitGroups;

            this.Variables = new List<Variable>();

            this.CreateVariables();
            this.SetMetrics();
        }

        public BaseDdsVariables(VariableInfo varInfo)
        {
            _varNames = varInfo.VarNames;
            _guids = varInfo.Guids;
            _types = varInfo.Types;
            _unitGroups = varInfo.UnitGroups;

            this.Variables = new List<Variable>();
            
            this.CreateVariables();
            this.SetMetrics();
        }

        // creating a list of DDS variables
        private void CreateVariables()
        {
            if (this.CheckConsistency())
            {
                for (int i = 0; i < this._guids.Count; i++)
                {
                    var variable = new Variable(this._varNames[i], this._guids[i], this._types[i]);
                    this.Variables.Add(variable);
                }
            }
            
        }

        // make sure all fields are of the same length
        private bool CheckConsistency()
        {
            var guidLength = this._guids.Count;
            var variableLength = this._varNames.Count;
            var typeLength = this._varNames.Count;
            var unitLength = this._unitGroups.Count;

            if (new[] {typeLength, variableLength, unitLength}.All(x => x==guidLength))
            {
                return true;
            }

            return false;
        }

        private void SetMetrics()
        {
            var index = 0;
            foreach (var variable in this.Variables)
            {
                variable.Metric.SetValue(GroupInfo.GetSiMetric(this._unitGroups[index++]).ID);
            }
        }
    }
}



