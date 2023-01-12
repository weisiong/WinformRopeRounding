namespace WinformRopeRounding
{
    partial class FormMain
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.msMain = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.colorSpacePickerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.configEditorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.cameraImageBox1 = new Emgu.CV.UI.ImageBox();
            this.txtDebug = new Serilog.Sinks.WinForms.Core.SimpleLogTextBox();
            this.btnStop = new System.Windows.Forms.Button();
            this.lblABBStatus = new System.Windows.Forms.Label();
            this.btnAcknowledge = new System.Windows.Forms.Button();
            this.txtStatus = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtCounter = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.nudUnit = new System.Windows.Forms.NumericUpDown();
            this.btnStart = new System.Windows.Forms.Button();
            this.cboModel = new System.Windows.Forms.ComboBox();
            this.btnStartCalibrate = new System.Windows.Forms.Button();
            this.btnInitialize = new System.Windows.Forms.Button();
            this.btnPause = new System.Windows.Forms.Button();
            this.btnStartTest = new System.Windows.Forms.Button();
            this.msMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cameraImageBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudUnit)).BeginInit();
            this.SuspendLayout();
            // 
            // msMain
            // 
            this.msMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.toolsToolStripMenuItem});
            this.msMain.Location = new System.Drawing.Point(0, 0);
            this.msMain.Name = "msMain";
            this.msMain.Size = new System.Drawing.Size(974, 24);
            this.msMain.TabIndex = 0;
            this.msMain.Text = "MainMenu";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "&File";
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(93, 22);
            this.exitToolStripMenuItem.Text = "E&xit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // toolsToolStripMenuItem
            // 
            this.toolsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.colorSpacePickerToolStripMenuItem,
            this.configEditorToolStripMenuItem});
            this.toolsToolStripMenuItem.Name = "toolsToolStripMenuItem";
            this.toolsToolStripMenuItem.Size = new System.Drawing.Size(46, 20);
            this.toolsToolStripMenuItem.Text = "Tools";
            // 
            // colorSpacePickerToolStripMenuItem
            // 
            this.colorSpacePickerToolStripMenuItem.Name = "colorSpacePickerToolStripMenuItem";
            this.colorSpacePickerToolStripMenuItem.Size = new System.Drawing.Size(172, 22);
            this.colorSpacePickerToolStripMenuItem.Text = "Color Space &Picker";
            this.colorSpacePickerToolStripMenuItem.Click += new System.EventHandler(this.colorSpacePickerToolStripMenuItem_Click);
            // 
            // configEditorToolStripMenuItem
            // 
            this.configEditorToolStripMenuItem.Name = "configEditorToolStripMenuItem";
            this.configEditorToolStripMenuItem.Size = new System.Drawing.Size(172, 22);
            this.configEditorToolStripMenuItem.Text = "Config &Editor";
            this.configEditorToolStripMenuItem.Click += new System.EventHandler(this.configEditorToolStripMenuItem_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Location = new System.Drawing.Point(0, 616);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(974, 22);
            this.statusStrip1.TabIndex = 1;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // splitContainer1
            // 
            this.splitContainer1.BackColor = System.Drawing.SystemColors.Control;
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.splitContainer1.Location = new System.Drawing.Point(0, 24);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.tableLayoutPanel1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.btnStop);
            this.splitContainer1.Panel2.Controls.Add(this.lblABBStatus);
            this.splitContainer1.Panel2.Controls.Add(this.btnAcknowledge);
            this.splitContainer1.Panel2.Controls.Add(this.txtStatus);
            this.splitContainer1.Panel2.Controls.Add(this.label4);
            this.splitContainer1.Panel2.Controls.Add(this.txtCounter);
            this.splitContainer1.Panel2.Controls.Add(this.label3);
            this.splitContainer1.Panel2.Controls.Add(this.label2);
            this.splitContainer1.Panel2.Controls.Add(this.label1);
            this.splitContainer1.Panel2.Controls.Add(this.nudUnit);
            this.splitContainer1.Panel2.Controls.Add(this.btnStart);
            this.splitContainer1.Panel2.Controls.Add(this.cboModel);
            this.splitContainer1.Panel2.Controls.Add(this.btnStartCalibrate);
            this.splitContainer1.Panel2.Controls.Add(this.btnInitialize);
            this.splitContainer1.Panel2.Controls.Add(this.btnPause);
            this.splitContainer1.Panel2.Controls.Add(this.btnStartTest);
            this.splitContainer1.Size = new System.Drawing.Size(974, 592);
            this.splitContainer1.SplitterDistance = 805;
            this.splitContainer1.TabIndex = 2;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.cameraImageBox1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.txtDebug, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 69.5946F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 30.40541F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(805, 592);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // cameraImageBox1
            // 
            this.cameraImageBox1.BackgroundImage = global::WinformRopeRounding.Properties.Resources.NoSignal;
            this.cameraImageBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.cameraImageBox1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cameraImageBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cameraImageBox1.Enabled = false;
            this.cameraImageBox1.Location = new System.Drawing.Point(3, 3);
            this.cameraImageBox1.Name = "cameraImageBox1";
            this.cameraImageBox1.Size = new System.Drawing.Size(799, 405);
            this.cameraImageBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.cameraImageBox1.TabIndex = 2;
            this.cameraImageBox1.TabStop = false;
            // 
            // txtDebug
            // 
            this.txtDebug.BackColor = System.Drawing.Color.White;
            this.txtDebug.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.txtDebug.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtDebug.ForContext = "";
            this.txtDebug.Location = new System.Drawing.Point(4, 414);
            this.txtDebug.LogBorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.txtDebug.LogPadding = new System.Windows.Forms.Padding(3);
            this.txtDebug.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.txtDebug.Name = "txtDebug";
            this.txtDebug.ReadOnly = true;
            this.txtDebug.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtDebug.Size = new System.Drawing.Size(797, 175);
            this.txtDebug.TabIndex = 3;
            // 
            // btnStop
            // 
            this.btnStop.Location = new System.Drawing.Point(12, 359);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(141, 35);
            this.btnStop.TabIndex = 16;
            this.btnStop.Text = "Stop After Current Unit";
            this.btnStop.UseVisualStyleBackColor = true;
            this.btnStop.Click += new System.EventHandler(this.btnStop_Click);
            // 
            // lblABBStatus
            // 
            this.lblABBStatus.AutoSize = true;
            this.lblABBStatus.BackColor = System.Drawing.Color.Red;
            this.lblABBStatus.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblABBStatus.ForeColor = System.Drawing.Color.White;
            this.lblABBStatus.Location = new System.Drawing.Point(27, 3);
            this.lblABBStatus.Name = "lblABBStatus";
            this.lblABBStatus.Size = new System.Drawing.Size(108, 21);
            this.lblABBStatus.TabIndex = 15;
            this.lblABBStatus.Text = "ABB OFFLINE";
            // 
            // btnAcknowledge
            // 
            this.btnAcknowledge.Location = new System.Drawing.Point(12, 445);
            this.btnAcknowledge.Name = "btnAcknowledge";
            this.btnAcknowledge.Size = new System.Drawing.Size(141, 31);
            this.btnAcknowledge.TabIndex = 14;
            this.btnAcknowledge.Text = "Acknowledge";
            this.btnAcknowledge.UseVisualStyleBackColor = true;
            // 
            // txtStatus
            // 
            this.txtStatus.Location = new System.Drawing.Point(12, 279);
            this.txtStatus.Name = "txtStatus";
            this.txtStatus.ReadOnly = true;
            this.txtStatus.Size = new System.Drawing.Size(141, 23);
            this.txtStatus.TabIndex = 12;
            this.txtStatus.Text = "Standby";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 261);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(85, 15);
            this.label4.TabIndex = 11;
            this.label4.Text = "Current Status:";
            // 
            // txtCounter
            // 
            this.txtCounter.Location = new System.Drawing.Point(12, 215);
            this.txtCounter.Name = "txtCounter";
            this.txtCounter.ReadOnly = true;
            this.txtCounter.Size = new System.Drawing.Size(141, 23);
            this.txtCounter.TabIndex = 10;
            this.txtCounter.Text = "0";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 197);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(132, 15);
            this.label3.TabIndex = 9;
            this.label3.Text = "Counter Unit Produced:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 140);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(122, 15);
            this.label2.TabIndex = 8;
            this.label2.Text = "Produce No. Of Units:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 88);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(95, 15);
            this.label1.TabIndex = 7;
            this.label1.Text = "Model Selection:";
            // 
            // nudUnit
            // 
            this.nudUnit.Location = new System.Drawing.Point(12, 158);
            this.nudUnit.Name = "nudUnit";
            this.nudUnit.Size = new System.Drawing.Size(141, 23);
            this.nudUnit.TabIndex = 6;
            this.nudUnit.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
            // 
            // btnStart
            // 
            this.btnStart.Location = new System.Drawing.Point(10, 322);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(143, 31);
            this.btnStart.TabIndex = 5;
            this.btnStart.Text = "Start";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // cboModel
            // 
            this.cboModel.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboModel.FormattingEnabled = true;
            this.cboModel.Items.AddRange(new object[] {
            "Model01",
            "Model02",
            "Model03",
            "Model04",
            "Model05",
            "Model06",
            "Model07",
            "Model08",
            "Model09",
            "Model10",
            "Model11",
            "Model12"});
            this.cboModel.Location = new System.Drawing.Point(10, 106);
            this.cboModel.Name = "cboModel";
            this.cboModel.Size = new System.Drawing.Size(143, 23);
            this.cboModel.TabIndex = 4;
            // 
            // btnStartCalibrate
            // 
            this.btnStartCalibrate.Location = new System.Drawing.Point(10, 558);
            this.btnStartCalibrate.Name = "btnStartCalibrate";
            this.btnStartCalibrate.Size = new System.Drawing.Size(143, 31);
            this.btnStartCalibrate.TabIndex = 3;
            this.btnStartCalibrate.Text = "Start Cablirate";
            this.btnStartCalibrate.UseVisualStyleBackColor = true;
            this.btnStartCalibrate.Click += new System.EventHandler(this.btnStartCalibrate_Click);
            // 
            // btnInitialize
            // 
            this.btnInitialize.Location = new System.Drawing.Point(10, 44);
            this.btnInitialize.Name = "btnInitialize";
            this.btnInitialize.Size = new System.Drawing.Size(143, 31);
            this.btnInitialize.TabIndex = 2;
            this.btnInitialize.Text = "Initialize";
            this.btnInitialize.UseVisualStyleBackColor = true;
            this.btnInitialize.Click += new System.EventHandler(this.btnInitialize_Click);
            // 
            // btnPause
            // 
            this.btnPause.Location = new System.Drawing.Point(12, 519);
            this.btnPause.Name = "btnPause";
            this.btnPause.Size = new System.Drawing.Size(141, 31);
            this.btnPause.TabIndex = 1;
            this.btnPause.Text = "Pause";
            this.btnPause.UseVisualStyleBackColor = true;
            this.btnPause.Click += new System.EventHandler(this.BtnPause_Click);
            // 
            // btnStartTest
            // 
            this.btnStartTest.Location = new System.Drawing.Point(10, 482);
            this.btnStartTest.Name = "btnStartTest";
            this.btnStartTest.Size = new System.Drawing.Size(143, 31);
            this.btnStartTest.TabIndex = 0;
            this.btnStartTest.Text = "Start Test";
            this.btnStartTest.UseVisualStyleBackColor = true;
            this.btnStartTest.Click += new System.EventHandler(this.BtnStartTest_Click);
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(974, 638);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.msMain);
            this.MainMenuStrip = this.msMain;
            this.Name = "FormMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Main Terminal";
            this.Load += new System.EventHandler(this.FormMain_Load);
            this.msMain.ResumeLayout(false);
            this.msMain.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.cameraImageBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudUnit)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MenuStrip msMain;
        private ToolStripMenuItem fileToolStripMenuItem;
        private ToolStripMenuItem exitToolStripMenuItem;
        private StatusStrip statusStrip1;
        private SplitContainer splitContainer1;
        private TableLayoutPanel tableLayoutPanel1;
        private Button btnPause;
        private Button btnStartTest;
        private Emgu.CV.UI.ImageBox cameraImageBox1;
        private ToolStripMenuItem toolsToolStripMenuItem;
        private ToolStripMenuItem colorSpacePickerToolStripMenuItem;
        private Serilog.Sinks.WinForms.Core.SimpleLogTextBox txtDebug;
        private Button btnInitialize;
        private Button btnStartCalibrate;
        private ToolStripMenuItem configEditorToolStripMenuItem;
        private ComboBox cboModel;
        private Button btnStart;
        private Label label2;
        private Label label1;
        private NumericUpDown nudUnit;
        private TextBox txtCounter;
        private Label label3;
        private TextBox txtStatus;
        private Label label4;
        private Button btnAcknowledge;
        private Label lblABBStatus;
        private Button btnStop;
    }
}