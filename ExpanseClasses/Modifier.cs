using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Expanse.Classes
{
    public class Modifier
    {
        public string Name { get; set; }
        public short AttackBonus { get; set; }
        public short DefenseBonus { get; set; }
        public bool IsActive { get; set; }
    }
}
