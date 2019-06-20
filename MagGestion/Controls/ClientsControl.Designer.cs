namespace MagGestion.Controls
{
    partial class ClientsControl
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
            this.DGVClients = new System.Windows.Forms.DataGridView();
            this.BTClient = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.DGVClients)).BeginInit();
            this.SuspendLayout();
            // 
            // DGVClients
            // 
            this.DGVClients.AllowUserToAddRows = false;
            this.DGVClients.AllowUserToDeleteRows = false;
            this.DGVClients.AllowUserToResizeColumns = false;
            this.DGVClients.AllowUserToResizeRows = false;
            this.DGVClients.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.DGVClients.BackgroundColor = System.Drawing.SystemColors.Control;
            this.DGVClients.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.DGVClients.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.DGVClients.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGVClients.Cursor = System.Windows.Forms.Cursors.Default;
            this.DGVClients.Location = new System.Drawing.Point(2, 2);
            this.DGVClients.Margin = new System.Windows.Forms.Padding(2);
            this.DGVClients.MultiSelect = false;
            this.DGVClients.Name = "DGVClients";
            this.DGVClients.ReadOnly = true;
            this.DGVClients.RowHeadersVisible = false;
            this.DGVClients.RowTemplate.Height = 28;
            this.DGVClients.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DGVClients.Size = new System.Drawing.Size(584, 278);
            this.DGVClients.TabIndex = 0;
            this.DGVClients.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DGVClients_CellClick);
            this.DGVClients.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.DGVClients_DataBindingComplete);
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
            this.BTClient.TabIndex = 1;
            this.BTClient.Text = "Fiche Client";
            this.BTClient.UseVisualStyleBackColor = false;
            this.BTClient.Click += new System.EventHandler(this.BTClient_Click);
            // 
            // ClientsControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.Controls.Add(this.BTClient);
            this.Controls.Add(this.DGVClients);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "ClientsControl";
            this.Size = new System.Drawing.Size(590, 325);
            this.Load += new System.EventHandler(this.ClientsControl_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DGVClients)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView DGVClients;
        private System.Windows.Forms.Button BTClient;
    }
}
