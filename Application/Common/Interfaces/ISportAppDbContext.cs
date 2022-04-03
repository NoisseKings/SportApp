using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Common.Interfaces
{
    public interface ISportAppDbContext
    {
        public DbSet<Domain.Entities.Account> Accounts { get; set; }
        public DbSet<Domain.Entities.Court> Courts { get; set; }
        public DbSet<Domain.Entities.Token> Tokens { get; set; }
        public DbSet<Domain.Entities.Customer> Customers { get; set; }
        public DbSet<Domain.Entities.Reservation> Reservations { get; set; }
        public DbSet<Domain.Entities.CustomerReservation> CustomerReservations { get; set; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
