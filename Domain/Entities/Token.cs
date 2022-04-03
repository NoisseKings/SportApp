using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Token
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public DateTime Expire { get; set; }
        public DateTime CreateAt { get; set; }
        public DateTime ModifyAt { get; set; }

      
    }
}
