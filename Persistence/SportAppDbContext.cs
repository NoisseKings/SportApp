using Application.Common.Interfaces;
using Domain.Entities;
using IdentityServer4.EntityFramework.Options;
using Microsoft.AspNetCore.ApiAuthorization.IdentityServer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Persistence.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Persistence
{
    public class SportAppDbContext : ApiAuthorizationDbContext<ApplicationUser>, ISportAppDbContext
    {
        private readonly ICurrentUserService _currentUserService;
        //private readonly IDateTime _dateTime;
        //private readonly IDomainEventService _domainEventService;

        public SportAppDbContext(DbContextOptions options,
            IOptions<OperationalStoreOptions> operationalStoreOptions,
            ICurrentUserService currentUserService
        //IDomainEventService domainEventService,
        //IDateTime dateTime
        ) : base(options, operationalStoreOptions)
        {
            _currentUserService = currentUserService;
            //_domainEventService = domainEventService;
            //_dateTime = dateTime;
        }
        public DbSet<Account> Accounts { get; set; }
        public DbSet<Court> Courts { get; set; }
        public DbSet<Token> Tokens { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Reservation> Reservations { get; set; }
        public DbSet<CustomerReservation> CustomerReservations { get; set; }

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            //add trucker
            var result = await base.SaveChangesAsync(cancellationToken);
            //add dispatchEvent
            return result;
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Account>().ToTable("Account");
            builder.Entity<Token>().ToTable("Token");
            builder.Entity<Customer>().ToTable("Customer");
            builder.Entity<Court>().ToTable("Court");
            builder.Entity<Reservation>().ToTable("Reservation");
            builder.Entity<CustomerReservation>().ToTable("CustomerReservation");
            
            builder.Entity<Customer>().ToTable("Customer").HasOne(c => c.Account).WithOne(a => a.Customer).HasForeignKey<Customer>(c => c.AccountId).IsRequired();
            //builder.Entity<Account>().HasOne(c => c.Customer).WithOne(a => a.Account).HasForeignKey<Customer>(c => c.AccountId).IsRequired();

            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            base.OnModelCreating(builder);
        }
    }
}
