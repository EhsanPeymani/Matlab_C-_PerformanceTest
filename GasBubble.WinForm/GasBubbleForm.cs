using System;
using System.Globalization;
using System.Threading;
using System.Windows.Forms;
using GasBubble.BusinessLayer;

namespace GasBubble.WinForm
{
    public partial class GasBubbleForm : Form
    {
        private ThreadRunSimStep _simThread;
        private ThreadPlotFinalResult _plotThread;
        private Thread _statusThread;

        public GasBubbleForm()
        {
            InitializeComponent();

            checkboxBorehole.Checked = true;
            checkboxChokeline.Checked = false;
            checkboxBoreholeFirst.Checked = false;
            checkboxRealtime.Checked = true;

            InitializeMatlabModel();
        }

        private void InitializeMatlabModel()
        {
            var simTime = 60;
            var timeStep = 0.05;

            txtSimTime.Text = simTime.ToString();
            txtTimeStep.Text = timeStep.ToString(CultureInfo.InvariantCulture);

            InitializeMatlabModelHelper(simTime, timeStep);
        }

        private void InitializeMatlabModelHelper(int simTime, double timeStep)
        {
            var model = new GasBubbleModel(simTime, timeStep, checkboxBorehole.Checked, checkboxChokeline.Checked, checkboxBoreholeFirst.Checked);

            int timeStepMilliseconds = Convert.ToInt32(timeStep * 1000);
            this._simThread = new ThreadRunSimStep(model, timeStepMilliseconds, checkboxRealtime.Checked, false);
            this._plotThread = new ThreadPlotFinalResult(model);

            this._statusThread = new Thread(() => StatusReporter(txtResult, model));
            this._statusThread.IsBackground = true;

            btnStart.Enabled = true;
            btnStop.Enabled = true;
            btnPlot.Enabled = true;

            var realtimeText = checkboxRealtime.Checked ? "Realtime" : "Fastforward";

            txtResult.Text = $"{DateTime.Now} - Model initialized (simTime = {simTime}, timeStep = {timeStep}, {realtimeText}).{Environment.NewLine}";
        }

        private void StatusReporter(object obj, GasBubbleModel model)
        {
            var txtbox = (TextBox) obj;

            while (true)
            {
                txtbox.Text += $"{DateTime.Now} - Simulation is running (Simulation time: {model.SimParam.GlobalTimeStep*model.StepCount}).{Environment.NewLine}";
                Thread.Sleep(10000);
            }

        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            this._simThread.Start();
            this._statusThread.Start();
            btnStart.Enabled = false;

            txtResult.Text += $"{DateTime.Now} - Simulation started.{Environment.NewLine}";
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            if (this._simThread.SimThread.IsAlive)
            {
                this._simThread.Stop();
                btnStop.Enabled = false;
                txtResult.Text += $"{DateTime.Now} - Simulation stopped.{Environment.NewLine}";
            }
            if (this._statusThread.IsAlive)
            {
                this._statusThread.Abort();
                btnStop.Enabled = false;
                txtResult.Text += $"{DateTime.Now} - Simulation stop requested.{Environment.NewLine}";
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            if (this._simThread.SimThread.IsAlive)
                this._simThread.Stop();

            if (this._plotThread.plotThread.IsAlive)
                this._plotThread.Stop();

            if (this._statusThread.IsAlive)
                this._statusThread.Abort();

            txtResult.Text += $"{DateTime.Now} - Applocation closing ...";
            Thread.Sleep(1000);

            this.Close();
        }

        private void btnInitialize_Click(object sender, EventArgs e)
        {
            if (this._simThread.SimThread.IsAlive || this._plotThread.plotThread.IsAlive)
            {
                txtResult.Text +=
                    $"{DateTime.Now} - Initializaion failed - either simulation or plotting is undergoing.{Environment.NewLine}";
                return;
            }

            if (!int.TryParse(txtSimTime.Text, out var simTime))
                simTime = 60;

            if (!double.TryParse(txtTimeStep.Text, out var timeStep))
                timeStep = 0.01;

            InitializeMatlabModelHelper(simTime, timeStep);
        }

        private void btnPlot_Click(object sender, EventArgs e)
        {
            this._plotThread.Start();
            btnPlot.Enabled = false;
            btnStart.Enabled = false;
            txtResult.Text += $"{DateTime.Now} - Plotting started.{Environment.NewLine}";


            this._plotThread.Join();
            this._plotThread.Stop();
        }
    }
}
