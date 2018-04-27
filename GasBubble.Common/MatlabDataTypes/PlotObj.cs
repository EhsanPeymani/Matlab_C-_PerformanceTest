namespace GasBubble.Common.MatlabDataTypes
{
    public struct PlotObj
    {
        public string ObjectName;
        public double OutputOrder;
        public double[] PlotGrouping;
        public string[] OutputNames;
        public double LenConduit;
        public double AreaCrsConduit;
        public double[,] PlotMatrix;
    }
}