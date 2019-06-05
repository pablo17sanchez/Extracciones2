namespace Extraciones
{
    partial class CAMBIAR_CONTRASEÑA
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
            this.TXTUSUARIO = new System.Windows.Forms.TextBox();
            this.TXTPASSWORD = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.TXTNEWPASSWORD = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // TXTUSUARIO
            // 
            this.TXTUSUARIO.Location = new System.Drawing.Point(113, 28);
            this.TXTUSUARIO.Name = "TXTUSUARIO";
            this.TXTUSUARIO.Size = new System.Drawing.Size(110, 20);
            this.TXTUSUARIO.TabIndex = 0;
            this.TXTUSUARIO.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TXTUSUARIO_KeyPress);
            // 
            // TXTPASSWORD
            // 
            this.TXTPASSWORD.Location = new System.Drawing.Point(113, 67);
            this.TXTPASSWORD.Name = "TXTPASSWORD";
            this.TXTPASSWORD.PasswordChar = '*';
            this.TXTPASSWORD.Size = new System.Drawing.Size(110, 20);
            this.TXTPASSWORD.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "USUARIO";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 74);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(95, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "OLD PASSWORD";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 114);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(99, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "NEW PASSWORD";
            // 
            // TXTNEWPASSWORD
            // 
            this.TXTNEWPASSWORD.Location = new System.Drawing.Point(113, 107);
            this.TXTNEWPASSWORD.Name = "TXTNEWPASSWORD";
            this.TXTNEWPASSWORD.PasswordChar = '*';
            this.TXTNEWPASSWORD.Size = new System.Drawing.Size(110, 20);
            this.TXTNEWPASSWORD.TabIndex = 5;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(15, 162);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 6;
            this.button1.Text = "CAMBIAR";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // CAMBIAR_CONTRASEÑA
            // 
            this.AcceptButton = this.button1;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(284, 197);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.TXTNEWPASSWORD);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.TXTPASSWORD);
            this.Controls.Add(this.TXTUSUARIO);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "CAMBIAR_CONTRASEÑA";
            this.Text = "CAMBIAR_CONTRASEÑA";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox TXTUSUARIO;
        private System.Windows.Forms.TextBox TXTPASSWORD;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox TXTNEWPASSWORD;
        private System.Windows.Forms.Button button1;
    }
}