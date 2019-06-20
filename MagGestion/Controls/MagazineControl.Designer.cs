namespace MagGestion.Controls
{
    partial class MagazineControl
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

        #region Code généré par le Concepteur de composants

        /// <summary> 
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas 
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            this.BTMagazine = new System.Windows.Forms.Button();
            this.DGVPublication = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.DGVPublication)).BeginInit();
            this.SuspendLayout();
            // 
            // BTMagazine
            // 
            this.BTMagazine.BackColor = System.Drawing.SystemColors.Highlight;
            this.BTMagazine.Enabled = false;
            this.BTMagazine.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.BTMagazine.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BTMagazine.ForeColor = System.Drawing.Color.White;
            this.BTMagazine.Location = new System.Drawing.Point(360, 283);
            this.BTMagazine.Margin = new System.Windows.Forms.Padding(2);
            this.BTMagazine.Name = "BTMagazine";
            this.BTMagazine.Size = new System.Drawing.Size(227, 39);
            this.BTMagazine.TabIndex = 4;
            this.BTMagazine.Text = "Gestion Publication";
            this.BTMagazine.UseVisualStyleBackColor = false;
            this.BTMagazine.Click += new System.EventHandler(this.BTMagazine_Click);
            // 
            // DGVPublication
            // 
            this.DGVPublication.AllowUserToAddRows = false;
            this.DGVPublication.AllowUserToDeleteRows = false;
            this.DGVPublication.AllowUserToResizeColumns = false;
            this.DGVPublication.AllowUserToResizeRows = false;
            this.DGVPublication.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.DGVPublication.BackgroundColor = System.Drawing.SystemColors.Control;
            this.DGVPublication.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.DGVPublication.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.DGVPublication.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGVPublication.Location = new System.Drawing.Point(3, 2);
            this.DGVPublication.Margin = new System.Windows.Forms.Padding(2);
            this.DGVPublication.Name = "DGVPublication";
            this.DGVPublication.ReadOnly = true;
            this.DGVPublication.RowHeadersVisible = false;
            this.DGVPublication.RowTemplate.Height = 28;
            this.DGVPublication.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DGVPublication.Size = new System.Drawing.Size(584, 278);
            this.DGVPublication.TabIndex = 3;
            this.DGVPublication.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DGVPublication_CellClick);
            this.DGVPublication.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.DGVPublication_DataBindingComplete);
            // 
            // MagazineControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.Controls.Add(this.BTMagazine);
            this.Controls.Add(this.DGVPublication);
            this.Name = "MagazineControl";
            this.Size = new System.Drawing.Size(590, 325);
            this.Load += new System.EventHandler(this.MagazineControl_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DGVPublication)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button BTMagazine;
        private System.Windows.Forms.DataGridView DGVPublication;
    }
}
