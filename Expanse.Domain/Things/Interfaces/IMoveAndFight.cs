using Expanse.Domain.Spatial;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Expanse.Domain.Things.Interfaces
{
    public interface IMoveAndFight
    {
        Position CurrentPosition { get; set; }
        Position DestinationPosition { get; set; }
        bool IsInCombat { get; set; }
        short Speed { get; }
    }
}
