namespace WinformRopeRounding
{
    partial class FormRoiEditor
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
            this.ucEditor = new WinformRopeRounding.UserControls.ucPtzRoiEditor();
            this.SuspendLayout();
            // 
            // ucEditor
            // 
            this.ucEditor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucEditor.Location = new System.Drawing.Point(0, 0);
            this.ucEditor.Name = "ucEditor";
            this.ucEditor.Size = new System.Drawing.Size(800, 551);
            this.ucEditor.TabIndex = 0;
            // 
            // FormRoiEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 551);
            this.Controls.Add(this.ucEditor);
            this.Name = "FormRoiEditor";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FormRoiEditor";
            this.Load += new System.EventHandler(this.FormRoiEditor_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private UserControls.ucPtzRoiEditor ucEditor;
    }
}