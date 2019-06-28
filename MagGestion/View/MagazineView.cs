﻿using MagGestion.Controls.Interface;
using MagGestion.DataServices.Interface;
using MagGestion.Helper.Interface;
using MagGestion.Presenter;
using MagGestion.View.Interface;
using RestSharp.Deserializers;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace MagGestion.Forms
{
    public partial class MagazineForm : Form, IMagazineView
    {
        private IControl _control;


        private readonly ICacheService _cache;
        private readonly IErrorLogger _errorLogger;
        private readonly IDeserializer _serializer;

        public event EventHandler CloseRequested;
        public event EventHandler CreationHistoriqueRequested;


        public MagazineViewPresenter Presenter { private get; set; }
        public int Id { get; set; }
        public string Titre { get => TBTitre.Text; set => TBTitre.Text = value; }
        public string URLPhoto { get; set; }
        public decimal PrixAnnee { get => NumericPrice.Value; set => NumericPrice.Value = value; }
        public string Description { get; set; }
        public int NumeroAnnee { get => (int)NumericNumberPerYear.Value; set => NumericNumberPerYear.Value = value; }

        private readonly string _id;

        public MagazineForm(IControl control, ICacheService cache, IErrorLogger errorLogger, IDeserializer serializer, int id)
        {
            InitializeComponent();
            Id = id;
            _cache = cache;
            _control = control;
            _serializer = serializer;
            _control.Parent.Parent.Enabled = false;
            this.TopMost = true;
            this.CenterToScreen();
        }

        private void BTQuit_Click(object sender, EventArgs e)
        {
            _control.Parent.Parent.Enabled = true;

            this.Close();
        }

        private void BTSelectImage_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog dlg = new OpenFileDialog())
            {

                dlg.Title = "Choisir couverture";
                dlg.Filter = "Image Files(*.BMP;*.JPG;*.GIF)|*.BMP;*.JPG;*.GIF|All files (*.*)|*.*";
                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    PicturePhoto.Image = new Bitmap(dlg.FileName);
                    PicturePhoto.SizeMode = PictureBoxSizeMode.CenterImage;
                }
            }
        }
        private void Initialize(int id)
        {
            //  Magazine magazine = new MagazineDataService().GetMagazine(id);
        }
    }
}
