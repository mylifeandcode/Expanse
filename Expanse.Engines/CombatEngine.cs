using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Expanse.Domain.Things;
using Expanse.Engines.Interfaces;
using Expanse.Infrastructure.Interfaces;

namespace Expanse.Engines
{
    public class CombatEngine : IResolveCombat
    {
        private IAnnounce _announcer;

        public CombatEngine(IAnnounce announcer)
        {
            _announcer = announcer; //Can be null
        }


        #region Public Methods
        public void Attack(TacticalUnit attacker, TacticalUnit defender, int percentageChanceOfMultiShieldDamage, bool allowDamageToAttacker)
        {
            int attackerDamage;
            int defenderDamage;

            ResolveCombat(attacker, defender, allowDamageToAttacker, out attackerDamage, out defenderDamage);

            if (defenderDamage > 0)
                AllocateDamage(defender, defenderDamage, percentageChanceOfMultiShieldDamage);

            if (allowDamageToAttacker && attackerDamage > 0)
                AllocateDamage(attacker, attackerDamage, percentageChanceOfMultiShieldDamage);
        }


        public void AllocateDamage(TacticalUnit recipient, int damageToAllocate, int percentageChanceOfMultiShieldDamage)
        {
            //Determine whether or not we'll be applying damage via 2 different shield angles
            Random random = new Random();
            int randomVal = random.Next(0, 100);

            //if (percentageChanceOfMultiShieldDamage <

            throw new NotImplementedException();
        }


        public void ResolveCombat(TacticalUnit attacker, TacticalUnit defender, bool allowDamageToAttacker, out int attackerDamage, out int defenderDamage)
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

            if (_announcer != null)
                _announcer.Announce(String.Format(
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
                defenderDamage));
        }

        #endregion Public Methods
    }
}
