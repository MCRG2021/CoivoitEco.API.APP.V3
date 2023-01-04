using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CovoitEco.Core.Application.Common.Exceptions;
using CovoitEco.Core.Application.Common.Interfaces;
using CovoitEco.Core.Application.DTOs;
using CovoitEco.Core.Application.Services.Reservation.Queries;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CovoitEco.Core.Application.Services.Annonce.Commands
{
    public class UpdateStatutAnnonceCommand : IRequest<int>
    {
        public int ANN_Id { get; set; }
    }
    public class UpdateStatutAnnonceCommandHandler : IRequestHandler<UpdateStatutAnnonceCommand, int>
    {
        private readonly IApplicationDbContext _context;

        public UpdateStatutAnnonceCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<int> Handle(UpdateStatutAnnonceCommand request, CancellationToken cancellationToken)
        {

            var annonce = await _context.Annonce.FindAsync(request.ANN_Id);

            if (annonce == null)
            {
                throw new Exception("Annonce not found");
            }

            // Test "Publier" => "EnCours"
            if (annonce.ANN_STATANN_Id == 1 && TooLate(annonce.ANN_DateDepart) == true)
            {
                 annonce.ANN_STATANN_Id = 2; // Status "EnCours"
            }


            //// Test "EnCours" => "Close"
            //if (annonce.ANN_STATANN_Id == 2 && annonce.ANN_DateArrive < DateTime.Now)
            //{
            //    ReservationProfileVm listReservation = new ReservationProfileVm();
            //    int nbreReservStatClose = 0;
                
            //    // Get list reservation for this annonce
            //    listReservation.Lists = await (
            //        from r in _context.Reservation
            //        join f in _context.Facture on r.RES_Id equals f.FACT_RES_Id
            //        join sr in _context.StatutReservation on r.RES_STATRES_Id equals sr.STATRES_Id
            //        join u in _context.Utilisateur on r.RES_UTL_Id equals u.UTL_Id
            //        where r.RES_ANN_Id == request.ANN_Id
            //        select new ReservationProfileDTO()
            //        {
            //            RESPR_Id = r.RES_Id,
            //            RESPR_DateReservation = r.RES_DateReservation,
            //            RESPR_ANN_Id = r.RES_ANN_Id,
            //            RESPR_StatutLibelle = sr.STATRES_Libelle,
            //            RESPR_FactureResolus = f.FACT_Resolus,
            //            RESPR_Nom = u.UTL_Nom,
            //            RESPR_Prenom = u.UTL_Prenom
            //        }
            //    ).ToListAsync(cancellationToken);

            //    // svg nbre reservation payed ("EnOrdre")
            //    foreach (var reservation in listReservation.Lists)
            //    {
            //        if (reservation.RESPR_StatutLibelle == "EnOrdre")
            //        {
            //            nbreReservStatClose++;
            //        }
            //    }

            //    // if all reservation payed (of no reservation)
            //    if (nbreReservStatClose == listReservation.Lists.Count)
            //    {
            //        annonce.ANN_STATANN_Id = 3; // Close
            //    }
            //}

            await _context.SaveChangesAsync(cancellationToken);

            return request.ANN_Id;
        }

        private bool TooLate(DateTime dateTimeDepart) 
        {
            double minutes = 0;
            if (dateTimeDepart.Date >= DateTime.Now.Date)
            {
                TimeSpan timespan =  dateTimeDepart - DateTime.Now;
                minutes = timespan.TotalMinutes;
                if (minutes >= 15) return false;
            }
            return true;
        }
    }
}
