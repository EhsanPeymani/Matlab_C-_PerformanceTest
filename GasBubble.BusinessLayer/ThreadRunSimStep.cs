using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace GasBubble.BusinessLayer
{
    public class ThreadRunSimStep
    {
        public bool IsCancelled { get; set; }
        public Thread SimThread { get; set; }
        public int CycleTime { get; set; }
        private Stopwatch stopwatch;
        
        public ThreadRunSimStep(GasBubbleModel model, int cycleTimeMilliseconds, bool realTime = true, bool printDetails = true)
        {
            int counter = 0;
            this.CycleTime = cycleTimeMilliseconds;
            this.stopwatch = new Stopwatch();

            this.SimThread = new Thread( () =>
            {
                Console.WriteLine($"Enter thread at {DateTime.Now}");
                while (counter <= model.SimParam.SimulationTimeInit/model.SimParam.GlobalTimeStep)
                {
                    if (IsCancelled)
                        break;

                    var elapsedTime = model.Step(counter++);
                    if (printDetails) 
                        Console.WriteLine($"Run {(counter-1)} @ {(counter-1)*model.SimParam.GlobalTimeStep} - {this.stopwatch.ElapsedMilliseconds}: execution time: {elapsedTime} msec.");
                    this.stopwatch.Restart();

                    if (elapsedTime < cycleTimeMilliseconds && realTime)
                    {
                        Thread.Sleep(cycleTimeMilliseconds - Convert.ToInt32(elapsedTime));
                    }
                    
                }
                Console.WriteLine($"Exit thread at {DateTime.Now}");
            });

            this.SimThread.IsBackground = true;
            this.SimThread.Name = "GasBubbleModelThread";
            this.SimThread.Priority = ThreadPriority.Highest;
        }

        public void Start()
        {
            this.SimThread.Start();
        }

        public void Stop()
        {
            this.IsCancelled = true;
        }

        public void Join(int millisecondTimeout)
        {
            this.SimThread.Join(millisecondTimeout);
            this.Stop();
        }
    }
}
