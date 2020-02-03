using Expanse.Domain.Spatial;
using Expanse.Domain.Things;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Expanse.Engines.Interfaces
{
    public interface IMovementEngine
    {
        /// <summary>
        /// Resolves movement for all TacticalUnits/Groups which are in transit for all nations
        /// </summary>
        void ResolveMovement();

        /// <summary>
        /// Nations in use
        /// </summary>
        List<Nation> Nations { get; set; }

        /// <summary>
        /// The game map
        /// </summary>
        TacticalMap Map { get; set; }
    }
}
