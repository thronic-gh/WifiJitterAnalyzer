using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Diagnostics;
using System.Net.NetworkInformation;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace WiFi_Jitter_Analyzer
{
	public partial class Form1 : Form
	{
		// vars. 
		private static string Progver = ""+
			Assembly.GetExecutingAssembly().GetName().Version.Major.ToString() +"."+
			Assembly.GetExecutingAssembly().GetName().Version.Minor.ToString();
		private static string exepath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
		private List<DataPoint> GraphPoints = new List<DataPoint>();
		private bool TestIsRunning = false;
		private int GraphMaxYVal = 5;
		Thread PingProcessEngine;

		// Cross-thread delegates.
		delegate void UpdateKissReportDg(String s);
		delegate void UpdateChartPointDg(int i, DataPoint dp);

		public Form1(string[] args)
		{
			InitializeComponent();
			this.Text = "Wifi Jitter Analyzer v"+ Progver +" by Dag J Nedrelid.";

			// Change the protected double buffering member of Chart control to true.
			typeof(Control).InvokeMember("DoubleBuffered",
				BindingFlags.SetProperty | BindingFlags.Instance | BindingFlags.NonPublic,
				null, TestChart, new object[] { true });

			// Set up an engine for performing pings.
			PingProcessEngine = new Thread(new ThreadStart(PingEngine));
			PingProcessEngine.IsBackground = true;
			PingProcessEngine.Start();
		}

		private void button1_Click(object sender, EventArgs e)
		{
			if (!TestIsRunning) {
				txtTimeoutlog.Clear();

				TestChart.Titles[0].Text = "Jitter Result Chart";
				TestChart.ChartAreas[0].AxisY.Maximum = 0;

				TestChart.Series.Clear();
				TestChart.Series.Add(txtTestIP.Text);
				TestChart.Series[txtTestIP.Text]["LabelStyle"] = "Bottom";
				TestChart.Series[txtTestIP.Text]["DrawingStyle"] = "Cylinder";
				TestChart.Series[txtTestIP.Text].ChartType = SeriesChartType.Column;
				TestChart.Series[txtTestIP.Text].BackGradientStyle = GradientStyle.DiagonalLeft;
				TestChart.Series[txtTestIP.Text].BorderWidth = 1;
				TestChart.Series[txtTestIP.Text].BorderColor = System.Drawing.Color.Black;
				TestChart.Series[txtTestIP.Text].IsValueShownAsLabel = true;

				// Initialize columns.
				DataPoint pt = new DataPoint();
				pt.SetValueXY("GOOD", 0);
				pt.Color = System.Drawing.Color.DeepSkyBlue;
				TestChart.Series[txtTestIP.Text].Points.Add(pt);
				
				pt = new DataPoint();
				pt.SetValueXY("OK", 0);
				pt.Color = System.Drawing.Color.LightBlue;
				TestChart.Series[txtTestIP.Text].Points.Add(pt);
				
				pt = new DataPoint();
				pt.SetValueXY("SLOW", 0);
				pt.Color = System.Drawing.Color.Orange;
				TestChart.Series[txtTestIP.Text].Points.Add(pt);
				
				pt = new DataPoint();
				pt.SetValueXY("BAD", 0);
				pt.Color = System.Drawing.Color.Red;
				TestChart.Series[txtTestIP.Text].Points.Add(pt);
				
				pt = new DataPoint();
				pt.SetValueXY("T/O", 0);
				pt.Color = System.Drawing.Color.DarkGray;
				TestChart.Series[txtTestIP.Text].Points.Add(pt);

				btnStart.Text = "Press to stop.";
				TestIsRunning = true;

			} else {
				btnStart.Text = "Start";
				TestIsRunning = false;
			}
		}

		private void UpdateChartPoint(int i, DataPoint dp)
		{
			try {
			if (this.InvokeRequired) {
				UpdateChartPointDg Dg = new UpdateChartPointDg(UpdateChartPoint);
				this.Invoke(Dg, new object[] {i, dp});
			} else {
				if ((dp.YValues[0]+1) >= GraphMaxYVal)
					GraphMaxYVal += 5;
				
				TestChart.ChartAreas[0].AxisY.Maximum = GraphMaxYVal;
				TestChart.Series[txtTestIP.Text].Points[i] = dp;

			}} catch (Exception) {}
		}

		private void PingEngine()
		{
			Ping TestPing = new Ping();
			PingReply TestReply;
			String KissReport, TimeoutRecorded;
			bool FirstTimeoutRecorded = true;
			List<int> Times = new List<int>();
			List<String> PingData = new List<String>();
			decimal Pingcount, Timeouts;
			decimal GOODpings, OKpings, BADpings, SUCKpings;
			decimal GOODperc, OKperc, BADperc, SUCKperc, TIMEOUTperc;
			DataPoint GOODpt, OKpt, BADpt, SUCKpt, TIMEOUTpt;
			Stopwatch ElapsedTime = Stopwatch.StartNew();
			TimeSpan ElapsedTimeSpan;

			while(true) {

				// Run in circles if test is not running.
				if (!TestIsRunning) {
					PingData.Clear();
					//UpdateKissReport("Test not running.");

					if (ElapsedTime.IsRunning) {
						ElapsedTime.Stop();
						lblTimeElapsed.Text += " (stopped)";
					}

					Thread.Sleep(500);
					continue;
				}
				
				// Start timer.
				if (!ElapsedTime.IsRunning)
					ElapsedTime = Stopwatch.StartNew();

				// Send a ping.
				Thread.Sleep(1000);

				try {
				TestReply = TestPing.Send(txtTestIP.Text, 3000);

				if (TestReply.Status == IPStatus.Success) {
					PingData.Add(TestReply.RoundtripTime.ToString());

				} else if (TestReply.Status == IPStatus.TimedOut) {
					PingData.Add("Request timed out.");

					if (FirstTimeoutRecorded) {
						FirstTimeoutRecorded = false;
						txtTimeoutlog.Clear();
					}

					TimeoutRecorded = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss", CultureInfo.InvariantCulture) + Environment.NewLine;
					txtTimeoutlog.AppendText(TimeoutRecorded);
					File.AppendAllText(exepath +@"\Timeouts.txt", TimeoutRecorded, Encoding.ASCII);
				
				}} catch (Exception) { 
					UpdateKissReport("Ping error. Check your connection."); 
					continue;
				}

				// Analyze pings.
				Pingcount = 0; 
				Timeouts = 0;
				GOODpings = 0; 
				OKpings = 0; 
				BADpings = 0;
				SUCKpings = 0;
				GOODperc = 0;
				OKperc = 0;
				BADperc = 0;
				SUCKperc = 0; 
				TIMEOUTperc = 0;

				Times.Clear();
				foreach (string l in PingData) {
					++Pingcount;
					
					if (l == "Request timed out.") {
						++Timeouts;
					} else {
						Times.Add(Int32.Parse(l));
					}
				}

				// Analyze ping quality.
				foreach (int t in Times) {
					if (t < 50)
						++GOODpings;
					else if (t < 100)
						++OKpings;
					else if (t < 1000)
						++BADpings;
					else if (t > 1000)
						++SUCKpings;
				}

				// Report
				try {
				GOODperc = Math.Round(GOODpings/(decimal)(Pingcount/100));
				OKperc = Math.Round(OKpings/(decimal)(Pingcount/100));
				BADperc = Math.Round(BADpings/(decimal)(Pingcount/100));
				SUCKperc = Math.Round(SUCKpings/(decimal)(Pingcount/100));
				TIMEOUTperc = Math.Round(Timeouts/(decimal)(Pingcount/100));
				} catch (Exception) { continue; }

				// KISS popup report.
				KissReport = "Connection is "+ GOODperc +"% GOOD. ";
				if (BADperc > 0 || TIMEOUTperc > 0 || SUCKperc > 0 || OKperc > 0) {
					KissReport += ""
						+ (OKperc > 0 ? OKperc +"% OK. ":"")
						+ (BADperc > 0 ? BADperc + "% SLOW. ":"")
						+ (SUCKperc > 0 ? SUCKperc + "% BAD. ":"")
						+ (TIMEOUTperc > 0 ? TIMEOUTperc +"% USELESS. ":"");
				}

				// Update chart.
				GOODpt = new DataPoint();
				GOODpt.SetValueXY("GOOD", GOODpings);
				GOODpt.Color = System.Drawing.Color.DeepSkyBlue;
				UpdateChartPoint(0, GOODpt);
				
				OKpt = new DataPoint();
				OKpt.SetValueXY("OK", OKpings);
				OKpt.Color = System.Drawing.Color.LightBlue;
				UpdateChartPoint(1, OKpt);
				
				BADpt = new DataPoint();
				BADpt.SetValueXY("SLOW", BADpings);
				BADpt.Color = System.Drawing.Color.Orange;
				UpdateChartPoint(2, BADpt);
				
				SUCKpt = new DataPoint();
				SUCKpt.SetValueXY("BAD", SUCKpings);
				SUCKpt.Color = System.Drawing.Color.Red;
				UpdateChartPoint(3, SUCKpt);
				
				TIMEOUTpt = new DataPoint();
				TIMEOUTpt.SetValueXY("T/O", Timeouts);
				TIMEOUTpt.Color = System.Drawing.Color.DarkGray;
				UpdateChartPoint(4, TIMEOUTpt);
				
				UpdateKissReport(KissReport);

				// Update timer.
				ElapsedTimeSpan = ElapsedTime.Elapsed;
				lblTimeElapsed.Text = String.Format(
					"Timer: {0:00}:{1:00}:{2:00}:{3:00}",
					ElapsedTimeSpan.Days,
					ElapsedTimeSpan.Hours,
					ElapsedTimeSpan.Minutes,
					ElapsedTimeSpan.Seconds
				);
			}
		}

		private void UpdateKissReport(String s)
		{
			try {
			if (this.InvokeRequired) {
				UpdateKissReportDg Dg = new UpdateKissReportDg(UpdateKissReport);
				this.Invoke(Dg, new object[] {s});
			} else {
				TestChart.Titles[0].Text = s;
			}} catch (Exception) {}
		}

		private void ErrMsg(string err)
		{
			System.Windows.Forms.MessageBox.Show(err, "Oops", MessageBoxButtons.OK, MessageBoxIcon.Error); 
		}
	}
}
