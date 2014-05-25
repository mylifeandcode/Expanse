using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Expanse.Domain.Things
{
    /// <summary>
    /// A class used to define anything which can modify a tactical unit.
    /// For example, in Star Trek this could be a cloaking device.
    /// Derived classes can be more specific/refined (for example, Commanders).
    /// </summary>
    public class Modifier
    {
        public string Name { get; set; }
        public short AttackBonus { get; set; }
        public short DefenseBonus { get; set; }
        public bool IsActive { get; set; }
        //public short Skill { get; set; }
    }
}
