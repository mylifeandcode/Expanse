﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Expanse.Classes
{
    public class Unit
    {
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
        public Hero CommandingOfficer { get; set; }
        public int Power { get; set; }
        public short PowerCostPerMove { get; set; }
        public short PowerCostPerTacticalTurn { get; set; }
        public Guid ShipGroupId { get; set; }
        public int BodyNormal { get; set; }
        public int BodyCurrent { get; set; }
        public short SpeedNormal { get; set; }
        public short SpeedCurrent { get; set; }
        public int ResourceCost { get; set; }
        public int MaintenanceCostPerGameTurn { get; set; }
        public short CrewSkill { get; set; }
        public short TechLevel { get; set; }
        public Position CurrentPosition { get; set; }
        public Position DestinationPosition { get; set; }
    }
}
