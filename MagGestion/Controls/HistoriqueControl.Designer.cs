namespace MagGestion.Controls
{
    partial class HistoriqueControl
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
            this.DGVHistorique = new System.Windows.Forms.DataGridView();
            this.BTClient = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.DGVHistorique)).BeginInit();
            this.SuspendLayout();
            // 
            // DGVHistorique
            // 
            this.DGVHistorique.AllowUserToAddRows = false;
            this.DGVHistorique.AllowUserToDeleteRows = false;
            this.DGVHistorique.AllowUserToResizeColumns = false;
            this.DGVHistorique.AllowUserToResizeRows = false;
            this.DGVHistorique.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.DGVHistorique.BackgroundColor = System.Drawing.SystemColors.Control;
            this.DGVHistorique.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.DGVHistorique.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.DGVHistorique.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGVHistorique.Location = new System.Drawing.Point(2, 2);
            this.DGVHistorique.Margin = new System.Windows.Forms.Padding(2);
            this.DGVHistorique.Name = "DGVHistorique";
            this.DGVHistorique.ReadOnly = true;
            this.DGVHistorique.RowHeadersVisible = false;
            this.DGVHistorique.RowTemplate.Height = 28;
            this.DGVHistorique.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DGVHistorique.Size = new System.Drawing.Size(584, 278);
            this.DGVHistorique.TabIndex = 0;
            this.DGVHistorique.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DGVHistorique_CellClick);
            this.DGVHistorique.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.DGVHistorique_DataBindingComplete);
            // 
            // BTClient
            // 
            this.BTClient.BackColor = System.Drawing.SystemColors.Highlight;
            this.BTClient.Enabled = false;
            this.BTClient.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.BTClient.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BTClient.ForeColor = System.Drawing.Color.White;
            this.BTClient.Location = new System.Drawing.Point(402, 283);
            this.BTClient.Margin = new System.Windows.Forms.Padding(2);
            this.BTClient.Name = "BTClient";
            this.BTClient.Size = new System.Drawing.Size(184, 39);
            this.BTClient.TabIndex = 2;
            this.BTClient.Text = "Fiche Client";
            this.BTClient.UseVisualStyleBackColor = false;
            this.BTClient.Click += new System.EventHandler(this.BTClient_Click);
            // 
            // HistoriqueControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.BTClient);
            this.Controls.Add(this.DGVHistorique);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "HistoriqueControl";
            this.Size = new System.Drawing.Size(590, 325);
            this.Load += new System.EventHandler(this.HistoriqueControl_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DGVHistorique)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView DGVHistorique;
        private System.Windows.Forms.Button BTClient;
    }
}
