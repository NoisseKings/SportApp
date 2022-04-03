using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebUI.ViewModels
{
    public class CourtAccountVM
    {
        public int Id { get; set; }
        public int AdressId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public DateTime DateOfCreation { get; set; }
        public string WorkingHours { get; set; }
        public string PriceForHour { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime DateModify { get; set; }
    }
}
