using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrusEvents.Infrastructure.Entities
{
    public partial class Registers
    {
        public int Id { get; set; }
        public Guid UserId { get; set; }
        public int EventId { get; set; }
        public bool Confirmed { get; set; }


        public virtual Events Event { get; set; }
        public virtual Users User { get; set; }
    }
}
