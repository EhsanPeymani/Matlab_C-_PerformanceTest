using System;
using System.Collections.Generic;
using System.Diagnostics;
using GasBubble.Common.MatlabDataTypes;
using GasBubble.Matlab.Interfaces;
using GasBubbleMatlabModel;

namespace GasBubble.BusinessLayer
{
    public class GasBubbleModel : IGasBubble
    {
        #region Properties

        public SimParam SimParam { get; set; }
        public PhysicsParam PhysicsParam { get; set; }
        public GeneratedInput GeneratedSetpoint { get; set; }
        public Fluid Fluid { get; set; }
        public Gas Gas { get; set; }
        public InterfaceObj BhInterfaceObj { get; set; }
        public InternalObj BhInternalObj { get; set; }
        public PlotObj BhPlotObj { get; set; }
        public InterfaceObj ClInterfaceObj { get; set; }
        public InternalObj ClInternalObj { get; set; }
        public PlotObj ClPlotObj { get; set; }
        public string[] ModelFlowOrder { get; set; }
        public long StepCount { get; set; }

        #endregion

        #region Fields

        private readonly object _locker = new object();
        private readonly IGasBubble _gasBubble = new GasBubbleModelIGasBubble();
        public Stopwatch StopWatch = new Stopwatch();

        #endregion

        #region Constructors

        public GasBubbleModel(int timeInit, double globalTimeStep, bool bhInUse = true, bool clInUse = true, bool bhIsFirst = true)
        {
            this.StopWatch.Start();

            var bhInUseInt = Convert.ToInt32(bhInUse);
            var clInUseInt = Convert.ToInt32(clInUse);

            this.SimParam = this.SetSimParam(timeInit, globalTimeStep);
            this.PhysicsParam = this.SetPhysicsParam();
            this.GeneratedSetpoint = this.SetSignalGeneratorParameters();
            this.Fluid = this.SetNominalMudProperties(this.PhysicsParam);
            this.Gas = this.SetNominalGasProperties(this.PhysicsParam);

            this.BhInterfaceObj = this.InitializeBhWithTaylorBubble(this.Fluid, this.Gas, this.PhysicsParam,
                this.SimParam, bhInUseInt, out var bhInternalObj, out var bhPlotObj);
            this.BhInternalObj = bhInternalObj;
            this.BhPlotObj = bhPlotObj;

            this.ClInterfaceObj = this.InitializeClWithTaylorBubble(this.Fluid, this.Gas, this.PhysicsParam,
                this.SimParam, clInUseInt, out var clInternalObj, out var clPlotObj);
            this.ClInternalObj = clInternalObj;
            this.ClPlotObj = clPlotObj;

            this.ModelFlowOrder = this.SetModelOrder(bhInUse, clInUse, bhIsFirst);

            this.StepCount = 0;

            this.StopWatch.Stop();
        }

        #endregion

        #region Methods

        public double Step(int iterationCount)
        {
            double elapsedTime;
            lock (_locker)
            {
                try
                {
                    this.StopWatch.Restart();

                    this.BhInterfaceObj = this.InputOutputMapping(this.ModelFlowOrder, this.BhInterfaceObj,
                        this.ClInterfaceObj, this.GeneratedSetpoint, iterationCount, this.SimParam.GlobalTimeStep,
                        this.PhysicsParam.PresAtmBar, this.Fluid.Density, this.PhysicsParam.ZeroLimit2,
                        out var clWithTbIfcOut);
                    this.ClInterfaceObj = clWithTbIfcOut;

                    this.BhInterfaceObj = this.ConduitWithTaylorBubbleStep(this.BhInterfaceObj,
                        this.BhInternalObj,
                        this.PhysicsParam, this.SimParam, out var bhInternalObj, out var bhPlotVariables);
                    this.BhInternalObj = bhInternalObj;
                    this.BhPlotObj = this.AugmentPlotObj(iterationCount, this.BhPlotObj, bhPlotVariables);

                    this.ClInterfaceObj = this.ConduitWithTaylorBubbleStep(this.ClInterfaceObj,
                        this.ClInternalObj,
                        this.PhysicsParam, this.SimParam, out var clInternalObj, out var clPlotVariables);
                    this.ClInternalObj = clInternalObj;
                    this.ClPlotObj = this.AugmentPlotObj(iterationCount, ClPlotObj, clPlotVariables);

                    this.StepCount++;
                }
                catch (Exception exception)
                {
                    Console.WriteLine(exception);
                    throw;
                }
                finally
                {
                    this.StopWatch.Stop();
                    elapsedTime = this.StopWatch.Elapsed.TotalMilliseconds;
                }
            }

            return elapsedTime;
        }

