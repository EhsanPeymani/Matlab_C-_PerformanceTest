using GasBubble.Common.MatlabDataTypes;

namespace GasBubble.Matlab.Interfaces
{
    public interface IGasBubble
    {
        SimParam SetSimParam(int simTime, double timeStep);
        PhysicsParam SetPhysicsParam();
        GeneratedInput SetSignalGeneratorParameters();
        Fluid SetNominalMudProperties(PhysicsParam physicsParam);
        Gas SetNominalGasProperties(PhysicsParam physicsParam);
        InterfaceObj InitializeBhWithTaylorBubble(Fluid fluidNom, Gas gasNom, PhysicsParam physicsParam,
            SimParam simParam, int inUse, out InternalObj internalObj, out PlotObj plotObj);
        InterfaceObj InitializeClWithTaylorBubble(Fluid fluidNom, Gas gasNom, PhysicsParam physicsParam,
            SimParam simParam, int inUse, out InternalObj internalObj, out PlotObj plotObj);
        string[] SetModelOrder(string firstModel, string secondModel);
        InterfaceObj InputOutputMapping(string[] modelFlowOrder, InterfaceObj bhWithTbIfc, InterfaceObj clWithTbIfcIn,
            GeneratedInput inputSetpointData, int iteration, double timeStep, double presAtmBar, double density, double zeroLimit2,
            out InterfaceObj clWithTbIfcOut);
        InterfaceObj ConduitWithTaylorBubbleStep(InterfaceObj interfaceObj, InternalObj internalObj,
            PhysicsParam physicsParam, SimParam simParam,
            out InternalObj interfaceObjOut, out double[] plotVariables);
        PlotObj AugmentPlotObj(int iteration, PlotObj plotObj, double[] vector);
        void PlotResult(int figNumber, PlotObj plotObj, int plotObjectName, double plotWidth, double timeStep);
    }
}