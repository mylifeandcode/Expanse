using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Expanse.Domain.Entities;

namespace Expanse.Engines
{
    public interface ICombatEngine
    {
        string Attack(TacticalUnit attacker, TacticalUnit defender, int percentageChanceOfMultiShieldDamage, bool allowDamageToAttacker, bool returnSpecifics);
        string AllocateDamage(TacticalUnit recipient, int damageToAllocate, int percentageChanceOfMultiShieldDamage, bool returnSpecifics);

        /// <summary>
        /// Resolves combat between two TacticalUnits
        /// </summary>
        /// <param name="attacker">The attacker</param>
        /// <param name="defender">The defender</param>
        /// <param name="allowDamageToAttacker">Specifies whether or not to allow damage to the attacker during the attack</param>
        /// <param name="attackerDamage">Amount of damage to apply to the attacker</param>
        /// <param name="defenderDamage">Amount of damage to apply to the defender</param>
        /// <param name="returnSpecifics">Specifies whether or not to return specifics about how the combat played out</param>
        /// <returns>A description of how the combat played out if returnSpecifics was specified as true, otherwise null</returns>
        string ResolveCombat(TacticalUnit attacker, TacticalUnit defender, bool allowDamageToAttacker, out int attackerDamage, out int defenderDamage, bool returnSpecifics);
    }

    public class CombatEngine : ICombatEngine
    {
        public string Attack(TacticalUnit attacker, TacticalUnit defender, int percentageChanceOfMultiShieldDamage, bool allowDamageToAttacker, bool returnSpecifics)
        {
            int attackerDamage;
            int defenderDamage;
            string defenderDamageResolution = null;
            string attackerDamageResolution = null;

            string combatResolution = ResolveCombat(attacker, defender, allowDamageToAttacker, out attackerDamage, out defenderDamage, returnSpecifics);

            if (defenderDamage > 0)
                defenderDamageResolution = AllocateDamage(defender, defenderDamage, percentageChanceOfMultiShieldDamage, returnSpecifics);

            if (allowDamageToAttacker && attackerDamage > 0)
                attackerDamageResolution = AllocateDamage(attacker, attackerDamage, percentageChanceOfMultiShieldDamage, returnSpecifics);

            if (!returnSpecifics)
                return null;
            else
                return (String.IsNullOrWhiteSpace(combatResolution) ? "" : combatResolution)
                    + (String.IsNullOrWhiteSpace(defenderDamageResolution) ? "" : defenderDamageResolution)
                    + (String.IsNullOrWhiteSpace(attackerDamageResolution) ? "" : attackerDamageResolution);
        }


        public string AllocateDamage(TacticalUnit recipient, int damageToAllocate, int percentageChanceOfMultiShieldDamage, bool returnSpecifics)
        {
            //Determine whether or not we'll be applying damage via 2 different shield angles
            Random random = new Random();
            int randomVal = random.Next(0, 100);

            //if (percentageChanceOfMultiShieldDamage <

            throw new NotImplementedException();
        }


        public string ResolveCombat(TacticalUnit attacker, TacticalUnit defender, bool allowDamageToAttacker, out int attackerDamage, out int defenderDamage, bool returnSpecifics)
        {
            string specifics = null;

            Random random = new Random();
            int attackerRandomVal = random.Next(0, 20);
            int defenderRandomVal = random.Next(0, 20);

            int attackerBonus = 0;
            int defenderBonus = 0;

            if (attacker.CommandingOfficer != null)
                attackerBonus = attacker.CommandingOfficer.Skill;

            if (attacker.SpecialAbilities != null)
                attackerBonus += attacker.SpecialAbilities.Where(x => x.IsActive).Sum(y => y.AttackBonus);

            if (defender.CommandingOfficer != null)
                defenderBonus = defender.CommandingOfficer.Skill;

            if (defender.SpecialAbilities != null)
                defenderBonus += defender.SpecialAbilities.Where(x => x.IsActive).Sum(y => y.DefenseBonus);

            if ((attacker.AttackRatingCurrent + attackerBonus + attackerRandomVal) > (defender.AttackRatingCurrent + defenderBonus + defenderRandomVal))
            {
                //Attacker wins
                defenderDamage = 
                    (attacker.AttackRatingCurrent + attackerBonus + attackerRandomVal) - (defender.AttackRatingCurrent + defenderBonus + defenderRandomVal);

                attackerDamage = 0;
            }
            else
            {
                //Defender's score is equal to or greater than attacker's -- defender wins
                defenderDamage = 0;

                if (allowDamageToAttacker)
                    attackerDamage =
                        (defender.AttackRatingCurrent + defenderBonus + defenderRandomVal) - (attacker.AttackRatingCurrent + attackerBonus + attackerRandomVal);
                else
                    attackerDamage = 0;
            }

            specifics = String.Format(
                "{0} current attack rating: {1}, bonus: {2}, random value: {3} - {4} current defense rating: {5}, bonus: {6}, random value: {7} - " +
                    "{0} damage taken = {8}, {9} damage taken = {10}",
                attacker.Name, 
                attacker.AttackRatingCurrent, 
                attackerBonus, 
                attackerRandomVal, 
                defender.Name, 
                defender.DefenseRatingCurrent, 
                defenderBonus, 
                defenderRandomVal, 
                attackerDamage, 
                defenderDamage);

            return specifics;
        }
    }
}
