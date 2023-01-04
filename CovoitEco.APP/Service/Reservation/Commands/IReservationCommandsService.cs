using CovoitEco.APP.Model.Models;

namespace CovoitEco.APP.Service.Reservation.Commands
{
    public interface IReservationCommandsService
    {
        public Task CreateReservation(ReservationFormular formular);
    }
}
