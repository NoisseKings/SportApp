using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Account
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public DateTime CreateAt { get; set; }
        public DateTime ModifyAt { get; set; }

        public int? TokenId { get; set; }
        public Token Token { get; set; }

        public int? LocationId { get; set; }
        public Location Location { get; set; }

        public Court Court { get; set; }
        public Customer Customer { get; set; }
    }
}
