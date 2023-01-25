namespace WiFi_Jitter_Analyzer
{
	partial class Form1
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null)) {
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
			System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
			System.Windows.Forms.DataVisualization.Charting.Title title1 = new System.Windows.Forms.DataVisualization.Charting.Title();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
			this.btnStart = new System.Windows.Forms.Button();
			this.txtTestIP = new System.Windows.Forms.TextBox();
			this.lblIP = new System.Windows.Forms.Label();
			this.TestChart = new System.Windows.Forms.DataVisualization.Charting.Chart();
			this.rtxtInfo = new System.Windows.Forms.RichTextBox();
			this.label3 = new System.Windows.Forms.Label();
			this.txtTimeoutlog = new System.Windows.Forms.RichTextBox();
			this.pictureBox1 = new System.Windows.Forms.PictureBox();
			this.lblTimeElapsed = new System.Windows.Forms.Label();
			((System.ComponentModel.ISupportInitialize)(this.TestChart)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
			this.SuspendLayout();
			// 
			// btnStart
			// 
			this.btnStart.BackColor = System.Drawing.Color.SkyBlue;
			this.btnStart.Cursor = System.Windows.Forms.Cursors.Hand;
			this.btnStart.FlatAppearance.BorderColor = System.Drawing.Color.Black;
			this.btnStart.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightSkyBlue;
			this.btnStart.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnStart.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btnStart.Location = new System.Drawing.Point(12, 81);
			this.btnStart.Name = "btnStart";
			this.btnStart.Size = new System.Drawing.Size(155, 32);
			this.btnStart.TabIndex = 5;
			this.btnStart.Text = "Start";
			this.btnStart.UseVisualStyleBackColor = false;
			this.btnStart.Click += new System.EventHandler(this.button1_Click);
			// 
			// txtTestIP
			// 
			this.txtTestIP.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.txtTestIP.Location = new System.Drawing.Point(339, 90);
			this.txtTestIP.Name = "txtTestIP";
			this.txtTestIP.Size = new System.Drawing.Size(110, 23);
			this.txtTestIP.TabIndex = 1;
			this.txtTestIP.Text = "1.1.1.1";
			// 
			// lblIP
			// 
			this.lblIP.AutoSize = true;
			this.lblIP.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblIP.Location = new System.Drawing.Point(199, 92);
			this.lblIP.Name = "lblIP";
			this.lblIP.Size = new System.Drawing.Size(134, 17);
			this.lblIP.TabIndex = 4;
			this.lblIP.Text = "Test against this IP:";
			// 
			// TestChart
			// 
			this.TestChart.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
			this.TestChart.AntiAliasing = System.Windows.Forms.DataVisualization.Charting.AntiAliasingStyles.None;
			this.TestChart.BorderlineColor = System.Drawing.Color.Black;
			this.TestChart.BorderlineDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Solid;
			chartArea1.AxisX.MajorGrid.LineColor = System.Drawing.Color.Silver;
			chartArea1.AxisX.MinorGrid.LineColor = System.Drawing.Color.Silver;
			chartArea1.AxisX.TitleFont = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			chartArea1.AxisX2.TitleFont = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			chartArea1.AxisY.MajorGrid.LineColor = System.Drawing.Color.Silver;
			chartArea1.AxisY.MinorGrid.LineColor = System.Drawing.Color.Silver;
			chartArea1.AxisY.TitleFont = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			chartArea1.AxisY2.TitleFont = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			chartArea1.Name = "ChartArea1";
			this.TestChart.ChartAreas.Add(chartArea1);
			this.TestChart.IsSoftShadows = false;
			legend1.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			legend1.IsTextAutoFit = false;
			legend1.Name = "Legend1";
			legend1.TitleFont = new System.Drawing.Font("Arial Narrow", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.TestChart.Legends.Add(legend1);
			this.TestChart.Location = new System.Drawing.Point(12, 119);
			this.TestChart.Name = "TestChart";
			this.TestChart.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.None;
			this.TestChart.Size = new System.Drawing.Size(437, 284);
			this.TestChart.TabIndex = 6;
			this.TestChart.TabStop = false;
			this.TestChart.Text = "TestChart";
			title1.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			title1.Name = "Title1";
			this.TestChart.Titles.Add(title1);
			// 
			// rtxtInfo
			// 
			this.rtxtInfo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.rtxtInfo.BackColor = System.Drawing.Color.White;
			this.rtxtInfo.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.rtxtInfo.Cursor = System.Windows.Forms.Cursors.Default;
			this.rtxtInfo.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.rtxtInfo.Location = new System.Drawing.Point(12, 409);
			this.rtxtInfo.Name = "rtxtInfo";
			this.rtxtInfo.ReadOnly = true;
			this.rtxtInfo.Size = new System.Drawing.Size(437, 145);
			this.rtxtInfo.TabIndex = 9;
			this.rtxtInfo.Text = resources.GetString("rtxtInfo.Text");
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label3.Location = new System.Drawing.Point(460, 12);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(88, 22);
			this.label3.TabIndex = 10;
			this.label3.Text = "Timeouts";
			// 
			// txtTimeoutlog
			// 
			this.txtTimeoutlog.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
			this.txtTimeoutlog.BackColor = System.Drawing.Color.White;
			this.txtTimeoutlog.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.txtTimeoutlog.Cursor = System.Windows.Forms.Cursors.Default;
			this.txtTimeoutlog.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.txtTimeoutlog.Location = new System.Drawing.Point(463, 38);
			this.txtTimeoutlog.Name = "txtTimeoutlog";
			this.txtTimeoutlog.ReadOnly = true;
			this.txtTimeoutlog.Size = new System.Drawing.Size(211, 516);
			this.txtTimeoutlog.TabIndex = 11;
			this.txtTimeoutlog.Text = "No timeouts recorded.";
			// 
			// pictureBox1
			// 
			this.pictureBox1.Image = global::WiFi_Jitter_Analyzer.Properties.Resources.antenne;
			this.pictureBox1.Location = new System.Drawing.Point(56, 12);
			this.pictureBox1.Name = "pictureBox1";
			this.pictureBox1.Size = new System.Drawing.Size(66, 63);
			this.pictureBox1.TabIndex = 101;
			this.pictureBox1.TabStop = false;
			// 
			// lblTimeElapsed
			// 
			this.lblTimeElapsed.AutoSize = true;
			this.lblTimeElapsed.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblTimeElapsed.Location = new System.Drawing.Point(199, 58);
			this.lblTimeElapsed.Name = "lblTimeElapsed";
			this.lblTimeElapsed.Size = new System.Drawing.Size(137, 17);
			this.lblTimeElapsed.TabIndex = 102;
			this.lblTimeElapsed.Text = "Timer: Not Running.";
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.White;
			this.ClientSize = new System.Drawing.Size(686, 566);
			this.Controls.Add(this.lblTimeElapsed);
			this.Controls.Add(this.pictureBox1);
			this.Controls.Add(this.txtTimeoutlog);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.rtxtInfo);
			this.Controls.Add(this.TestChart);
			this.Controls.Add(this.lblIP);
			this.Controls.Add(this.txtTestIP);
			this.Controls.Add(this.btnStart);
			this.DoubleBuffered = true;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.MaximumSize = new System.Drawing.Size(702, 605);
			this.MinimumSize = new System.Drawing.Size(477, 605);
			this.Name = "Form1";
			this.ShowIcon = false;
			this.Text = "WiFi Jitter Analyzer";
			((System.ComponentModel.ISupportInitialize)(this.TestChart)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion
		private System.Windows.Forms.Button btnStart;
		private System.Windows.Forms.TextBox txtTestIP;
		private System.Windows.Forms.Label lblIP;
		private System.Windows.Forms.DataVisualization.Charting.Chart TestChart;
		private System.Windows.Forms.RichTextBox rtxtInfo;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.RichTextBox txtTimeoutlog;
		private System.Windows.Forms.PictureBox pictureBox1;
		private System.Windows.Forms.Label lblTimeElapsed;
	}
}

