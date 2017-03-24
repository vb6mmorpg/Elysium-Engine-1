namespace AccountEditor {
    partial class MainForm {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
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
        private void InitializeComponent() {
            this.darkTitle1 = new DarkUI.Controls.DarkTitle();
            this.btn_new = new DarkUI.Controls.DarkButton();
            this.btn_edit = new DarkUI.Controls.DarkButton();
            this.darkTitle2 = new DarkUI.Controls.DarkTitle();
            this.SuspendLayout();
            // 
            // darkTitle1
            // 
            this.darkTitle1.Font = new System.Drawing.Font("Meiryo UI", 9F);
            this.darkTitle1.Location = new System.Drawing.Point(22, 9);
            this.darkTitle1.Name = "darkTitle1";
            this.darkTitle1.Size = new System.Drawing.Size(417, 16);
            this.darkTitle1.TabIndex = 0;
            this.darkTitle1.Text = "O que deseja fazer?";
            // 
            // btn_new
            // 
            this.btn_new.Font = new System.Drawing.Font("Meiryo UI", 9F);
            this.btn_new.Location = new System.Drawing.Point(51, 37);
            this.btn_new.Name = "btn_new";
            this.btn_new.Padding = new System.Windows.Forms.Padding(5);
            this.btn_new.Size = new System.Drawing.Size(353, 23);
            this.btn_new.TabIndex = 1;
            this.btn_new.Text = "Inserir um novo usuário";
            this.btn_new.Click += new System.EventHandler(this.btn_new_Click);
            // 
            // btn_edit
            // 
            this.btn_edit.Font = new System.Drawing.Font("Meiryo UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.btn_edit.Location = new System.Drawing.Point(51, 76);
            this.btn_edit.Name = "btn_edit";
            this.btn_edit.Padding = new System.Windows.Forms.Padding(5);
            this.btn_edit.Size = new System.Drawing.Size(353, 23);
            this.btn_edit.TabIndex = 2;
            this.btn_edit.Text = "Alterar um usuário";
            this.btn_edit.Click += new System.EventHandler(this.btn_edit_Click);
            // 
            // darkTitle2
            // 
            this.darkTitle2.Location = new System.Drawing.Point(22, 118);
            this.darkTitle2.Name = "darkTitle2";
            this.darkTitle2.Size = new System.Drawing.Size(417, 10);
            this.darkTitle2.TabIndex = 3;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(471, 139);
            this.Controls.Add(this.darkTitle2);
            this.Controls.Add(this.btn_edit);
            this.Controls.Add(this.btn_new);
            this.Controls.Add(this.darkTitle1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Editor de Usuário";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private DarkUI.Controls.DarkTitle darkTitle1;
        private DarkUI.Controls.DarkButton btn_new;
        private DarkUI.Controls.DarkButton btn_edit;
        private DarkUI.Controls.DarkTitle darkTitle2;
    }
}