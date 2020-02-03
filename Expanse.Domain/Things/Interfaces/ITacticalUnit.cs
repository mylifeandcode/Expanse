using Expanse.Domain.Spatial;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Expanse.Domain.Things.Interfaces
{
    /// <summary>
    /// An interface defining properties of a tactical unit which can travel the game map and engage in combat.
    /// </summary>
    public interface ITacticalUnit
    {
        /// <summary>
        /// Where the unit currently is.
        /// </summary>
        Position CurrentPosition { get; set; }
        
        /// <summary>
        /// The unit's destination.
        /// </summary>
        Position Destination { get; set; }
        
        /// <summary>
        /// The intended destination of the unit. After combat is resolved, the player or AI will have the option to continue to their intended desitnation, or 
        /// to stay put.
        /// </summary>
        Position IntendedDestination { get; set; }
        
        /// <summary>
        /// Indicates whether or not the unit is in combat.
        /// </summary>
        bool IsInCombat { get; set; }
        
        /// <summary>
        /// The number of spaces per turn the unit moves.
        /// </summary>
        short Speed { get; }
    }
}
