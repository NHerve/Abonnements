using MagGestion.DataServices;
using MagGestion.DataServices.Interface;
using MagGestion.Helper;
using MagGestion.Helper.Interface;
using MagGestion.Model.Historique;
using MagGestion.Model.Magazine;
using MagGestion.View.Interface;
using RestSharp.Deserializers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MagGestion.Presenter
{
    public class MagazineViewPresenter : BasePresenter
    {
        private readonly IMagazineView _view;
        private readonly MagazineDataService _magazineDataService;

        private int IdMagazine;
        public MagazineViewPresenter(IMagazineView view, ICacheService cache, IErrorLogger errorLogger, IDeserializer serializer) : base(cache, errorLogger, serializer)
        {
            _view = view;
            _view.SaveMagazine += SaveMagazine;
            _magazineDataService = new MagazineDataService(_cache, _serializer, _errorLogger);
        }

        public void OnCloseRequested(object sender, EventArgs e)
        {
            _view.Close();
        }

        public void GetMagazine(int id)
        {
            Magazine magazine = _magazineDataService.GetMagazine(id) ?? new Magazine { Titre = "Test", Description = "TestPre", NumeroAnnee = 365, PrixAnnuel = 99.99M };
            IdMagazine = magazine.Id;
            _view.Titre = magazine.Titre;
            _view.Description = magazine.Description;
            _view.PrixAnnee = magazine.PrixAnnuel;
            _view.NumeroAnnee = magazine.NumeroAnnee;
        }

        public void SaveMagazine(object sender, EventArgs e)
        {
            int id = _view.Id;
            string titre = _view.Titre;
            int numAnnee = _view.NumeroAnnee;
            //string urlPhoto
            decimal prixAnnuel = _view.PrixAnnee;
            string description = _view.Description;

            _magazineDataService.PutMagazine(new Magazine { Id = id, Titre = titre, Description = description, NumeroAnnee = numAnnee, PrixAnnuel = prixAnnuel });
            _view.Close();
            

        }
    }
}
