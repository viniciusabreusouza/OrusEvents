using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrusEvents.Infrastructure.Entities
{
    public partial class Users
    {
        public Users()
        {
            Registers = new HashSet<Registers>();
        }

        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }

        public virtual ICollection<Registers> Registers { get; set; }
    }
}
