using System.Threading;

namespace GasBubble.BusinessLayer
{
    public class ThreadPlotFinalResult
    {
        public Thread plotThread { get; set; }

        public ThreadPlotFinalResult(GasBubbleModel model)
        {
            this.plotThread = new Thread(model.PlotFinalResults);

            this.plotThread.IsBackground = false;
            this.plotThread.Name = "PlotFinalResultThread";
        }

        public void Start()
        {
            this.plotThread.Start();
        }

        public void Stop()
        {
            this.plotThread.Abort();
        }

        public void Join(int millisecondTimeout)
        {
            this.plotThread.Join(millisecondTimeout);
        }

        public void Join()
            {
                this.plotThread.Join();
            }

        }
}
