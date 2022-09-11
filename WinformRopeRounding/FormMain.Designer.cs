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
            this.btnStartCalibrate = new System.Windows.Forms.Button();
            this.btnInitialize = new System.Windows.Forms.Button();
            this.btnPause = new System.Windows.Forms.Button();
            this.btnStart = new System.Windows.Forms.Button();
            this.msMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cameraImageBox1)).BeginInit();
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
            this.colorSpacePickerToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.colorSpacePickerToolStripMenuItem.Text = "Color Space &Picker";
            this.colorSpacePickerToolStripMenuItem.Click += new System.EventHandler(this.colorSpacePickerToolStripMenuItem_Click);
            // 
            // configEditorToolStripMenuItem
            // 
            this.configEditorToolStripMenuItem.Name = "configEditorToolStripMenuItem";
            this.configEditorToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
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
            this.splitContainer1.Panel2.Controls.Add(this.btnStartCalibrate);
            this.splitContainer1.Panel2.Controls.Add(this.btnInitialize);
            this.splitContainer1.Panel2.Controls.Add(this.btnPause);
            this.splitContainer1.Panel2.Controls.Add(this.btnStart);
            this.splitContainer1.Size = new System.Drawing.Size(974, 592);
            this.splitContainer1.SplitterDistance = 814;
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
            this.tableLayoutPanel1.Size = new System.Drawing.Size(814, 592);
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
            this.cameraImageBox1.Size = new System.Drawing.Size(808, 405);
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
            this.txtDebug.Size = new System.Drawing.Size(806, 175);
            this.txtDebug.TabIndex = 3;
            // 
            // btnStartCalibrate
            // 
            this.btnStartCalibrate.Location = new System.Drawing.Point(10, 148);
            this.btnStartCalibrate.Name = "btnStartCalibrate";
            this.btnStartCalibrate.Size = new System.Drawing.Size(134, 31);
            this.btnStartCalibrate.TabIndex = 3;
            this.btnStartCalibrate.Text = "Start Cablirate";
            this.btnStartCalibrate.UseVisualStyleBackColor = true;
            this.btnStartCalibrate.Click += new System.EventHandler(this.btnStartCalibrate_Click);
            // 
            // btnInitialize
            // 
            this.btnInitialize.Location = new System.Drawing.Point(10, 14);
            this.btnInitialize.Name = "btnInitialize";
            this.btnInitialize.Size = new System.Drawing.Size(134, 31);
            this.btnInitialize.TabIndex = 2;
            this.btnInitialize.Text = "Initialize";
            this.btnInitialize.UseVisualStyleBackColor = true;
            this.btnInitialize.Click += new System.EventHandler(this.btnInitialize_Click);
            // 
            // btnPause
            // 
            this.btnPause.Location = new System.Drawing.Point(10, 88);
            this.btnPause.Name = "btnPause";
            this.btnPause.Size = new System.Drawing.Size(134, 31);
            this.btnPause.TabIndex = 1;
            this.btnPause.Text = "Pause";
            this.btnPause.UseVisualStyleBackColor = true;
            this.btnPause.Click += new System.EventHandler(this.BtnPause_Click);
            // 
            // btnStart
            // 
            this.btnStart.Location = new System.Drawing.Point(10, 51);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(134, 31);
            this.btnStart.TabIndex = 0;
            this.btnStart.Text = "Start";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.BtnStart_Click);
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
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.cameraImageBox1)).EndInit();
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
        private Button btnStart;
        private Emgu.CV.UI.ImageBox cameraImageBox1;
        private ToolStripMenuItem toolsToolStripMenuItem;
        private ToolStripMenuItem colorSpacePickerToolStripMenuItem;
        private Serilog.Sinks.WinForms.Core.SimpleLogTextBox txtDebug;
        private Button btnInitialize;
        private Button btnStartCalibrate;
        private ToolStripMenuItem configEditorToolStripMenuItem;
    }
}