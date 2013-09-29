using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Expanse.Domain.Entities
{
    public class Diplomat //: Modifier
    {
        public int NationId { get; private set; }
        public Dictionary<int, int> Skill { get; set; }

        public Diplomat(int nationId, Dictionary<int, int> skill)
        {
            NationId = nationId;
            Skill = skill;
        }
    }
}
