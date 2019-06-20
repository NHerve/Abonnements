namespace MagGestion.Forms
{
    partial class LoginForm
    {
        /// <summary>
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur Windows Form

        /// <summary>
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            this.TBLogin = new System.Windows.Forms.TextBox();
            this.TBPassword = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.BTConnection = new System.Windows.Forms.Button();
            this.BTQuit = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // TBLogin
            // 
            this.TBLogin.BackColor = System.Drawing.SystemColors.HighlightText;
            this.TBLogin.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.TBLogin.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TBLogin.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.TBLogin.Location = new System.Drawing.Point(86, 74);
            this.TBLogin.MaxLength = 50;
            this.TBLogin.Name = "TBLogin";
            this.TBLogin.Size = new System.Drawing.Size(322, 37);
            this.TBLogin.TabIndex = 0;
            // 
            // TBPassword
            // 
            this.TBPassword.BackColor = System.Drawing.SystemColors.HighlightText;
            this.TBPassword.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.TBPassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TBPassword.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.TBPassword.Location = new System.Drawing.Point(86, 198);
            this.TBPassword.MaxLength = 50;
            this.TBPassword.Name = "TBPassword";
            this.TBPassword.Size = new System.Drawing.Size(322, 37);
            this.TBPassword.TabIndex = 1;
            this.TBPassword.UseSystemPasswordChar = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.Highlight;
            this.label1.Location = new System.Drawing.Point(80, 42);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(73, 29);
            this.label1.TabIndex = 2;
            this.label1.Text = "Login";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.Highlight;
            this.label2.Location = new System.Drawing.Point(80, 168);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(170, 29);
            this.label2.TabIndex = 3;
            this.label2.Text = "Mots de passe";
            // 
            // BTConnection
            // 
            this.BTConnection.BackColor = System.Drawing.SystemColors.Highlight;
            this.BTConnection.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.BTConnection.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BTConnection.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.BTConnection.Location = new System.Drawing.Point(86, 262);
            this.BTConnection.Name = "BTConnection";
            this.BTConnection.Size = new System.Drawing.Size(322, 69);
            this.BTConnection.TabIndex = 4;
            this.BTConnection.Text = "Se connecter";
            this.BTConnection.UseVisualStyleBackColor = false;
            this.BTConnection.Click += new System.EventHandler(this.BTConnection_Click);
            // 
            // BTQuit
            // 
            this.BTQuit.BackColor = System.Drawing.Color.Red;
            this.BTQuit.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.BTQuit.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BTQuit.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.BTQuit.Location = new System.Drawing.Point(86, 343);
            this.BTQuit.Name = "BTQuit";
            this.BTQuit.Size = new System.Drawing.Size(322, 69);
            this.BTQuit.TabIndex = 5;
            this.BTQuit.Text = "Quitter";
            this.BTQuit.UseVisualStyleBackColor = false;
            this.BTQuit.Click += new System.EventHandler(this.BTQuit_Click);
            // 
            // LoginForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(494, 492);
            this.Controls.Add(this.BTQuit);
            this.Controls.Add(this.BTConnection);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.TBPassword);
            this.Controls.Add(this.TBLogin);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "LoginForm";
            this.Load += new System.EventHandler(this.LoginForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox TBLogin;
        private System.Windows.Forms.TextBox TBPassword;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button BTConnection;
        private System.Windows.Forms.Button BTQuit;
    }
}

