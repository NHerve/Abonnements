namespace MagGestion.Forms
{
    partial class ClientForm
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
            this.BTQuit = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lbPrenom = new System.Windows.Forms.Label();
            this.lbNom = new System.Windows.Forms.Label();
            this.BTCourrier = new System.Windows.Forms.Button();
            this.BTMail = new System.Windows.Forms.Button();
            this.BTTelephone = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.lbBirthday = new System.Windows.Forms.Label();
            this.lbTelephone = new System.Windows.Forms.Label();
            this.lbMail = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // BTQuit
            // 
            this.BTQuit.BackColor = System.Drawing.SystemColors.Highlight;
            this.BTQuit.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.BTQuit.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BTQuit.ForeColor = System.Drawing.Color.White;
            this.BTQuit.Location = new System.Drawing.Point(417, 288);
            this.BTQuit.Margin = new System.Windows.Forms.Padding(2);
            this.BTQuit.Name = "BTQuit";
            this.BTQuit.Size = new System.Drawing.Size(105, 40);
            this.BTQuit.TabIndex = 0;
            this.BTQuit.Text = "Quitter";
            this.BTQuit.UseVisualStyleBackColor = false;
            this.BTQuit.Click += new System.EventHandler(this.BTQuit_click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.Highlight;
            this.label1.Location = new System.Drawing.Point(8, 20);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(82, 29);
            this.label1.TabIndex = 1;
            this.label1.Text = "Nom :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.Highlight;
            this.label2.Location = new System.Drawing.Point(8, 60);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(118, 29);
            this.label2.TabIndex = 2;
            this.label2.Text = "Prenom :";
            // 
            // lbPrenom
            // 
            this.lbPrenom.AutoSize = true;
            this.lbPrenom.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbPrenom.Location = new System.Drawing.Point(126, 65);
            this.lbPrenom.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbPrenom.Name = "lbPrenom";
            this.lbPrenom.Size = new System.Drawing.Size(166, 20);
            this.lbPrenom.TabIndex = 3;
            this.lbPrenom.Text = "Emplacement Prenom";
            // 
            // lbNom
            // 
            this.lbNom.AutoSize = true;
            this.lbNom.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbNom.Location = new System.Drawing.Point(91, 27);
            this.lbNom.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbNom.Name = "lbNom";
            this.lbNom.Size = new System.Drawing.Size(144, 20);
            this.lbNom.TabIndex = 4;
            this.lbNom.Text = "Emplacement Nom";
            // 
            // BTCourrier
            // 
            this.BTCourrier.BackColor = System.Drawing.Color.Chocolate;
            this.BTCourrier.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.BTCourrier.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BTCourrier.ForeColor = System.Drawing.Color.White;
            this.BTCourrier.Location = new System.Drawing.Point(10, 288);
            this.BTCourrier.Name = "BTCourrier";
            this.BTCourrier.Size = new System.Drawing.Size(120, 40);
            this.BTCourrier.TabIndex = 6;
            this.BTCourrier.Text = "Courrier";
            this.BTCourrier.UseVisualStyleBackColor = false;
            // 
            // BTMail
            // 
            this.BTMail.BackColor = System.Drawing.Color.Chocolate;
            this.BTMail.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.BTMail.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BTMail.ForeColor = System.Drawing.Color.White;
            this.BTMail.Location = new System.Drawing.Point(136, 288);
            this.BTMail.Name = "BTMail";
            this.BTMail.Size = new System.Drawing.Size(120, 40);
            this.BTMail.TabIndex = 7;
            this.BTMail.Text = "E-mail";
            this.BTMail.UseVisualStyleBackColor = false;
            // 
            // BTTelephone
            // 
            this.BTTelephone.BackColor = System.Drawing.Color.Chocolate;
            this.BTTelephone.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.BTTelephone.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BTTelephone.ForeColor = System.Drawing.Color.White;
            this.BTTelephone.Location = new System.Drawing.Point(262, 288);
            this.BTTelephone.Name = "BTTelephone";
            this.BTTelephone.Size = new System.Drawing.Size(120, 40);
            this.BTTelephone.TabIndex = 8;
            this.BTTelephone.Text = "Téléphone";
            this.BTTelephone.UseVisualStyleBackColor = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Chocolate;
            this.label3.Location = new System.Drawing.Point(8, 247);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(201, 29);
            this.label3.TabIndex = 9;
            this.label3.Text = "Relation client : ";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.SystemColors.Highlight;
            this.label4.Location = new System.Drawing.Point(11, 180);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(242, 29);
            this.label4.TabIndex = 10;
            this.label4.Text = "Date de naissance :";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.SystemColors.Highlight;
            this.label5.Location = new System.Drawing.Point(8, 100);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(154, 29);
            this.label5.TabIndex = 11;
            this.label5.Text = "Téléphone :";
            // 
            // lbBirthday
            // 
            this.lbBirthday.AutoSize = true;
            this.lbBirthday.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbBirthday.Location = new System.Drawing.Point(258, 187);
            this.lbBirthday.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbBirthday.Name = "lbBirthday";
            this.lbBirthday.Size = new System.Drawing.Size(222, 20);
            this.lbBirthday.TabIndex = 12;
            this.lbBirthday.Text = "Emplacement Date naissance";
            // 
            // lbTelephone
            // 
            this.lbTelephone.AutoSize = true;
            this.lbTelephone.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTelephone.Location = new System.Drawing.Point(166, 107);
            this.lbTelephone.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbTelephone.Name = "lbTelephone";
            this.lbTelephone.Size = new System.Drawing.Size(186, 20);
            this.lbTelephone.TabIndex = 13;
            this.lbTelephone.Text = "Emplacement Téléphone";
            // 
            // lbMail
            // 
            this.lbMail.AutoSize = true;
            this.lbMail.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbMail.Location = new System.Drawing.Point(88, 147);
            this.lbMail.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbMail.Name = "lbMail";
            this.lbMail.Size = new System.Drawing.Size(139, 20);
            this.lbMail.TabIndex = 15;
            this.lbMail.Text = "Emplacement Mail";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.SystemColors.Highlight;
            this.label9.Location = new System.Drawing.Point(8, 140);
            this.label9.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(76, 29);
            this.label9.TabIndex = 14;
            this.label9.Text = "Mail :";
            // 
            // ClientForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(533, 339);
            this.Controls.Add(this.lbMail);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.lbTelephone);
            this.Controls.Add(this.lbBirthday);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.BTTelephone);
            this.Controls.Add(this.BTMail);
            this.Controls.Add(this.BTCourrier);
            this.Controls.Add(this.lbNom);
            this.Controls.Add(this.lbPrenom);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.BTQuit);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "ClientForm";
            this.Text = "ClientForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button BTQuit;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lbPrenom;
        private System.Windows.Forms.Label lbNom;
        private System.Windows.Forms.Button BTCourrier;
        private System.Windows.Forms.Button BTMail;
        private System.Windows.Forms.Button BTTelephone;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lbBirthday;
        private System.Windows.Forms.Label lbTelephone;
        private System.Windows.Forms.Label lbMail;
        private System.Windows.Forms.Label label9;
    }
}