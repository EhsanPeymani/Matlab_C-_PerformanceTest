using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace GasBubble.BusinessLayer
{
    public class ThreadDdsClient
    {
        public Timer DdsTimer { get; set; }
        public int CycleTime { get; set; }
        public GasBubbleModel Model { get;}
        public Client Client { get; }

        public ThreadDdsClient(int cycleTimeMilliseconds, GasBubbleModel model, string serverName, string clientName)
        {
            this.Model = model;

            var task = new Task<Client>(() =>
            {
                var client = new Client(serverName, clientName);
                client.Connect();
                return client;
            });
            task.Start();

            this.DdsTimer = new Timer(cycleTimeMilliseconds);
            this.DdsTimer.AutoReset = true;
            this.DdsTimer.Elapsed += DdsTimerOnElapsed;

            this.Client = task.Result;
        }

        private void DdsTimerOnElapsed(object sender, ElapsedEventArgs elapsedEventArgs)
        {
            var timer = (Timer) sender;
            var setProvidedVariables = new Task<bool>(UpdateProvidedVariables);
            setProvidedVariables.Start();
            if (setProvidedVariables.Result)
            {
                //Console.WriteLine($"{DateTime.Now:hh:mm:ss.fff} - Update Provided Variables. {this.DdsTimer.Interval} {elapsedEventArgs.SignalTime:hh:mm:ss.fff}");
            }
        }

        private bool UpdateProvidedVariables()
        {
            var modelOutputs = this.Model.ModelOutputs();
            modelOutputs[1] = 1000;
            this.Client.UpdateProvidedVariables(modelOutputs);
            return true;
        }

        public void Start()
        {
            this.DdsTimer.Enabled = true;
        }

        public void Stop()
        {
            this.DdsTimer.Enabled = false;
        }
    }
}
