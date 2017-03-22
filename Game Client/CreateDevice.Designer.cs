namespace Elysium_Diamond
{
    partial class CreateDevice
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CreateDevice));
            this.SuspendLayout();
            // 
            // CreateDevice
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(1008, 681);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.Name = "CreateDevice";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Elysium Diamond";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.CreateDevice_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.CreateDevice_FormClosed);
            this.Load += new System.EventHandler(this.CreateDevice_Load);
            this.InputLanguageChanged += new System.Windows.Forms.InputLanguageChangedEventHandler(this.CreateDevice_InputLanguageChanged);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.CreateDevice_KeyDown);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.CreateDevice_KeyPress);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.CreateDevice_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.CreateDevice_MouseMove);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.CreateDevice_MouseUp);
            this.ImeModeChanged += new System.EventHandler(this.CreateDevice_ImeModeChanged);
            this.ResumeLayout(false);

        }

        #endregion

    }
}

