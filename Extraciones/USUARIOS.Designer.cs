namespace Extraciones
{
    partial class USUARIOS
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(USUARIOS));
            this.TXTUSUARIO = new System.Windows.Forms.TextBox();
            this.LBUSUARIO = new System.Windows.Forms.Label();
            this.TXTCONTRASEÑA = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.LOGIN = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // TXTUSUARIO
            // 
            this.TXTUSUARIO.Location = new System.Drawing.Point(96, 30);
            this.TXTUSUARIO.Name = "TXTUSUARIO";
            this.TXTUSUARIO.Size = new System.Drawing.Size(100, 20);
            this.TXTUSUARIO.TabIndex = 0;
            this.TXTUSUARIO.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TXTUSUARIO_KeyPress);
            // 
            // LBUSUARIO
            // 
            this.LBUSUARIO.AutoSize = true;
            this.LBUSUARIO.Location = new System.Drawing.Point(12, 33);
            this.LBUSUARIO.Name = "LBUSUARIO";
            this.LBUSUARIO.Size = new System.Drawing.Size(56, 13);
            this.LBUSUARIO.TabIndex = 1;
            this.LBUSUARIO.Text = "USUARIO";
            // 
            // TXTCONTRASEÑA
            // 
            this.TXTCONTRASEÑA.Location = new System.Drawing.Point(96, 57);
            this.TXTCONTRASEÑA.Multiline = true;
            this.TXTCONTRASEÑA.Name = "TXTCONTRASEÑA";
            this.TXTCONTRASEÑA.PasswordChar = '*';
            this.TXTCONTRASEÑA.Size = new System.Drawing.Size(100, 20);
            this.TXTCONTRASEÑA.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 61);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(81, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "CONTRASEÑA";
            // 
            // LOGIN
            // 
            this.LOGIN.Location = new System.Drawing.Point(177, 87);
            this.LOGIN.Name = "LOGIN";
            this.LOGIN.Size = new System.Drawing.Size(75, 23);
            this.LOGIN.TabIndex = 4;
            this.LOGIN.Text = "LOGIN";
            this.LOGIN.UseVisualStyleBackColor = true;
            this.LOGIN.Click += new System.EventHandler(this.LOGIN_Click);
            // 
            // USUARIOS
            // 
            this.AcceptButton = this.LOGIN;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(264, 119);
            this.Controls.Add(this.LOGIN);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.TXTCONTRASEÑA);
            this.Controls.Add(this.LBUSUARIO);
            this.Controls.Add(this.TXTUSUARIO);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Location = new System.Drawing.Point(500, 500);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "USUARIOS";
            this.Text = "USUARIOS";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox TXTUSUARIO;
        private System.Windows.Forms.Label LBUSUARIO;
        private System.Windows.Forms.TextBox TXTCONTRASEÑA;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button LOGIN;
    }
}