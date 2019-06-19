using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MagGestion.Model.Magazine;
using MagGestion.Forms;
using MagGestion.DataServices;
using MagGestion.DataServices.Interface;
using MagGestion.Helper.Interface;
using RestSharp.Deserializers;

namespace MagGestion.Controls
{
    public partial class MagazineControl : UserControl
    {
        private readonly ICacheService _cache;
        private readonly IErrorLogger _errorLogger;
        private readonly IDeserializer _serializer;
        public MagazineControl(ICacheService cache, IErrorLogger errorLogger, IDeserializer serializer)
        {
            InitializeComponent();
            _cache = cache;
            _errorLogger = errorLogger;
            _serializer = serializer;
            Initialize();
        }

        private void DGVPublication_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            BTMagazine.Enabled = true;
        }

        private void DGVPublication_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            DGVPublication.ClearSelection();
        }

        private void BTMagazine_Click(object sender, EventArgs e)
        {
            var id = DGVPublication.SelectedRows[0].Cells["Id"].Value;
            new MagazineForm(this, id.ToString()).Show();
        }

        private void Initialize()
        {
            List<DGVMagazine> Magazines = new MagazineDataService(_cache,_serializer, _errorLogger).GetMagazines() ?? new List<DGVMagazine>();

            var h = new BindingList<DGVMagazine>(Magazines);
            DGVPublication.DataSource = new BindingSource(h, null);
            DGVPublication.Columns["Id"].Visible = false;
            DGVPublication.Columns["NumeroAnnée"].HeaderText = "Numéro année";
            DGVPublication.Columns["PrixAnnuel"].HeaderText = "Prix annuel";
        }
    }
}
