namespace WinformRopeRounding.UserControls
{
    partial class ucPtzRoiEditor
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.TreeView = new System.Windows.Forms.TreeView();
            this.pnlSave = new System.Windows.Forms.Panel();
            this.lblLocation = new System.Windows.Forms.Label();
            this.cbShowValue = new System.Windows.Forms.CheckBox();
            this.pbImage = new WinformRopeRounding.UserControls.PtzPictureBoxEx();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnEdit = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnZoomIn = new System.Windows.Forms.Button();
            this.btnAutoFit = new System.Windows.Forms.Button();
            this.btnZoomOut = new System.Windows.Forms.Button();
            this.pnlSave.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // TreeView
            // 
            this.TreeView.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.TreeView.Location = new System.Drawing.Point(3, 3);
            this.TreeView.Name = "TreeView";
            this.TreeView.Size = new System.Drawing.Size(320, 480);
            this.TreeView.TabIndex = 0;
            // 
            // pnlSave
            // 
            this.pnlSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.pnlSave.Controls.Add(this.btnSave);
            this.pnlSave.Controls.Add(this.btnEdit);
            this.pnlSave.Controls.Add(this.btnClear);
            this.pnlSave.Controls.Add(this.groupBox1);
            this.pnlSave.Controls.Add(this.lblLocation);
            this.pnlSave.Controls.Add(this.cbShowValue);
            this.pnlSave.Location = new System.Drawing.Point(3, 489);
            this.pnlSave.Name = "pnlSave";
            this.pnlSave.Size = new System.Drawing.Size(320, 128);
            this.pnlSave.TabIndex = 2;
            // 
            // lblLocation
            // 
            this.lblLocation.AutoSize = true;
            this.lblLocation.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblLocation.Location = new System.Drawing.Point(3, 105);
            this.lblLocation.Name = "lblLocation";
            this.lblLocation.Size = new System.Drawing.Size(29, 15);
            this.lblLocation.TabIndex = 1;
            this.lblLocation.Text = "Loc:";
            // 
            // cbShowValue
            // 
            this.cbShowValue.AutoSize = true;
            this.cbShowValue.Location = new System.Drawing.Point(200, 105);
            this.cbShowValue.Name = "cbShowValue";
            this.cbShowValue.Size = new System.Drawing.Size(117, 19);
            this.cbShowValue.TabIndex = 0;
            this.cbShowValue.Text = "Show Coordinate";
            this.cbShowValue.UseVisualStyleBackColor = true;
            // 
            // pbImage
            // 
            this.pbImage.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pbImage.DrawMode = 0;
            this.pbImage.EnabledEditMode = false;
            this.pbImage.Location = new System.Drawing.Point(329, 3);
            this.pbImage.Name = "pbImage";
            this.pbImage.Size = new System.Drawing.Size(491, 614);
            this.pbImage.TabIndex = 3;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnZoomOut);
            this.groupBox1.Controls.Add(this.btnAutoFit);
            this.groupBox1.Controls.Add(this.btnZoomIn);
            this.groupBox1.Location = new System.Drawing.Point(3, 41);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(317, 58);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Zoom";
            // 
            // btnClear
            // 
            this.btnClear.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnClear.Location = new System.Drawing.Point(3, 3);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(102, 32);
            this.btnClear.TabIndex = 3;
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = true;
            // 
            // btnEdit
            // 
            this.btnEdit.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnEdit.Location = new System.Drawing.Point(109, 3);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(102, 32);
            this.btnEdit.TabIndex = 4;
            this.btnEdit.Text = "Edit";
            this.btnEdit.UseVisualStyleBackColor = true;
            // 
            // btnSave
            // 
            this.btnSave.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnSave.Location = new System.Drawing.Point(215, 3);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(102, 32);
            this.btnSave.TabIndex = 5;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            // 
            // btnZoomIn
            // 
            this.btnZoomIn.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnZoomIn.Location = new System.Drawing.Point(6, 20);
            this.btnZoomIn.Name = "btnZoomIn";
            this.btnZoomIn.Size = new System.Drawing.Size(96, 32);
            this.btnZoomIn.TabIndex = 4;
            this.btnZoomIn.Text = "+";
            this.btnZoomIn.UseVisualStyleBackColor = true;
            // 
            // btnAutoFit
            // 
            this.btnAutoFit.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnAutoFit.Location = new System.Drawing.Point(112, 20);
            this.btnAutoFit.Name = "btnAutoFit";
            this.btnAutoFit.Size = new System.Drawing.Size(96, 32);
            this.btnAutoFit.TabIndex = 5;
            this.btnAutoFit.Text = "Auto Fit";
            this.btnAutoFit.UseVisualStyleBackColor = true;
            // 
            // btnZoomOut
            // 
            this.btnZoomOut.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnZoomOut.Location = new System.Drawing.Point(218, 20);
            this.btnZoomOut.Name = "btnZoomOut";
            this.btnZoomOut.Size = new System.Drawing.Size(96, 32);
            this.btnZoomOut.TabIndex = 6;
            this.btnZoomOut.Text = "-";
            this.btnZoomOut.UseVisualStyleBackColor = true;
            // 
            // ucPtzRoiEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pbImage);
            this.Controls.Add(this.pnlSave);
            this.Controls.Add(this.TreeView);
            this.Name = "ucPtzRoiEditor";
            this.Size = new System.Drawing.Size(823, 617);
            this.pnlSave.ResumeLayout(false);
            this.pnlSave.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private TreeView TreeView;
        private Panel pnlSave;
        private Label lblLocation;
        private CheckBox cbShowValue;
        private PtzPictureBoxEx pbImage;
        private GroupBox groupBox1;
        private Button btnSave;
        private Button btnEdit;
        private Button btnClear;
        private Button btnZoomOut;
        private Button btnAutoFit;
        private Button btnZoomIn;
    }
}
