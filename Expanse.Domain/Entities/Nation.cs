using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Expanse.Domain.Spatial;

namespace Expanse.Domain.Entities
{
    public class Nation
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Summary { get; set; }
        public List<TacticalTerritory> Territories { get; set; }
        public List<TacticalGroup> TacticalGroups { get; set; }
        public List<TacticalUnit> TacticalUnits { get; set; }
        public List<Commander> Commanders { get; set; }
        public List<Diplomat> Diplomats { get; set; }
        
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

        public bool Active { get; set; }

        //TODO: Spies in V2

        //TODO: Tactical Groups?

        public Nation()
        {
            this.TacticalGroups = new List<TacticalGroup>();
            this.TacticalUnits = new List<TacticalUnit>();
        }
    }
}
