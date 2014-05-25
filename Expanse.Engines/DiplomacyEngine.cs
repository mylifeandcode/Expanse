using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Expanse.Domain.Things;
using Expanse.Engines.Interfaces;

namespace Expanse.Engines
{
    public class DiplomacyEngine : ICoordinateDiplomacy
    {
        public bool WillCombatOccur(Nation nation1, Nation nation2)
        {
            throw new NotImplementedException();
        }
    }
}