        public void PlotFinalResults()
        {
            try
            {
                if (this.BhInterfaceObj.InUse == 1.0)
                    this.PlotResult(1, BhPlotObj, 0, 0.25, this.SimParam.GlobalTimeStep);

                if (this.ClInterfaceObj.InUse == 1.0)
                    this.PlotResult(1, ClPlotObj, 0, 0.25, this.SimParam.GlobalTimeStep);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public List<double> ModelOutputs()
        {
            var output = new List<double>();

            lock (_locker)
            {
                output.Add(this.BhInterfaceObj.Outputs.InputOutletOpenPct);
                output.Add(this.ClInterfaceObj.Outputs.PresLiq);
                output.Add(this.ClInterfaceObj.Outputs.FlowLiqDwstLpm);
                output.Add(this.ClInterfaceObj.Outputs.FlowGasOutKgs);
            }

            return output;
        }

        public string[] SetModelOrder(bool bhInUse, bool clInUse, bool bhIsFirst)
        {
            if (bhInUse && clInUse)
            {
                if (bhIsFirst)
                    return this.SetModelOrder(this.BhInterfaceObj.ObjectName, this.ClInterfaceObj.ObjectName);
                else
                    return this.SetModelOrder(this.ClInterfaceObj.ObjectName, this.BhInterfaceObj.ObjectName);
            }
            else if (bhInUse && !clInUse)
            {
                return this.SetModelOrder(this.BhInterfaceObj.ObjectName, "");
            }
            else if (!bhInUse && clInUse)
            {
                return this.SetModelOrder(this.ClInterfaceObj.ObjectName, "");
            }
            else
            {
                // this case should not happen
                // if happens, we consider the case both are in use and borehole model is first
                return this.SetModelOrder(this.BhInterfaceObj.ObjectName, this.ClInterfaceObj.ObjectName);
            }
        }

    #endregion

        #region Matlab Methods

        public SimParam SetSimParam(int timeInit, double globalTimeStep)
        {
            return this._gasBubble.SetSimParam(timeInit, globalTimeStep);
        }

        public PhysicsParam SetPhysicsParam()
        {
            return this._gasBubble.SetPhysicsParam();
        }

        public GeneratedInput SetSignalGeneratorParameters()
        {
            return this._gasBubble.SetSignalGeneratorParameters();
        }

        public Fluid SetNominalMudProperties(PhysicsParam physicsParam)
        {
            return this._gasBubble.SetNominalMudProperties(physicsParam);
        }

        public Gas SetNominalGasProperties(PhysicsParam physicsParam)
        {
            return this._gasBubble.SetNominalGasProperties(physicsParam);
        }

        public InterfaceObj InitializeBhWithTaylorBubble(Fluid fluidNom, Gas gasNom, PhysicsParam physicsParam, SimParam simParam,
            int inUse, out InternalObj internalObj, out PlotObj plotObj)
        {
            return this._gasBubble.InitializeBhWithTaylorBubble(fluidNom, gasNom, physicsParam, simParam, inUse,
                out internalObj, out plotObj);
        }

        public InterfaceObj InitializeClWithTaylorBubble(Fluid fluidNom, Gas gasNom, PhysicsParam physicsParam, SimParam simParam,
            int inUse, out InternalObj internalObj, out PlotObj plotObj)
        {
            return this._gasBubble.InitializeClWithTaylorBubble(fluidNom, gasNom, physicsParam, simParam, inUse,
                out internalObj, out plotObj);
        }

        public string[] SetModelOrder(string firstModel, string secondModel)
        {
            return _gasBubble.SetModelOrder(firstModel, secondModel);
        }

        public InterfaceObj InputOutputMapping(string[] modelFlowOrder, InterfaceObj bhWithTbIfc, InterfaceObj clWithTbIfcIn,
            GeneratedInput inputSetpointData, int iteration, double timeStep, double presAtmBar, double density,
            double zeroLimit2, out InterfaceObj clWithTbIfcOut)
        {
            return this._gasBubble.InputOutputMapping(modelFlowOrder, bhWithTbIfc, clWithTbIfcIn, inputSetpointData,
                iteration, timeStep, presAtmBar, density, zeroLimit2, out clWithTbIfcOut);
        }

        public InterfaceObj ConduitWithTaylorBubbleStep(InterfaceObj interfaceObj, InternalObj internalObj, PhysicsParam physicsParam,
            SimParam simParam, out InternalObj internalObjOut, out double[] plotVariables)
        {
            return this._gasBubble.ConduitWithTaylorBubbleStep(interfaceObj, internalObj, physicsParam, simParam,
                out internalObjOut, out plotVariables);
        }

        public PlotObj AugmentPlotObj(int iteration, PlotObj plotObj, double[] vector)
        {
            return this._gasBubble.AugmentPlotObj(iteration, plotObj, vector);
        }

        public void PlotResult(int figNumber, PlotObj plotObj, int plotObjectName, double plotWidth, double timeStep)
        {
            this._gasBubble.PlotResult(figNumber, plotObj, plotObjectName, plotWidth, timeStep);
        }

        #endregion

    }
}