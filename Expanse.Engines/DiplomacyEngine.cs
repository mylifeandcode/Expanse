using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Expanse.Domain.Entities;

namespace Expanse.Engines
{
    public interface IDiplomacyEngine 
    {
        bool WillCombatOccur(Nation nation1, Nation nation2);
    }

    public class DiplomacyEngine : IDiplomacyEngine
    {
        public bool WillCombatOccur(Nation nation1, Nation nation2)
        {
            throw new NotImplementedException();
        }
    }
}
