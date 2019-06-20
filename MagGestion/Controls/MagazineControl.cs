using MagGestion.Controls.Interface;
using MagGestion.DataServices.Interface;
using MagGestion.Helper.Interface;
using MagGestion.Presenter;
using RestSharp.Deserializers;
using System;
using System.Windows.Forms;

namespace MagGestion.Controls
{
    public partial class MagazineControl : UserControl, IMagazineControl
    {
        private readonly ICacheService _cache;
        private readonly IErrorLogger _errorLogger;
        private readonly IDeserializer _serializer;

        public event EventHandler MagazineSelected;
        public event EventHandler OnShowMagazineForm;

        public MagazineControlPresenter Presenter { private get; set; }
        public DataGridView DGVMagazine { get => DGVMagazine; set => DGVMagazine = value; }
        public Button BTMag { get => BTMagazine; set => BTMagazine = value; }

        public MagazineControl(ICacheService cache, IErrorLogger errorLogger, IDeserializer serializer)
        {
            _cache = cache;
            _errorLogger = errorLogger;
            _serializer = serializer;
            InitializeComponent();
        }

        private void DGVPublication_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            MagazineSelected(this, EventArgs.Empty);
        }

        private void DGVPublication_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            DGVPublication.ClearSelection();
        }

        private void BTMagazine_Click(object sender, EventArgs e)
        {

        }

        private void MagazineControl_Load(object sender, EventArgs e)
        {
            Presenter = new MagazineControlPresenter(this, _cache, _errorLogger, _serializer);
            Presenter.FillDGV();
        }
    }
}
