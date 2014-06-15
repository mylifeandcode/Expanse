using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Expanse.Domain.Diplomacy
{
    public class Relationship
    {
        public short NationId { get; set; }
        public short VolatilityTowards { get; set; }
        public short FriendlinessTowards { get; set; }
    }
}
