namespace WinformRopeRounding
{
    partial class FormCamCalibration
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
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.lblMessage = new System.Windows.Forms.Label();
            this.pnlRight = new System.Windows.Forms.TableLayoutPanel();
            this.ucCamPtzPanel1 = new WinformRopeRounding.UserControls.ucCamPtzPanel();
            this.pnlBottomRight = new System.Windows.Forms.Panel();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnGetPosition = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txtValue = new System.Windows.Forms.TextBox();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.pnlRight.SuspendLayout();
            this.pnlBottomRight.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.splitContainer1.IsSplitterFixed = true;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.splitContainer1.Panel1.Controls.Add(this.lblMessage);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.pnlRight);
            this.splitContainer1.Size = new System.Drawing.Size(816, 531);
            this.splitContainer1.SplitterDistance = 618;
            this.splitContainer1.TabIndex = 0;
            // 
            // lblMessage
            // 
            this.lblMessage.AutoSize = true;
            this.lblMessage.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblMessage.Location = new System.Drawing.Point(188, 244);
            this.lblMessage.Name = "lblMessage";
            this.lblMessage.Size = new System.Drawing.Size(235, 24);
            this.lblMessage.TabIndex = 0;
            this.lblMessage.Text = "Loading Video Stream...";
            // 
            // pnlRight
            // 
            this.pnlRight.ColumnCount = 1;
            this.pnlRight.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.pnlRight.Controls.Add(this.ucCamPtzPanel1, 0, 0);
            this.pnlRight.Controls.Add(this.pnlBottomRight, 0, 1);
            this.pnlRight.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlRight.Location = new System.Drawing.Point(0, 0);
            this.pnlRight.Name = "pnlRight";
            this.pnlRight.RowCount = 2;
            this.pnlRight.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 51.22873F));
            this.pnlRight.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 48.77127F));
            this.pnlRight.Size = new System.Drawing.Size(192, 529);
            this.pnlRight.TabIndex = 0;
            // 
            // ucCamPtzPanel1
            // 
            this.ucCamPtzPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucCamPtzPanel1.Location = new System.Drawing.Point(3, 3);
            this.ucCamPtzPanel1.Name = "ucCamPtzPanel1";
            this.ucCamPtzPanel1.Size = new System.Drawing.Size(186, 264);
            this.ucCamPtzPanel1.TabIndex = 0;
            // 
            // pnlBottomRight
            // 
            this.pnlBottomRight.Controls.Add(this.btnCancel);
            this.pnlBottomRight.Controls.Add(this.btnOK);
            this.pnlBottomRight.Controls.Add(this.btnGetPosition);
            this.pnlBottomRight.Controls.Add(this.label1);
            this.pnlBottomRight.Controls.Add(this.txtValue);
            this.pnlBottomRight.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlBottomRight.Location = new System.Drawing.Point(3, 273);
            this.pnlBottomRight.Name = "pnlBottomRight";
            this.pnlBottomRight.Size = new System.Drawing.Size(186, 253);
            this.pnlBottomRight.TabIndex = 1;
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(112, 211);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(66, 25);
            this.btnCancel.TabIndex = 4;
            this.btnCancel.Text = "&Close";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(16, 211);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(66, 25);
            this.btnOK.TabIndex = 3;
            this.btnOK.Text = "&Apply";
            this.btnOK.UseVisualStyleBackColor = true;
            // 
            // btnGetPosition
            // 
            this.btnGetPosition.Location = new System.Drawing.Point(16, 67);
            this.btnGetPosition.Name = "btnGetPosition";
            this.btnGetPosition.Size = new System.Drawing.Size(162, 25);
            this.btnGetPosition.TabIndex = 2;
            this.btnGetPosition.Text = "&Get Current Position";
            this.btnGetPosition.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(134, 15);
            this.label1.TabIndex = 1;
            this.label1.Text = "LOC_Info ( X  Y  Zoom ):";
            // 
            // txtValue
            // 
            this.txtValue.Location = new System.Drawing.Point(16, 38);
            this.txtValue.Name = "txtValue";
            this.txtValue.Size = new System.Drawing.Size(162, 23);
            this.txtValue.TabIndex = 0;
            // 
            // statusStrip1
            // 
            this.statusStrip1.Location = new System.Drawing.Point(0, 534);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(816, 22);
            this.statusStrip1.TabIndex = 1;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // FormCamCalibration
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(816, 556);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.splitContainer1);
            this.Name = "FormCamCalibration";
            this.Text = "FormCamCalibration";
            this.Load += new System.EventHandler(this.FormCamCalibration_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.pnlRight.ResumeLayout(false);
            this.pnlBottomRight.ResumeLayout(false);
            this.pnlBottomRight.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private SplitContainer splitContainer1;
        private StatusStrip statusStrip1;
        private TableLayoutPanel pnlRight;
        private UserControls.ucCamPtzPanel ucCamPtzPanel1;
        private Panel pnlBottomRight;
        private Label label1;
        private TextBox txtValue;
        private Button btnGetPosition;
        private Button btnCancel;
        private Button btnOK;
        private Label lblMessage;
    }
}