namespace WinformRopeRounding.UserControls
{
    partial class ucCamPtzPanel
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.btnDnRight = new System.Windows.Forms.Button();
            this.btnDn = new System.Windows.Forms.Button();
            this.btnDnLeft = new System.Windows.Forms.Button();
            this.btnRight = new System.Windows.Forms.Button();
            this.btnLeft = new System.Windows.Forms.Button();
            this.btnUpRight = new System.Windows.Forms.Button();
            this.btnUp = new System.Windows.Forms.Button();
            this.btnUpLeft = new System.Windows.Forms.Button();
            this.tlpZoom = new System.Windows.Forms.TableLayoutPanel();
            this.btnHome = new System.Windows.Forms.Button();
            this.btnZoomIn = new System.Windows.Forms.Button();
            this.btnZoomOut = new System.Windows.Forms.Button();
            this.tlpFocus = new System.Windows.Forms.TableLayoutPanel();
            this.btnFocusFront = new System.Windows.Forms.Button();
            this.btnFocusBack = new System.Windows.Forms.Button();
            this.tableLayoutPanel1.SuspendLayout();
            this.tlpZoom.SuspendLayout();
            this.tlpFocus.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.Controls.Add(this.btnDnRight, 2, 2);
            this.tableLayoutPanel1.Controls.Add(this.btnDn, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.btnDnLeft, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.btnRight, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.btnLeft, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.btnUpRight, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.btnUp, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.btnUpLeft, 0, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 3);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(188, 195);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // btnDnRight
            // 
            this.btnDnRight.BackColor = System.Drawing.Color.Transparent;
            this.btnDnRight.BackgroundImage = global::WinformRopeRounding.Properties.Resources.Keypad_Right_Dn;
            this.btnDnRight.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnDnRight.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDnRight.Location = new System.Drawing.Point(127, 133);
            this.btnDnRight.Name = "btnDnRight";
            this.btnDnRight.Size = new System.Drawing.Size(56, 58);
            this.btnDnRight.TabIndex = 8;
            this.btnDnRight.Tag = "4";
            this.btnDnRight.UseVisualStyleBackColor = false;
            this.btnDnRight.MouseDown += new System.Windows.Forms.MouseEventHandler(this.BtnMouseDown);
            this.btnDnRight.MouseUp += new System.Windows.Forms.MouseEventHandler(this.BtnMouseUp);
            // 
            // btnDn
            // 
            this.btnDn.BackColor = System.Drawing.Color.Transparent;
            this.btnDn.BackgroundImage = global::WinformRopeRounding.Properties.Resources.Keypad_Dn;
            this.btnDn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnDn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDn.Location = new System.Drawing.Point(65, 133);
            this.btnDn.Name = "btnDn";
            this.btnDn.Size = new System.Drawing.Size(56, 58);
            this.btnDn.TabIndex = 7;
            this.btnDn.Tag = "5";
            this.btnDn.UseVisualStyleBackColor = false;
            this.btnDn.MouseDown += new System.Windows.Forms.MouseEventHandler(this.BtnMouseDown);
            this.btnDn.MouseUp += new System.Windows.Forms.MouseEventHandler(this.BtnMouseUp);
            // 
            // btnDnLeft
            // 
            this.btnDnLeft.BackColor = System.Drawing.Color.Transparent;
            this.btnDnLeft.BackgroundImage = global::WinformRopeRounding.Properties.Resources.Keypad_Left_Dn;
            this.btnDnLeft.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnDnLeft.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDnLeft.Location = new System.Drawing.Point(3, 133);
            this.btnDnLeft.Name = "btnDnLeft";
            this.btnDnLeft.Size = new System.Drawing.Size(56, 58);
            this.btnDnLeft.TabIndex = 6;
            this.btnDnLeft.Tag = "6";
            this.btnDnLeft.UseVisualStyleBackColor = false;
            this.btnDnLeft.MouseDown += new System.Windows.Forms.MouseEventHandler(this.BtnMouseDown);
            this.btnDnLeft.MouseUp += new System.Windows.Forms.MouseEventHandler(this.BtnMouseUp);
            // 
            // btnRight
            // 
            this.btnRight.BackColor = System.Drawing.Color.Transparent;
            this.btnRight.BackgroundImage = global::WinformRopeRounding.Properties.Resources.Keypad_Right;
            this.btnRight.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnRight.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRight.Location = new System.Drawing.Point(127, 68);
            this.btnRight.Name = "btnRight";
            this.btnRight.Size = new System.Drawing.Size(56, 58);
            this.btnRight.TabIndex = 5;
            this.btnRight.Tag = "3";
            this.btnRight.UseVisualStyleBackColor = false;
            this.btnRight.MouseDown += new System.Windows.Forms.MouseEventHandler(this.BtnMouseDown);
            this.btnRight.MouseUp += new System.Windows.Forms.MouseEventHandler(this.BtnMouseUp);
            // 
            // btnLeft
            // 
            this.btnLeft.BackColor = System.Drawing.Color.Transparent;
            this.btnLeft.BackgroundImage = global::WinformRopeRounding.Properties.Resources.Keypad_Left;
            this.btnLeft.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnLeft.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLeft.Location = new System.Drawing.Point(3, 68);
            this.btnLeft.Name = "btnLeft";
            this.btnLeft.Size = new System.Drawing.Size(56, 58);
            this.btnLeft.TabIndex = 3;
            this.btnLeft.Tag = "7";
            this.btnLeft.UseVisualStyleBackColor = false;
            this.btnLeft.MouseDown += new System.Windows.Forms.MouseEventHandler(this.BtnMouseDown);
            this.btnLeft.MouseUp += new System.Windows.Forms.MouseEventHandler(this.BtnMouseUp);
            // 
            // btnUpRight
            // 
            this.btnUpRight.BackColor = System.Drawing.Color.Transparent;
            this.btnUpRight.BackgroundImage = global::WinformRopeRounding.Properties.Resources.Keypad_UpRight;
            this.btnUpRight.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnUpRight.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUpRight.Location = new System.Drawing.Point(127, 3);
            this.btnUpRight.Name = "btnUpRight";
            this.btnUpRight.Size = new System.Drawing.Size(56, 58);
            this.btnUpRight.TabIndex = 2;
            this.btnUpRight.Tag = "2";
            this.btnUpRight.UseVisualStyleBackColor = false;
            this.btnUpRight.MouseDown += new System.Windows.Forms.MouseEventHandler(this.BtnMouseDown);
            this.btnUpRight.MouseUp += new System.Windows.Forms.MouseEventHandler(this.BtnMouseUp);
            // 
            // btnUp
            // 
            this.btnUp.BackColor = System.Drawing.Color.Transparent;
            this.btnUp.BackgroundImage = global::WinformRopeRounding.Properties.Resources.Keypad_Up;
            this.btnUp.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnUp.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUp.Location = new System.Drawing.Point(65, 3);
            this.btnUp.Name = "btnUp";
            this.btnUp.Size = new System.Drawing.Size(56, 58);
            this.btnUp.TabIndex = 1;
            this.btnUp.Tag = "1";
            this.btnUp.UseVisualStyleBackColor = false;
            this.btnUp.MouseDown += new System.Windows.Forms.MouseEventHandler(this.BtnMouseDown);
            this.btnUp.MouseUp += new System.Windows.Forms.MouseEventHandler(this.BtnMouseUp);
            // 
            // btnUpLeft
            // 
            this.btnUpLeft.BackColor = System.Drawing.Color.Transparent;
            this.btnUpLeft.BackgroundImage = global::WinformRopeRounding.Properties.Resources.Keypad_UpLeft;
            this.btnUpLeft.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnUpLeft.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUpLeft.Location = new System.Drawing.Point(3, 3);
            this.btnUpLeft.Name = "btnUpLeft";
            this.btnUpLeft.Size = new System.Drawing.Size(56, 58);
            this.btnUpLeft.TabIndex = 0;
            this.btnUpLeft.Tag = "8";
            this.btnUpLeft.UseVisualStyleBackColor = false;
            this.btnUpLeft.MouseDown += new System.Windows.Forms.MouseEventHandler(this.BtnMouseDown);
            this.btnUpLeft.MouseUp += new System.Windows.Forms.MouseEventHandler(this.BtnMouseUp);
            // 
            // tlpZoom
            // 
            this.tlpZoom.ColumnCount = 3;
            this.tlpZoom.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tlpZoom.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tlpZoom.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tlpZoom.Controls.Add(this.btnHome, 0, 0);
            this.tlpZoom.Controls.Add(this.btnZoomIn, 0, 0);
            this.tlpZoom.Controls.Add(this.btnZoomOut, 0, 0);
            this.tlpZoom.Location = new System.Drawing.Point(0, 204);
            this.tlpZoom.Name = "tlpZoom";
            this.tlpZoom.RowCount = 1;
            this.tlpZoom.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpZoom.Size = new System.Drawing.Size(188, 51);
            this.tlpZoom.TabIndex = 1;
            // 
            // btnHome
            // 
            this.btnHome.BackColor = System.Drawing.Color.Transparent;
            this.btnHome.BackgroundImage = global::WinformRopeRounding.Properties.Resources.Keypad_Home;
            this.btnHome.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnHome.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnHome.Location = new System.Drawing.Point(127, 3);
            this.btnHome.Name = "btnHome";
            this.btnHome.Size = new System.Drawing.Size(56, 45);
            this.btnHome.TabIndex = 9;
            this.btnHome.Tag = "12";
            this.btnHome.UseVisualStyleBackColor = false;
            this.btnHome.Click += new System.EventHandler(this.BtnClick);
            // 
            // btnZoomIn
            // 
            this.btnZoomIn.BackColor = System.Drawing.Color.Transparent;
            this.btnZoomIn.BackgroundImage = global::WinformRopeRounding.Properties.Resources.Keypad_ZoomIn;
            this.btnZoomIn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnZoomIn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnZoomIn.Location = new System.Drawing.Point(65, 3);
            this.btnZoomIn.Name = "btnZoomIn";
            this.btnZoomIn.Size = new System.Drawing.Size(56, 45);
            this.btnZoomIn.TabIndex = 8;
            this.btnZoomIn.Tag = "11";
            this.btnZoomIn.UseVisualStyleBackColor = false;
            this.btnZoomIn.MouseDown += new System.Windows.Forms.MouseEventHandler(this.BtnMouseDown);
            this.btnZoomIn.MouseUp += new System.Windows.Forms.MouseEventHandler(this.BtnMouseUp);
            // 
            // btnZoomOut
            // 
            this.btnZoomOut.BackColor = System.Drawing.Color.Transparent;
            this.btnZoomOut.BackgroundImage = global::WinformRopeRounding.Properties.Resources.Keypad_ZoomOut;
            this.btnZoomOut.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnZoomOut.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnZoomOut.Location = new System.Drawing.Point(3, 3);
            this.btnZoomOut.Name = "btnZoomOut";
            this.btnZoomOut.Size = new System.Drawing.Size(56, 45);
            this.btnZoomOut.TabIndex = 7;
            this.btnZoomOut.Tag = "10";
            this.btnZoomOut.UseVisualStyleBackColor = false;
            this.btnZoomOut.MouseDown += new System.Windows.Forms.MouseEventHandler(this.BtnMouseDown);
            this.btnZoomOut.MouseUp += new System.Windows.Forms.MouseEventHandler(this.BtnMouseUp);
            // 
            // tlpFocus
            // 
            this.tlpFocus.ColumnCount = 3;
            this.tlpFocus.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tlpFocus.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tlpFocus.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tlpFocus.Controls.Add(this.btnFocusFront, 0, 0);
            this.tlpFocus.Controls.Add(this.btnFocusBack, 0, 0);
            this.tlpFocus.Location = new System.Drawing.Point(0, 259);
            this.tlpFocus.Name = "tlpFocus";
            this.tlpFocus.RowCount = 1;
            this.tlpFocus.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpFocus.Size = new System.Drawing.Size(188, 51);
            this.tlpFocus.TabIndex = 3;
            // 
            // btnFocusFront
            // 
            this.btnFocusFront.BackColor = System.Drawing.Color.Transparent;
            this.btnFocusFront.BackgroundImage = global::WinformRopeRounding.Properties.Resources.Keypad_FocusFront;
            this.btnFocusFront.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnFocusFront.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFocusFront.Location = new System.Drawing.Point(65, 3);
            this.btnFocusFront.Name = "btnFocusFront";
            this.btnFocusFront.Size = new System.Drawing.Size(56, 45);
            this.btnFocusFront.TabIndex = 8;
            this.btnFocusFront.Tag = "14";
            this.btnFocusFront.UseVisualStyleBackColor = false;
            this.btnFocusFront.MouseDown += new System.Windows.Forms.MouseEventHandler(this.BtnMouseDown);
            this.btnFocusFront.MouseUp += new System.Windows.Forms.MouseEventHandler(this.BtnMouseUp);
            // 
            // btnFocusBack
            // 
            this.btnFocusBack.BackColor = System.Drawing.Color.Transparent;
            this.btnFocusBack.BackgroundImage = global::WinformRopeRounding.Properties.Resources.Keypad_FocusBack;
            this.btnFocusBack.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnFocusBack.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFocusBack.Location = new System.Drawing.Point(3, 3);
            this.btnFocusBack.Name = "btnFocusBack";
            this.btnFocusBack.Size = new System.Drawing.Size(56, 45);
            this.btnFocusBack.TabIndex = 7;
            this.btnFocusBack.Tag = "13";
            this.btnFocusBack.UseVisualStyleBackColor = false;
            this.btnFocusBack.MouseDown += new System.Windows.Forms.MouseEventHandler(this.BtnMouseDown);
            this.btnFocusBack.MouseUp += new System.Windows.Forms.MouseEventHandler(this.BtnMouseUp);
            // 
            // ucCamPtzPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tlpFocus);
            this.Controls.Add(this.tlpZoom);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "ucCamPtzPanel";
            this.Size = new System.Drawing.Size(188, 313);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tlpZoom.ResumeLayout(false);
            this.tlpFocus.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private TableLayoutPanel tableLayoutPanel1;
        private Button btnUpLeft;
        private Button btnDnRight;
        private Button btnDn;
        private Button btnDnLeft;
        private Button btnRight;
        private Button btnLeft;
        private Button btnUpRight;
        private Button btnUp;
        private TableLayoutPanel tlpZoom;
        private Button btnHome;
        private Button btnZoomIn;
        private Button btnZoomOut;
        private TableLayoutPanel tlpFocus;
        private Button btnFocusFront;
        private Button btnFocusBack;
    }
}
