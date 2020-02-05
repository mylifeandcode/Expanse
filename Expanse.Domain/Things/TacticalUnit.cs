using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Expanse.Domain.Spatial;
using Expanse.Domain.Things.Interfaces;

namespace Expanse.Domain.Things
{
    public class TacticalUnit : ITacticalUnit
    {
        #region Properties
        public short NationId { get; set; }
        public string Name { get; set; }
        public string Classification { get; set; }
        public string ClassificationDescription { get; set; }
        public short Affiliation { get; set; }
        public short AttackRatingNormal { get; set; }
        public short AttackRatingCurrent { get; set; }
        public short DefenseRatingNormal { get; set; }
        public short DefenseRatingCurrent { get; set; }
        public List<short> Shields { get; set; }
        public List<Modifier> SpecialAbilities { get; set; }
        public Commander CommandingOfficer { get; set; }
        public int Power { get; set; }
        public short PowerCostPerMove { get; set; }
        public short PowerCostPerTacticalTurn { get; set; }
        public Guid? TacticalGroupId { get; set; }
        public int BodyNormal { get; set; }
        public int BodyCurrent { get; set; }
        public short SpeedNormal { get; set; }
        public short Speed { get; set; }
        public int ResourceCost { get; set; }
        public int MaintenanceCostPerGameTurn { get; set; }
        public short CrewSkill { get; set; }
        public short TechLevel { get; set; }
        public Position CurrentPosition { get; set; }
        public Position Destination { get; set; }
        
        public bool IsInTransit
        {
            get
            {
                if (CurrentPosition == null || Destination == null)
                    return false;
                else
                    return !CurrentPosition.Equals(Destination);
            }
        }

        public bool IsInCombat { get; set; }
        public Position IntendedDestination { get; set; }

        public void ResumeMoving()
        {
            Destination = IntendedDestination;
        }

        public void StopMoving()
        {
            Destination = null;
        }
        #endregion Properties

    }
}
