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
            this.txtDebug = new Serilog.Sinks.WinForms.Core.SimpleLogTextBox();
            this.lblWarning = new System.Windows.Forms.TextBox();
            this.cameraImageBox1 = new Emgu.CV.UI.ImageBox();
            this.cameraImageBox2 = new Emgu.CV.UI.ImageBox();
            this.grpPoloygon = new System.Windows.Forms.GroupBox();
            this.nudPt4Y = new System.Windows.Forms.NumericUpDown();
            this.nudPt4X = new System.Windows.Forms.NumericUpDown();
            this.nudPt3Y = new System.Windows.Forms.NumericUpDown();
            this.nudPt3X = new System.Windows.Forms.NumericUpDown();
            this.nudPt2Y = new System.Windows.Forms.NumericUpDown();
            this.nudPt2X = new System.Windows.Forms.NumericUpDown();
            this.nudPt1Y = new System.Windows.Forms.NumericUpDown();
            this.nudPt1X = new System.Windows.Forms.NumericUpDown();
            this.nudOffsetY = new System.Windows.Forms.NumericUpDown();
            this.nudOffsetX = new System.Windows.Forms.NumericUpDown();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.btnStartTestB = new System.Windows.Forms.Button();
            this.btnRight = new System.Windows.Forms.Button();
            this.btnLeft = new System.Windows.Forms.Button();
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
            this.btnStartTestA = new System.Windows.Forms.Button();
            this.msMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cameraImageBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cameraImageBox2)).BeginInit();
            this.grpPoloygon.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudPt4Y)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudPt4X)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudPt3Y)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudPt3X)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudPt2Y)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudPt2X)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudPt1Y)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudPt1X)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudOffsetY)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudOffsetX)).BeginInit();
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
            this.msMain.Size = new System.Drawing.Size(1383, 24);
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
            this.statusStrip1.Location = new System.Drawing.Point(0, 876);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1383, 22);
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
            this.splitContainer1.Panel2.Controls.Add(this.grpPoloygon);
            this.splitContainer1.Panel2.Controls.Add(this.btnStartTestB);
            this.splitContainer1.Panel2.Controls.Add(this.btnRight);
            this.splitContainer1.Panel2.Controls.Add(this.btnLeft);
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
            this.splitContainer1.Panel2.Controls.Add(this.btnStartTestA);
            this.splitContainer1.Size = new System.Drawing.Size(1383, 852);
            this.splitContainer1.SplitterDistance = 1214;
            this.splitContainer1.TabIndex = 2;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.txtDebug, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.lblWarning, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.cameraImageBox1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.cameraImageBox2, 1, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 69.59459F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 30.40541F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1214, 852);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // txtDebug
            // 
            this.txtDebug.BackColor = System.Drawing.Color.White;
            this.txtDebug.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.tableLayoutPanel1.SetColumnSpan(this.txtDebug, 2);
            this.txtDebug.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtDebug.ForContext = "";
            this.txtDebug.Location = new System.Drawing.Point(4, 575);
            this.txtDebug.LogBorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.txtDebug.LogPadding = new System.Windows.Forms.Padding(3);
            this.txtDebug.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.txtDebug.Name = "txtDebug";
            this.txtDebug.ReadOnly = true;
            this.txtDebug.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtDebug.Size = new System.Drawing.Size(1206, 243);
            this.txtDebug.TabIndex = 3;
            // 
            // lblWarning
            // 
            this.lblWarning.BackColor = System.Drawing.Color.Red;
            this.tableLayoutPanel1.SetColumnSpan(this.lblWarning, 2);
            this.lblWarning.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblWarning.ForeColor = System.Drawing.Color.White;
            this.lblWarning.Location = new System.Drawing.Point(3, 824);
            this.lblWarning.Name = "lblWarning";
            this.lblWarning.Size = new System.Drawing.Size(1122, 29);
            this.lblWarning.TabIndex = 4;
            this.lblWarning.Text = "Warning";
            this.lblWarning.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
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
            this.cameraImageBox1.Size = new System.Drawing.Size(601, 566);
            this.cameraImageBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.cameraImageBox1.TabIndex = 2;
            this.cameraImageBox1.TabStop = false;
            // 
            // cameraImageBox2
            // 
            this.cameraImageBox2.BackgroundImage = global::WinformRopeRounding.Properties.Resources.NoSignal;
            this.cameraImageBox2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.cameraImageBox2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.cameraImageBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cameraImageBox2.Enabled = false;
            this.cameraImageBox2.Location = new System.Drawing.Point(610, 3);
            this.cameraImageBox2.Name = "cameraImageBox2";
            this.cameraImageBox2.Size = new System.Drawing.Size(601, 566);
            this.cameraImageBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.cameraImageBox2.TabIndex = 5;
            this.cameraImageBox2.TabStop = false;
            // 
            // grpPoloygon
            // 
            this.grpPoloygon.Controls.Add(this.nudPt4Y);
            this.grpPoloygon.Controls.Add(this.nudPt4X);
            this.grpPoloygon.Controls.Add(this.nudPt3Y);
            this.grpPoloygon.Controls.Add(this.nudPt3X);
            this.grpPoloygon.Controls.Add(this.nudPt2Y);
            this.grpPoloygon.Controls.Add(this.nudPt2X);
            this.grpPoloygon.Controls.Add(this.nudPt1Y);
            this.grpPoloygon.Controls.Add(this.nudPt1X);
            this.grpPoloygon.Controls.Add(this.nudOffsetY);
            this.grpPoloygon.Controls.Add(this.nudOffsetX);
            this.grpPoloygon.Controls.Add(this.label9);
            this.grpPoloygon.Controls.Add(this.label8);
            this.grpPoloygon.Controls.Add(this.label7);
            this.grpPoloygon.Controls.Add(this.label6);
            this.grpPoloygon.Controls.Add(this.label5);
            this.grpPoloygon.Location = new System.Drawing.Point(13, 634);
            this.grpPoloygon.Name = "grpPoloygon";
            this.grpPoloygon.Size = new System.Drawing.Size(143, 213);
            this.grpPoloygon.TabIndex = 20;
            this.grpPoloygon.TabStop = false;
            this.grpPoloygon.Text = "Draw Polygon";
            // 
            // nudPt4Y
            // 
            this.nudPt4Y.Location = new System.Drawing.Point(99, 150);
            this.nudPt4Y.Maximum = new decimal(new int[] {
            2048,
            0,
            0,
            0});
            this.nudPt4Y.Name = "nudPt4Y";
            this.nudPt4Y.Size = new System.Drawing.Size(44, 23);
            this.nudPt4Y.TabIndex = 21;
            this.nudPt4Y.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            // 
            // nudPt4X
            // 
            this.nudPt4X.Location = new System.Drawing.Point(48, 150);
            this.nudPt4X.Maximum = new decimal(new int[] {
            2048,
            0,
            0,
            0});
            this.nudPt4X.Name = "nudPt4X";
            this.nudPt4X.Size = new System.Drawing.Size(44, 23);
            this.nudPt4X.TabIndex = 20;
            this.nudPt4X.Value = new decimal(new int[] {
            15,
            0,
            0,
            0});
            // 
            // nudPt3Y
            // 
            this.nudPt3Y.Location = new System.Drawing.Point(99, 121);
            this.nudPt3Y.Maximum = new decimal(new int[] {
            2048,
            0,
            0,
            0});
            this.nudPt3Y.Name = "nudPt3Y";
            this.nudPt3Y.Size = new System.Drawing.Size(44, 23);
            this.nudPt3Y.TabIndex = 19;
            this.nudPt3Y.Value = new decimal(new int[] {
            200,
            0,
            0,
            0});
            // 
            // nudPt3X
            // 
            this.nudPt3X.Location = new System.Drawing.Point(48, 121);
            this.nudPt3X.Maximum = new decimal(new int[] {
            2048,
            0,
            0,
            0});
            this.nudPt3X.Name = "nudPt3X";
            this.nudPt3X.Size = new System.Drawing.Size(44, 23);
            this.nudPt3X.TabIndex = 18;
            this.nudPt3X.Value = new decimal(new int[] {
            440,
            0,
            0,
            0});
            // 
            // nudPt2Y
            // 
            this.nudPt2Y.Location = new System.Drawing.Point(99, 90);
            this.nudPt2Y.Maximum = new decimal(new int[] {
            2048,
            0,
            0,
            0});
            this.nudPt2Y.Name = "nudPt2Y";
            this.nudPt2Y.Size = new System.Drawing.Size(44, 23);
            this.nudPt2Y.TabIndex = 17;
            this.nudPt2Y.Value = new decimal(new int[] {
            130,
            0,
            0,
            0});
            // 
            // nudPt2X
            // 
            this.nudPt2X.Location = new System.Drawing.Point(48, 90);
            this.nudPt2X.Maximum = new decimal(new int[] {
            2048,
            0,
            0,
            0});
            this.nudPt2X.Name = "nudPt2X";
            this.nudPt2X.Size = new System.Drawing.Size(44, 23);
            this.nudPt2X.TabIndex = 16;
            this.nudPt2X.Value = new decimal(new int[] {
            440,
            0,
            0,
            0});
            // 
            // nudPt1Y
            // 
            this.nudPt1Y.Location = new System.Drawing.Point(99, 61);
            this.nudPt1Y.Maximum = new decimal(new int[] {
            2048,
            0,
            0,
            0});
            this.nudPt1Y.Name = "nudPt1Y";
            this.nudPt1Y.Size = new System.Drawing.Size(44, 23);
            this.nudPt1Y.TabIndex = 15;
            this.nudPt1Y.Value = new decimal(new int[] {
            35,
            0,
            0,
            0});
            // 
            // nudPt1X
            // 
            this.nudPt1X.Location = new System.Drawing.Point(48, 61);
            this.nudPt1X.Maximum = new decimal(new int[] {
            2048,
            0,
            0,
            0});
            this.nudPt1X.Name = "nudPt1X";
            this.nudPt1X.Size = new System.Drawing.Size(44, 23);
            this.nudPt1X.TabIndex = 14;
            this.nudPt1X.Value = new decimal(new int[] {
            15,
            0,
            0,
            0});
            // 
            // nudOffsetY
            // 
            this.nudOffsetY.Location = new System.Drawing.Point(99, 22);
            this.nudOffsetY.Maximum = new decimal(new int[] {
            2048,
            0,
            0,
            0});
            this.nudOffsetY.Name = "nudOffsetY";
            this.nudOffsetY.Size = new System.Drawing.Size(44, 23);
            this.nudOffsetY.TabIndex = 13;
            this.nudOffsetY.Value = new decimal(new int[] {
            106,
            0,
            0,
            0});
            // 
            // nudOffsetX
            // 
            this.nudOffsetX.Location = new System.Drawing.Point(48, 22);
            this.nudOffsetX.Maximum = new decimal(new int[] {
            2048,
            0,
            0,
            0});
            this.nudOffsetX.Name = "nudOffsetX";
            this.nudOffsetX.Size = new System.Drawing.Size(44, 23);
            this.nudOffsetX.TabIndex = 12;
            this.nudOffsetX.Value = new decimal(new int[] {
            273,
            0,
            0,
            0});
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(0, 152);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(44, 15);
            this.label9.TabIndex = 10;
            this.label9.Text = "Point4:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(0, 121);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(44, 15);
            this.label8.TabIndex = 8;
            this.label8.Text = "Point3:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(0, 92);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(44, 15);
            this.label7.TabIndex = 4;
            this.label7.Text = "Point2:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(0, 61);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(44, 15);
            this.label6.TabIndex = 2;
            this.label6.Text = "Point1:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(0, 24);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(42, 15);
            this.label5.TabIndex = 0;
            this.label5.Text = "Offset:";
            // 
            // btnStartTestB
            // 
            this.btnStartTestB.Location = new System.Drawing.Point(10, 518);
            this.btnStartTestB.Name = "btnStartTestB";
            this.btnStartTestB.Size = new System.Drawing.Size(143, 31);
            this.btnStartTestB.TabIndex = 19;
            this.btnStartTestB.Text = "Start Test Right";
            this.btnStartTestB.UseVisualStyleBackColor = true;
            this.btnStartTestB.Click += new System.EventHandler(this.btnStartTestB_Click);
            // 
            // btnRight
            // 
            this.btnRight.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnRight.Location = new System.Drawing.Point(89, 400);
            this.btnRight.Name = "btnRight";
            this.btnRight.Size = new System.Drawing.Size(64, 31);
            this.btnRight.TabIndex = 18;
            this.btnRight.Text = ">";
            this.btnRight.UseVisualStyleBackColor = true;
            this.btnRight.Click += new System.EventHandler(this.btnRight_Click);
            // 
            // btnLeft
            // 
            this.btnLeft.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnLeft.Location = new System.Drawing.Point(12, 400);
            this.btnLeft.Name = "btnLeft";
            this.btnLeft.Size = new System.Drawing.Size(64, 31);
            this.btnLeft.TabIndex = 17;
            this.btnLeft.Text = "<";
            this.btnLeft.UseVisualStyleBackColor = true;
            this.btnLeft.Click += new System.EventHandler(this.btnLeft_Click);
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
            this.btnAcknowledge.BackColor = System.Drawing.Color.Red;
            this.btnAcknowledge.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnAcknowledge.ForeColor = System.Drawing.Color.White;
            this.btnAcknowledge.Location = new System.Drawing.Point(12, 445);
            this.btnAcknowledge.Name = "btnAcknowledge";
            this.btnAcknowledge.Size = new System.Drawing.Size(141, 31);
            this.btnAcknowledge.TabIndex = 14;
            this.btnAcknowledge.Text = "Acknowledge";
            this.btnAcknowledge.UseVisualStyleBackColor = false;
            this.btnAcknowledge.Click += new System.EventHandler(this.btnAcknowledge_Click);
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
            this.txtCounter.Location = new System.Drawing.Point(10, 157);
            this.txtCounter.Name = "txtCounter";
            this.txtCounter.ReadOnly = true;
            this.txtCounter.Size = new System.Drawing.Size(141, 23);
            this.txtCounter.TabIndex = 10;
            this.txtCounter.Text = "0";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(10, 139);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(132, 15);
            this.label3.TabIndex = 9;
            this.label3.Text = "Counter Unit Produced:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 90);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(122, 15);
            this.label2.TabIndex = 8;
            this.label2.Text = "Produce No. Of Units:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 34);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(95, 15);
            this.label1.TabIndex = 7;
            this.label1.Text = "Model Selection:";
            // 
            // nudUnit
            // 
            this.nudUnit.Location = new System.Drawing.Point(12, 108);
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
            "1001",
            "9001",
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
            this.cboModel.Location = new System.Drawing.Point(10, 52);
            this.cboModel.Name = "cboModel";
            this.cboModel.Size = new System.Drawing.Size(143, 23);
            this.cboModel.TabIndex = 4;
            // 
            // btnStartCalibrate
            // 
            this.btnStartCalibrate.Location = new System.Drawing.Point(10, 592);
            this.btnStartCalibrate.Name = "btnStartCalibrate";
            this.btnStartCalibrate.Size = new System.Drawing.Size(143, 31);
            this.btnStartCalibrate.TabIndex = 3;
            this.btnStartCalibrate.Text = "Start Cablirate";
            this.btnStartCalibrate.UseVisualStyleBackColor = true;
            this.btnStartCalibrate.Visible = false;
            this.btnStartCalibrate.Click += new System.EventHandler(this.btnStartCalibrate_Click);
            // 
            // btnInitialize
            // 
            this.btnInitialize.Location = new System.Drawing.Point(10, 195);
            this.btnInitialize.Name = "btnInitialize";
            this.btnInitialize.Size = new System.Drawing.Size(143, 31);
            this.btnInitialize.TabIndex = 2;
            this.btnInitialize.Text = "Initialize";
            this.btnInitialize.UseVisualStyleBackColor = true;
            this.btnInitialize.Click += new System.EventHandler(this.btnInitialize_Click);
            // 
            // btnPause
            // 
            this.btnPause.Location = new System.Drawing.Point(12, 555);
            this.btnPause.Name = "btnPause";
            this.btnPause.Size = new System.Drawing.Size(141, 31);
            this.btnPause.TabIndex = 1;
            this.btnPause.Text = "Pause";
            this.btnPause.UseVisualStyleBackColor = true;
            this.btnPause.Visible = false;
            this.btnPause.Click += new System.EventHandler(this.BtnPause_Click);
            // 
            // btnStartTestA
            // 
            this.btnStartTestA.Location = new System.Drawing.Point(10, 482);
            this.btnStartTestA.Name = "btnStartTestA";
            this.btnStartTestA.Size = new System.Drawing.Size(143, 31);
            this.btnStartTestA.TabIndex = 0;
            this.btnStartTestA.Text = "Start Test Left";
            this.btnStartTestA.UseVisualStyleBackColor = true;
            this.btnStartTestA.Click += new System.EventHandler(this.BtnStartTestA_Click);
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1383, 898);
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
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cameraImageBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cameraImageBox2)).EndInit();
            this.grpPoloygon.ResumeLayout(false);
            this.grpPoloygon.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudPt4Y)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudPt4X)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudPt3Y)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudPt3X)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudPt2Y)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudPt2X)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudPt1Y)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudPt1X)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudOffsetY)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudOffsetX)).EndInit();
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
        private Button btnStartTestA;
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
        private TextBox lblWarning;
        private Button btnLeft;
        private Button btnRight;
        private Emgu.CV.UI.ImageBox cameraImageBox2;
        private Button btnStartTestB;
        private GroupBox grpPoloygon;
        private Label label5;
        private Label label9;
        private Label label8;
        private Label label7;
        private Label label6;
        private NumericUpDown nudOffsetY;
        private NumericUpDown nudOffsetX;
        private NumericUpDown nudPt2Y;
        private NumericUpDown nudPt2X;
        private NumericUpDown nudPt1Y;
        private NumericUpDown nudPt1X;
        private NumericUpDown nudPt4Y;
        private NumericUpDown nudPt4X;
        private NumericUpDown nudPt3Y;
        private NumericUpDown nudPt3X;
    }
}