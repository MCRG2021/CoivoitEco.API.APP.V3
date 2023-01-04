using System.Data;
using CoiviteEco.APP.Service.Annonce.Queries;
using CovoitEco.APP.Model.Models;
using CovoitEco.APP.Service.Annonce.Commands;
using CovoitEco.APP.Service.Facture.Commands;
using CovoitEco.APP.Service.Facture.Queries;
using CovoitEco.APP.Service.Reservation.Commands;
using CovoitEco.APP.Service.Reservation.Queries;
using CovoitEco.APP.Service.Utilisateur.Queries;
using CovoitEco.APP.Service.Vehicule.Commands;
using CovoitEco.APP.Service.Vehicule.Queries;
using Microsoft.AspNetCore.Components;

namespace CovoitEco.APP.Components
{
    public class BaseComponent : ComponentBase
    {
        #region Parameter

        [Parameter]
        public static int idVehicule { get; set; }

        [Parameter]
        public static int idAnnonce { get; set; }

        [Parameter]
        public static int idReservation { get; set; }

        [Parameter]
        public static int idFacture { get; set; }

        [Parameter]
        public static int idUser { get; set; } = 1; // idUser must be edit (default 1 for the moment => see data)

        [Parameter]
        public static bool confirme { get; set; }

        #region Response

        [Parameter]
        public ReservationUserProfileVm responseGetAllReservationUser { get; set; }

        [Parameter]
        public VehiculeProfileVm responseGetVehicule { get; set; }

        [Parameter]
        public AnnonceProfileVm responseAnnonce { get; set; }

        [Parameter]
        public VehiculeProfileVm responseGetAllVehicule { get; set; } // test

        [Parameter]
        public ReservationUserProfileVm responseGetReservationUser { get; set; } // test

        [Parameter]
        public UserProfileVm responseGetUtilisateurProfile { get; set; } // test

        #endregion

        #endregion

        #region Formular

        public ReservationFormular requestReservationFormular { get; set; } = new ReservationFormular(); // test

        public AnnonceProfileFormular requestAnnonceProfileFormular { get; set; } = new AnnonceProfileFormular(); // test

        public AnnonceRechercheFormular requestAnnonceRechercheFormular { get; set; } = new AnnonceRechercheFormular(); // test

        public VehiculeProfileFormular resquestVehiculeProfileFormular { get; set; } = new VehiculeProfileFormular() { VEH_UTL_Id = idUser }; // test

        #endregion

        #region Inject

        [Inject]
        public IVehiculeQueriesService vehiculeQueries { get; set; }

        [Inject]
        public IVehiculeCommandsService vehiculeCommands { get; set; } //test

        [Inject]
        public IAnnonceQueriesService AnnonceQueries { get; set; } // test

        [Inject]
        public IAnnonceCommandsService AnnonceCommands { get; set; } // test

        [Inject]
        public IReservationCommandsService ReservationCommands { get; set; } // test

        [Inject]
        public IReservationQueriesService ReservationQueries { get; set; } // test

        [Inject]
        public IFactureCommandsService FactureCommands { get; set; } // test

        [Inject]
        public IFactureQueriesService FactureQueries { get; set; } //test

        [Inject]
        public IUtilisateurQueriesService UtilisateurQueries { get; set; } // test

        #endregion


        public void UpdateIdAnnonce(int id)
        {
            idAnnonce = id;
        }

        public void UpdateIdReservation(int id)
        {
            idReservation = id;
        }

        public void UpdateIFacutre(int id)
        {
            idFacture = id;
        }

        protected async Task SetIdVehCurrent()
        {
            responseGetVehicule = await vehiculeQueries.GetVehiculeProfile(idUser); 
            if (responseGetVehicule.Lists.Count == 0)
            {
                throw new Exception(); // to edit (message you have no vehicule profile)
            }
            else
            {
                idVehicule = responseGetVehicule.Lists[0].VEHPR_Id;
            }
        }

        protected async Task SetIdUser()
        {
            // to edit
        }

    }
}
