using Application.Common.Interfaces;
using Application.Customer.Query.GetCustomerByUsername;
using Application.Dashboard.Query.GetCourtById;
using AutoMapper;
using Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Dashboard.Command.CreateReservation
{
    public class CreateReservationCommandHandler : IRequestHandler<CreateReservationCommand, int>
    {
        private readonly ISportAppDbContext _context;
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public CreateReservationCommandHandler(ISportAppDbContext context, IMediator mediator, IMapper mapper)
        {
            _context = context;
            _mediator = mediator;
            _mapper = mapper;
        }
        public async Task<int> Handle(CreateReservationCommand request, CancellationToken cancellationToken)
        {
            Reservation entityReservation = new Reservation();
            string _customerSessionValue = request.CustomerReservation;

            var _court = await _mediator.Send(new GetCourtByIdQuery
            {
                Id = request.Reservation.CourtId
            }, cancellationToken);

            var _customer = await _mediator.Send(new GetCustomerByUsernameQuery
            {
                InputUsername = _customerSessionValue
            });

            if(_court.Id != 0)
            {
                entityReservation = new Reservation()
                {
                    Id = request.Reservation.Id,
                    StartDate = request.Reservation.StartDate,
                    EndDate = request.Reservation.EndDate,
                    NumberOfPeople = request.Reservation.NumberOfPeople,
                    IsOpen = request.Reservation.IsOpen,
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now,
                    CourtId = _court.Id,
                };

                _context.Reservations.Add(entityReservation);
                await _context.SaveChangesAsync(cancellationToken);

                if (entityReservation.Id != 0)
                {
                    var entityCustomerReservation = new CustomerReservation()
                    {
                        ReservationId = entityReservation.Id,
                        

                        CustomerId = _customer.Customer.Id,
                        
                    };

                    _context.CustomerReservations.Add(entityCustomerReservation);
                    await _context.SaveChangesAsync(cancellationToken);
                }
            }
            return entityReservation.Id;
        }
    }
}
