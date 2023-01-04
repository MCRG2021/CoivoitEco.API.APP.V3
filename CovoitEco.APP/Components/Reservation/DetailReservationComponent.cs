using CovoitEco.APP.Model.Models;
using CovoitEco.APP.Service.Reservation.Queries;
using Microsoft.AspNetCore.Components;

namespace CovoitEco.APP.Components.Reservation
{
    public class DetailReservationComponent : BaseComponent
    {
        //[Parameter]
        //public ReservationUserProfileVm responseGetReservationUser { get; set; }

        //[Inject]
        //public IReservationQueriesService ReservationQueries { get; set; }

        protected override async Task OnInitializedAsync()
        {
            responseGetReservationUser = await ReservationQueries.GetReservationUserProfile(idReservation);
        }

    }
}
