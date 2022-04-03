using Application.Common.Interfaces;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace Application.Account.Command.CreateUser
{
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, CreateUserCommand>
    {
        private readonly ISportAppDbContext _context;

        public CreateUserCommandHandler(ISportAppDbContext context)
        {
            _context = context;
        }

        public async Task<CreateUserCommand> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            if(request.Customer != null)
            {
                CreateUserCommand createUserCommand = new CreateUserCommand();
                var entity = new Domain.Entities.Account
                {
                    Email = request.Customer.Account.Email,
                    Password = request.Customer.Account.Password,
                    CreateAt = DateTime.Now,
                    ModifyAt = DateTime.Now,
                };
                //add domain event

                _context.Accounts.Add(entity);
                await _context.SaveChangesAsync(cancellationToken);

                if (entity.Id != 0)
                {
                    createUserCommand.Customer = new Domain.Entities.Customer
                    {
                        Account = entity
                    };

                    SymmetricSecurityKey secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("X42ZB5BWfEtkSfRdVENPZfWYTMvLe8TbmCjBzE3W"));
                    SigningCredentials credentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);

                    JwtSecurityToken tokenOptions = new JwtSecurityToken(
                        issuer: "https://localhost:5001",
                        audience: "https://localhost:5001",
                        claims: new List<Claim>(),
                        expires: DateTime.Now.AddMonths(6),
                        signingCredentials: credentials
                    );
                    entity.Token = new Token
                    {
                        Title = new JwtSecurityTokenHandler().WriteToken(tokenOptions),
                        Expire = DateTime.Now.AddMonths(6),
                        CreateAt = DateTime.Now,
                        ModifyAt = DateTime.Now
                    };
                    _context.Tokens.Add(entity.Token);
                    await _context.SaveChangesAsync(cancellationToken);

                    if (entity.Token.Id != 0)
                    {
                        createUserCommand.Customer.Account.Token = entity.Token;
                        var customer = new Domain.Entities.Customer
                        {
                            AccountId = entity.Id,
                            Account = entity,
                            FirstName = request.Customer.FirstName,
                            LastName = request.Customer.LastName,
                            Username = request.Customer.Username,
                            CreateAt = DateTime.Now,
                            ModifyAt = DateTime.Now
                        };

                        _context.Customers.Add(customer);
                        await _context.SaveChangesAsync(cancellationToken);

                        createUserCommand.Customer = customer;
                    }
                }

                return createUserCommand;
            }
            else
            {
                CreateUserCommand createUserCommand = new CreateUserCommand();
                var entity = new Domain.Entities.Account
                {
                    Email = request.Court.Account.Email,
                    Password = request.Court.Account.Password,
                    CreateAt = DateTime.Now,
                    ModifyAt = DateTime.Now,
                };
                _context.Accounts.Add(entity);
                await _context.SaveChangesAsync(cancellationToken);
                if (entity.Id != 0)
                {
                    createUserCommand.Court = new Domain.Entities.Court
                    {
                        Account = entity
                    };
                    SymmetricSecurityKey secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("X42ZB5BWfEtkSfRdVENPZfWYTMvLe8TbmCjBzE3W"));
                    SigningCredentials credentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);

                    JwtSecurityToken tokenOptions = new JwtSecurityToken(
                        issuer: "https://localhost:5001",
                        audience: "https://localhost:5001",
                        claims: new List<Claim>(),
                        expires: DateTime.Now.AddMonths(6),
                        signingCredentials: credentials
                    );
                    entity.Token = new Token
                    {
                        Title = new JwtSecurityTokenHandler().WriteToken(tokenOptions),
                        Expire = DateTime.Now.AddMonths(6),
                        CreateAt = DateTime.Now,
                        ModifyAt = DateTime.Now
                    };
                    _context.Tokens.Add(entity.Token);
                    await _context.SaveChangesAsync(cancellationToken);

                    if (entity.Token.Id != 0)
                    {
                        createUserCommand.Court.Account.Token = entity.Token;
                        var court = new Domain.Entities.Court
                        {
                            AccountId = entity.Id,
                            Account = entity,
                            Name = request.Court.Name,
                            WorkingHours = request.Court.WorkingHours,
                            PriceForHour = request.Court.PriceForHour,
                            DateOfCreation = request.Court.DateOfCreation,
                            PhoneNumber = request.Court.PhoneNumber,
                            CreateAt = DateTime.Now,
                            ModifyAt = DateTime.Now
                        };

                        _context.Courts.Add(court);
                        await _context.SaveChangesAsync(cancellationToken);

                        createUserCommand.Court = court;
                    }
                }

                return createUserCommand;
            }
            
        }
    }
}