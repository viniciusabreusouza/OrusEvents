using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrusEvents.Infrastructure.Entities
{
    public partial class Events
    {
        public Events()
        {
            Registers = new HashSet<Registers>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime Date { get; set; }
        public bool Payed { get; set; }

        public virtual ICollection<Registers> Registers { get; set; }
    }
}
