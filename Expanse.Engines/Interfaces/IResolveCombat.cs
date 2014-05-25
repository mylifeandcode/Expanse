using Expanse.Domain.Things;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Expanse.Engines.Interfaces
{
    public interface IResolveCombat
    {
        void Attack(TacticalUnit attacker, TacticalUnit defender, int percentageChanceOfMultiShieldDamage, bool allowDamageToAttacker);
        void AllocateDamage(TacticalUnit recipient, int damageToAllocate, int percentageChanceOfMultiShieldDamage);

        /// <summary>
        /// Resolves combat between two TacticalUnits
        /// </summary>
        /// <param name="attacker">The attacker</param>
        /// <param name="defender">The defender</param>
        /// <param name="allowDamageToAttacker">Specifies whether or not to allow damage to the attacker during the attack</param>
        /// <param name="attackerDamage">Amount of damage to apply to the attacker</param>
        /// <param name="defenderDamage">Amount of damage to apply to the defender</param>
        void ResolveCombat(TacticalUnit attacker, TacticalUnit defender, bool allowDamageToAttacker, out int attackerDamage, out int defenderDamage);
    }
}
