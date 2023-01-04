using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CovoitEco.Core.Application.Common.Interfaces;
using CovoitEco.Core.Application.DTOs;
using CovoitEco.Core.Application.Services.Reservation.Queries;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CovoitEco.Core.Application.Services.Reservation.Commands
{
    public class UpdateAccepterReservationCommand : IRequest<int>
    {
        public int RES_Id { get; set; }
        public class UpdateAccepterReservationCommandHandler : IRequestHandler<UpdateAccepterReservationCommand, int>
        {
            private readonly IApplicationDbContext _context;

            public UpdateAccepterReservationCommandHandler(IApplicationDbContext context)
            {
                _context = context;
            }

            public async Task<int> Handle(UpdateAccepterReservationCommand request, CancellationToken cancellationToken)
            {
                var reservation = await _context.Reservation.FindAsync(request.RES_Id);

                reservation.RES_STATRES_Id = 2;

                await _context.SaveChangesAsync(cancellationToken);

                return request.RES_Id;
            }
        }
    }
}
