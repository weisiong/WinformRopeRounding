namespace WinformRopeRounding
{
    partial class FormColorSpacePicker
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
            if (disposing && (components != null))
            {
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
            this.components = new System.ComponentModel.Container();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.imgBoxDst = new Emgu.CV.UI.ImageBox();
            this.imgBoxSrc = new Emgu.CV.UI.ImageBox();
            this.btnCopy = new System.Windows.Forms.Button();
            this.btnDefault = new System.Windows.Forms.Button();
            this.nudVmax = new System.Windows.Forms.NumericUpDown();
            this.nudSmax = new System.Windows.Forms.NumericUpDown();
            this.nudHmax = new System.Windows.Forms.NumericUpDown();
            this.nudVmin = new System.Windows.Forms.NumericUpDown();
            this.nudSmin = new System.Windows.Forms.NumericUpDown();
            this.nudHmin = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tbVmax = new System.Windows.Forms.TrackBar();
            this.tbSmax = new System.Windows.Forms.TrackBar();
            this.tbHmax = new System.Windows.Forms.TrackBar();
            this.tbVmin = new System.Windows.Forms.TrackBar();
            this.tbSmin = new System.Windows.Forms.TrackBar();
            this.tbHmin = new System.Windows.Forms.TrackBar();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imgBoxDst)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgBoxSrc)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudVmax)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudSmax)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudHmax)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudVmin)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudSmin)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudHmin)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbVmax)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbSmax)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbHmax)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbVmin)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbSmin)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbHmin)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.tableLayoutPanel1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.btnCopy);
            this.splitContainer1.Panel2.Controls.Add(this.btnDefault);
            this.splitContainer1.Panel2.Controls.Add(this.nudVmax);
            this.splitContainer1.Panel2.Controls.Add(this.nudSmax);
            this.splitContainer1.Panel2.Controls.Add(this.nudHmax);
            this.splitContainer1.Panel2.Controls.Add(this.nudVmin);
            this.splitContainer1.Panel2.Controls.Add(this.nudSmin);
            this.splitContainer1.Panel2.Controls.Add(this.nudHmin);
            this.splitContainer1.Panel2.Controls.Add(this.label3);
            this.splitContainer1.Panel2.Controls.Add(this.label2);
            this.splitContainer1.Panel2.Controls.Add(this.label1);
            this.splitContainer1.Panel2.Controls.Add(this.tbVmax);
            this.splitContainer1.Panel2.Controls.Add(this.tbSmax);
            this.splitContainer1.Panel2.Controls.Add(this.tbHmax);
            this.splitContainer1.Panel2.Controls.Add(this.tbVmin);
            this.splitContainer1.Panel2.Controls.Add(this.tbSmin);
            this.splitContainer1.Panel2.Controls.Add(this.tbHmin);
            this.splitContainer1.Size = new System.Drawing.Size(1168, 582);
            this.splitContainer1.SplitterDistance = 390;
            this.splitContainer1.TabIndex = 0;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.imgBoxDst, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.imgBoxSrc, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1168, 390);
            this.tableLayoutPanel1.TabIndex = 3;
            // 
            // imgBoxDst
            // 
            this.imgBoxDst.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.imgBoxDst.Dock = System.Windows.Forms.DockStyle.Fill;
            this.imgBoxDst.Location = new System.Drawing.Point(587, 3);
            this.imgBoxDst.Name = "imgBoxDst";
            this.imgBoxDst.Size = new System.Drawing.Size(578, 384);
            this.imgBoxDst.TabIndex = 3;
            this.imgBoxDst.TabStop = false;
            // 
            // imgBoxSrc
            // 
            this.imgBoxSrc.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.imgBoxSrc.Dock = System.Windows.Forms.DockStyle.Fill;
            this.imgBoxSrc.Location = new System.Drawing.Point(3, 3);
            this.imgBoxSrc.Name = "imgBoxSrc";
            this.imgBoxSrc.Size = new System.Drawing.Size(578, 384);
            this.imgBoxSrc.TabIndex = 2;
            this.imgBoxSrc.TabStop = false;
            // 
            // btnCopy
            // 
            this.btnCopy.Location = new System.Drawing.Point(821, 68);
            this.btnCopy.Name = "btnCopy";
            this.btnCopy.Size = new System.Drawing.Size(90, 32);
            this.btnCopy.TabIndex = 16;
            this.btnCopy.Text = "Copy Value";
            this.btnCopy.UseVisualStyleBackColor = true;
            this.btnCopy.Click += new System.EventHandler(this.btnCopy_Click);
            // 
            // btnDefault
            // 
            this.btnDefault.Location = new System.Drawing.Point(821, 17);
            this.btnDefault.Name = "btnDefault";
            this.btnDefault.Size = new System.Drawing.Size(90, 32);
            this.btnDefault.TabIndex = 15;
            this.btnDefault.Text = "Default";
            this.btnDefault.UseVisualStyleBackColor = true;
            this.btnDefault.Click += new System.EventHandler(this.btnDefault_Click);
            // 
            // nudVmax
            // 
            this.nudVmax.Location = new System.Drawing.Point(733, 123);
            this.nudVmax.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.nudVmax.Name = "nudVmax";
            this.nudVmax.Size = new System.Drawing.Size(42, 23);
            this.nudVmax.TabIndex = 14;
            this.nudVmax.Value = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.nudVmax.ValueChanged += new System.EventHandler(this.nudVmax_ValueChanged);
            // 
            // nudSmax
            // 
            this.nudSmax.Location = new System.Drawing.Point(733, 72);
            this.nudSmax.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.nudSmax.Name = "nudSmax";
            this.nudSmax.Size = new System.Drawing.Size(42, 23);
            this.nudSmax.TabIndex = 13;
            this.nudSmax.Value = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.nudSmax.ValueChanged += new System.EventHandler(this.nudSmax_ValueChanged);
            // 
            // nudHmax
            // 
            this.nudHmax.Location = new System.Drawing.Point(733, 21);
            this.nudHmax.Maximum = new decimal(new int[] {
            180,
            0,
            0,
            0});
            this.nudHmax.Name = "nudHmax";
            this.nudHmax.Size = new System.Drawing.Size(42, 23);
            this.nudHmax.TabIndex = 12;
            this.nudHmax.Value = new decimal(new int[] {
            180,
            0,
            0,
            0});
            this.nudHmax.ValueChanged += new System.EventHandler(this.nudHmax_ValueChanged);
            // 
            // nudVmin
            // 
            this.nudVmin.Location = new System.Drawing.Point(355, 126);
            this.nudVmin.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.nudVmin.Name = "nudVmin";
            this.nudVmin.Size = new System.Drawing.Size(42, 23);
            this.nudVmin.TabIndex = 11;
            this.nudVmin.ValueChanged += new System.EventHandler(this.nudVmin_ValueChanged);
            // 
            // nudSmin
            // 
            this.nudSmin.Location = new System.Drawing.Point(355, 75);
            this.nudSmin.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.nudSmin.Name = "nudSmin";
            this.nudSmin.Size = new System.Drawing.Size(42, 23);
            this.nudSmin.TabIndex = 10;
            this.nudSmin.ValueChanged += new System.EventHandler(this.nudSmin_ValueChanged);
            // 
            // nudHmin
            // 
            this.nudHmin.Location = new System.Drawing.Point(355, 24);
            this.nudHmin.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.nudHmin.Name = "nudHmin";
            this.nudHmin.Size = new System.Drawing.Size(42, 23);
            this.nudHmin.TabIndex = 9;
            this.nudHmin.ValueChanged += new System.EventHandler(this.nudHmin_ValueChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label3.Location = new System.Drawing.Point(15, 123);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(21, 21);
            this.label3.TabIndex = 8;
            this.label3.Text = "V";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label2.Location = new System.Drawing.Point(15, 72);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(19, 21);
            this.label2.TabIndex = 7;
            this.label2.Text = "S";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(15, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(22, 21);
            this.label1.TabIndex = 6;
            this.label1.Text = "H";
            // 
            // tbVmax
            // 
            this.tbVmax.Location = new System.Drawing.Point(421, 123);
            this.tbVmax.Maximum = 255;
            this.tbVmax.Name = "tbVmax";
            this.tbVmax.Size = new System.Drawing.Size(306, 45);
            this.tbVmax.TabIndex = 5;
            this.tbVmax.Value = 255;
            this.tbVmax.ValueChanged += new System.EventHandler(this.tbVmax_ValueChanged);
            // 
            // tbSmax
            // 
            this.tbSmax.Location = new System.Drawing.Point(421, 72);
            this.tbSmax.Maximum = 255;
            this.tbSmax.Name = "tbSmax";
            this.tbSmax.Size = new System.Drawing.Size(306, 45);
            this.tbSmax.TabIndex = 4;
            this.tbSmax.Value = 255;
            this.tbSmax.ValueChanged += new System.EventHandler(this.tbSmax_ValueChanged);
            // 
            // tbHmax
            // 
            this.tbHmax.Location = new System.Drawing.Point(421, 21);
            this.tbHmax.Maximum = 180;
            this.tbHmax.Name = "tbHmax";
            this.tbHmax.Size = new System.Drawing.Size(306, 45);
            this.tbHmax.TabIndex = 3;
            this.tbHmax.Value = 180;
            this.tbHmax.ValueChanged += new System.EventHandler(this.tbHmax_ValueChanged);
            // 
            // tbVmin
            // 
            this.tbVmin.Location = new System.Drawing.Point(43, 123);
            this.tbVmin.Maximum = 255;
            this.tbVmin.Name = "tbVmin";
            this.tbVmin.Size = new System.Drawing.Size(306, 45);
            this.tbVmin.TabIndex = 2;
            this.tbVmin.ValueChanged += new System.EventHandler(this.tbVmin_ValueChanged);
            // 
            // tbSmin
            // 
            this.tbSmin.Location = new System.Drawing.Point(43, 72);
            this.tbSmin.Maximum = 255;
            this.tbSmin.Name = "tbSmin";
            this.tbSmin.Size = new System.Drawing.Size(306, 45);
            this.tbSmin.TabIndex = 1;
            this.tbSmin.ValueChanged += new System.EventHandler(this.tbSmin_ValueChanged);
            // 
            // tbHmin
            // 
            this.tbHmin.Location = new System.Drawing.Point(43, 21);
            this.tbHmin.Maximum = 255;
            this.tbHmin.Name = "tbHmin";
            this.tbHmin.Size = new System.Drawing.Size(306, 45);
            this.tbHmin.TabIndex = 0;
            this.tbHmin.ValueChanged += new System.EventHandler(this.tbHmin_ValueChanged);
            // 
            // FormColorSpacePicker
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1168, 582);
            this.Controls.Add(this.splitContainer1);
            this.Name = "FormColorSpacePicker";
            this.Text = "FormColorSpacePicker";
            this.Load += new System.EventHandler(this.FormColorSpacePicker_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.imgBoxDst)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgBoxSrc)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudVmax)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudSmax)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudHmax)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudVmin)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudSmin)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudHmin)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbVmax)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbSmax)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbHmax)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbVmin)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbSmin)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbHmin)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private SplitContainer splitContainer1;
        private Emgu.CV.UI.ImageBox imgBoxSrc;
        private TrackBar tbVmax;
        private TrackBar tbSmax;
        private TrackBar tbHmax;
        private TrackBar tbVmin;
        private TrackBar tbSmin;
        private TrackBar tbHmin;
        private NumericUpDown nudVmax;
        private NumericUpDown nudSmax;
        private NumericUpDown nudHmax;
        private NumericUpDown nudVmin;
        private NumericUpDown nudSmin;
        private NumericUpDown nudHmin;
        private Label label3;
        private Label label2;
        private Label label1;
        private TableLayoutPanel tableLayoutPanel1;
        private Emgu.CV.UI.ImageBox imgBoxDst;
        private Button btnDefault;
        private Button btnCopy;
    }
}