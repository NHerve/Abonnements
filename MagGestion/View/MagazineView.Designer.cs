namespace MagGestion.Forms
{
    partial class MagazineForm
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
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.TBTitre = new System.Windows.Forms.TextBox();
            this.NumericPrice = new System.Windows.Forms.NumericUpDown();
            this.TBDescription = new System.Windows.Forms.TextBox();
            this.BTEnregistrer = new System.Windows.Forms.Button();
            this.NumericNumberPerYear = new System.Windows.Forms.NumericUpDown();
            this.BTSelectImage = new System.Windows.Forms.Button();
            this.PicturePhoto = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.NumericPrice)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NumericNumberPerYear)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PicturePhoto)).BeginInit();
            this.SuspendLayout();
            // 
            // BTQuit
            // 
            this.BTQuit.BackColor = System.Drawing.SystemColors.Highlight;
            this.BTQuit.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.BTQuit.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BTQuit.ForeColor = System.Drawing.Color.White;
            this.BTQuit.Location = new System.Drawing.Point(399, 444);
            this.BTQuit.Name = "BTQuit";
            this.BTQuit.Size = new System.Drawing.Size(135, 45);
            this.BTQuit.TabIndex = 0;
            this.BTQuit.Text = "Fermer";
            this.BTQuit.UseVisualStyleBackColor = false;
            this.BTQuit.Click += new System.EventHandler(this.BTQuit_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.SystemColors.Highlight;
            this.label5.Location = new System.Drawing.Point(8, 320);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(146, 29);
            this.label5.TabIndex = 19;
            this.label5.Text = "Description";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.SystemColors.Highlight;
            this.label4.Location = new System.Drawing.Point(8, 179);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(136, 29);
            this.label4.TabIndex = 18;
            this.label4.Text = "URL photo";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.Highlight;
            this.label2.Location = new System.Drawing.Point(8, 101);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(230, 29);
            this.label2.TabIndex = 15;
            this.label2.Text = "Numéro par année";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.Highlight;
            this.label1.Location = new System.Drawing.Point(11, 20);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(68, 29);
            this.label1.TabIndex = 14;
            this.label1.Text = "Titre";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.Highlight;
            this.label3.Location = new System.Drawing.Point(8, 252);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(143, 29);
            this.label3.TabIndex = 22;
            this.label3.Text = "Prix annuel";
            // 
            // TBTitre
            // 
            this.TBTitre.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.TBTitre.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TBTitre.Location = new System.Drawing.Point(35, 52);
            this.TBTitre.Name = "TBTitre";
            this.TBTitre.Size = new System.Drawing.Size(222, 22);
            this.TBTitre.TabIndex = 23;
            // 
            // NumericPrice
            // 
            this.NumericPrice.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.NumericPrice.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NumericPrice.Location = new System.Drawing.Point(35, 284);
            this.NumericPrice.Name = "NumericPrice";
            this.NumericPrice.Size = new System.Drawing.Size(222, 25);
            this.NumericPrice.TabIndex = 27;
            // 
            // TBDescription
            // 
            this.TBDescription.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TBDescription.Location = new System.Drawing.Point(35, 352);
            this.TBDescription.Multiline = true;
            this.TBDescription.Name = "TBDescription";
            this.TBDescription.Size = new System.Drawing.Size(222, 86);
            this.TBDescription.TabIndex = 28;
            // 
            // BTEnregistrer
            // 
            this.BTEnregistrer.BackColor = System.Drawing.Color.LimeGreen;
            this.BTEnregistrer.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.BTEnregistrer.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BTEnregistrer.ForeColor = System.Drawing.Color.White;
            this.BTEnregistrer.Location = new System.Drawing.Point(122, 444);
            this.BTEnregistrer.Name = "BTEnregistrer";
            this.BTEnregistrer.Size = new System.Drawing.Size(135, 45);
            this.BTEnregistrer.TabIndex = 29;
            this.BTEnregistrer.Text = "Enregistrer";
            this.BTEnregistrer.UseVisualStyleBackColor = false;
            this.BTEnregistrer.Click += new System.EventHandler(this.BTEnregistrer_Click);
            // 
            // NumericNumberPerYear
            // 
            this.NumericNumberPerYear.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.NumericNumberPerYear.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NumericNumberPerYear.Location = new System.Drawing.Point(35, 133);
            this.NumericNumberPerYear.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.NumericNumberPerYear.Name = "NumericNumberPerYear";
            this.NumericNumberPerYear.Size = new System.Drawing.Size(222, 25);
            this.NumericNumberPerYear.TabIndex = 30;
            // 
            // BTSelectImage
            // 
            this.BTSelectImage.BackColor = System.Drawing.SystemColors.Info;
            this.BTSelectImage.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.BTSelectImage.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BTSelectImage.ForeColor = System.Drawing.Color.Red;
            this.BTSelectImage.Location = new System.Drawing.Point(35, 211);
            this.BTSelectImage.Name = "BTSelectImage";
            this.BTSelectImage.Size = new System.Drawing.Size(222, 38);
            this.BTSelectImage.TabIndex = 31;
            this.BTSelectImage.Text = "Choisir Image";
            this.BTSelectImage.UseVisualStyleBackColor = false;
            this.BTSelectImage.Click += new System.EventHandler(this.BTSelectImage_Click);
            // 
            // PicturePhoto
            // 
            this.PicturePhoto.Location = new System.Drawing.Point(263, 52);
            this.PicturePhoto.Name = "PicturePhoto";
            this.PicturePhoto.Size = new System.Drawing.Size(271, 386);
            this.PicturePhoto.TabIndex = 32;
            this.PicturePhoto.TabStop = false;
            // 
            // MagazineForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(546, 500);
            this.Controls.Add(this.PicturePhoto);
            this.Controls.Add(this.BTSelectImage);
            this.Controls.Add(this.NumericNumberPerYear);
            this.Controls.Add(this.BTEnregistrer);
            this.Controls.Add(this.TBDescription);
            this.Controls.Add(this.NumericPrice);
            this.Controls.Add(this.TBTitre);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.BTQuit);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "MagazineForm";
            this.Text = "Magasine";
            this.Load += new System.EventHandler(this.MagazineForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.NumericPrice)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NumericNumberPerYear)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PicturePhoto)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button BTQuit;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox TBTitre;
        private System.Windows.Forms.NumericUpDown NumericPrice;
        private System.Windows.Forms.TextBox TBDescription;
        private System.Windows.Forms.Button BTEnregistrer;
        private System.Windows.Forms.NumericUpDown NumericNumberPerYear;
        private System.Windows.Forms.Button BTSelectImage;
        private System.Windows.Forms.PictureBox PicturePhoto;
    }
}