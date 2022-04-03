using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Dashboard.Command.CreateReservation
{
    public class CreateReservationCommand : IRequest<int>
    {
        public Domain.Entities.Reservation Reservation { get; set; }
        public string CustomerReservation { get; set; }
    }
}
