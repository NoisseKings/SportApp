using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Court
    {
        public int Id { get; set; }
        public int AccountId { get; set; }
        public string Name { get; set; }
        public string WorkingHours { get; set; }
        public string PriceForHour { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime DateOfCreation { get; set; }
        public DateTime CreateAt { get; set; }
        public DateTime ModifyAt { get; set; }
        public Account Account { get; set; }
       
    }
}
