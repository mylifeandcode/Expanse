using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Expanse.Domain.Things
{
    public class Commander : Modifier
    {
        //public int AttackBonus { get; set; }
        //public int DefenseBonus { get; set; }
        public bool GroupwideModifier { get; set; }
        public short Skill { get; set; }

        public Commander(string name, short skill, short attackBonus, short defenseBonus, bool groupwideModifier, bool isActive)
        {
            Name = name;
            Skill = skill;
            AttackBonus = attackBonus;
            DefenseBonus = defenseBonus;
            GroupwideModifier = groupwideModifier;
            IsActive = isActive;
        }
    }
}
