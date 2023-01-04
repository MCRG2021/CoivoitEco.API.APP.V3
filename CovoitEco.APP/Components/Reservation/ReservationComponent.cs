using CovoitEco.APP.Model.Models;
using CovoitEco.APP.Service.Facture.Commands;
using CovoitEco.APP.Service.Facture.Queries;
using CovoitEco.APP.Service.Reservation.Commands;
using CovoitEco.APP.Service.Reservation.Queries;
using Microsoft.AspNetCore.Components;

namespace CovoitEco.APP.Components.Reservation
{
    public class ReservationComponent : BaseComponent
    {

        //[Inject]
        //public IReservationCommandsService ReservationCommands { get; set; }

        //[Inject]
        //public IReservationQueriesService ReservationQueries { get; set; }

        //[Inject]
        //public IFactureCommandsService FactureCommands { get; set; }  
        
        //[Inject]
        //public IFactureQueriesService FactureQueries { get; set; }

        protected override async Task OnInitializedAsync()
        {
            responseGetAllReservationUser = await ReservationQueries.GetAllReservationUserProfile(idUser); 
        }

        protected async Task UpdateFacturePayment(int id)
        {
            idFacture = await FactureQueries.GetIdFactureReservation(id);
            await FactureCommands.UpdateFacturePayment(idFacture);
        }
    }
}
