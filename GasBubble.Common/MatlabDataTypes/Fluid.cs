namespace GasBubble.Common.MatlabDataTypes
{
    public struct Fluid
    {
        public double PresRefPa;
        public double Density;
        public double BulkModulus;
        public Viscosity Viscosity;
        public ReynoldsNmbTrnsPar ReynoldsNmbTrnsPar;
        public RheologyPipe RheologyPipe;
    }
}