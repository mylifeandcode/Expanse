using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Expanse.Domain.Diplomacy;
using Expanse.Domain.Spatial;

namespace Expanse.Domain.Things
{
    public class Nation
    {
        //TODO: Implement an interface

        public short Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Summary { get; set; }
        public List<TacticalTerritory> Territories { get; set; }
        
        //TODO: Refactor the lists below into a single List<ITacticalUnit>
        public List<TacticalGroup> TacticalGroups { get; set; }
        public List<TacticalUnit> TacticalUnits { get; set; }
        
        public List<Commander> Commanders { get; set; }
        public List<Diplomat> Diplomats { get; set; }
        public List<Relationship> Relationships { get; set; } //TODO: Rethink RelationshipMatrix

        private const short MIN_VOLATILITY_RATING_FOR_COMBAT = 7; //TODO: Put this in a Game Settings class, loaded from config

        public int Resources
        {
            get
            {
                if (this.Territories != null && this.Territories.Any())
                    return this.Territories.Sum(x => x.Resources);
                else
                    return 0;
            }
        }

        public List<Modifier> Modifiers { get; set; }
        
        //TODO: ProductionQueue

        public bool IsActive { get; set; }

        //TODO: Spies in V2

        public Nation()
        {
            this.TacticalGroups = new List<TacticalGroup>();
            this.TacticalUnits = new List<TacticalUnit>();
        }

        public bool IsAtWarWith(short nationId)
        {
            return Relationships.Exists(relationship =>
                relationship.NationId == nationId
                    && relationship.AtWarWith);
        }

        public bool IsHostileTowardsNation(short nationId)
        {
            return Relationships.Exists(relationship => 
                relationship.NationId == nationId 
                    && relationship.AtWarWith || relationship.VolatilityTowards >= MIN_VOLATILITY_RATING_FOR_COMBAT);
        }

        public bool DeclaresWar(short nationId)
        {
            //Get a random number between 1 and 10. If it's higher than MIN_VOLATILITY_RATING_FOR_COMBAT, war is declared. 
            Random random = new Random();
            if (random.Next(1, 10) >= MIN_VOLATILITY_RATING_FOR_COMBAT)
            {
                return true;
            }
            else
                return false;
        }

        private void DeclareWarAgainstNation(short nationId)
        {
            var relationship = Relationships.First(relationship => relationship.NationId == nationId);
            relationship.AtWarWith = true;
            relationship.VolatilityTowards = 10; //TODO: Replace with a constant
            //TODO: Consider raising an event here
        }
    }
}
