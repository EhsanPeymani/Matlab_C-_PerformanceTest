using System;
using System.Runtime.InteropServices;
using System.Threading;
using System.Threading.Tasks;
using GasBubble.BusinessLayer;
using GasBubble.TestConsole.Properties;

namespace GasBubble.TestConsole
{
    public class MatlabTest
    {
        public void Test1()
        {
            var timeInit = 60;
            var globalTimeStep = 02;

            var model = new GasBubbleModel(timeInit, globalTimeStep);
            var modelInstantiationExecutionTime = model.StopWatch.Elapsed.TotalMilliseconds;

            var maxElapedTime = 0.0;
            double average = 0.0;

            int numOfIteration = 200;

            for (int i = 0; i < numOfIteration; i++)
            {
                var elapsedTime = model.Step(i);
                Console.WriteLine($"Total time for executing one step is {elapsedTime} millisecond.");
                if (i > 5)
                {
                    maxElapedTime = Math.Max(maxElapedTime, elapsedTime);
                    average +=  elapsedTime;
                }
                Thread.Sleep(20);
            }

            Console.WriteLine($"Instantiation took {modelInstantiationExecutionTime} milliseconds.");

            Console.WriteLine($"The largest elapsed time is {maxElapedTime} milliseconds.");
            Console.WriteLine($"The average execution time is {average/numOfIteration} milliseconds.");
        }

        public void Test2()
        {
            var simTime = 600;
            var timeStep = 0.05;
            var timeStepMilliseconds = Convert.ToInt32(timeStep * 1000);

            var model = new GasBubbleModel(simTime, timeStep, true, false);

            var thread = new ThreadRunSimStep(model, timeStepMilliseconds, true, false);
            var plotThread = new ThreadPlotFinalResult(model);

            var ddsThread = new ThreadDdsClient(100, model, Settings.Default.ServerName, Settings.Default.ClientName);

            var startTime = DateTime.Now;
            thread.Start();
            ddsThread.Start();

            //visit https://stackoverflow.com/questions/1196991/get-property-value-from-string-using-reflection-in-c-sharp


            Console.ReadLine();
            thread.Stop();
            var endTime = DateTime.Now;

            Console.WriteLine($"Simulation started {startTime}.\nSimulation ended {endTime}");

            //plotThread.Start();
            //Console.ReadLine();
            //plotThread.Stop();
        }

        public static object GetPropertyValue(object src, string propertyName)
        {
            return src.GetType().GetProperty(propertyName)?.GetValue(src, null);
        }
    }
}
