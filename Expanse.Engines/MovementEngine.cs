using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Expanse.Domain.Things;
using Expanse.Domain.Spatial;
using Expanse.Engines.Interfaces;
using Expanse.Domain.Things.Interfaces;


namespace Expanse.Engines
{
    public class MovementEngine : IMovementEngine
    {
        public List<Nation> Nations { get; set; }
        public TacticalMap Map { get; set; }


        public MovementEngine(List<Nation> nations, TacticalMap map)
        {
            #region Guard Code
            if (nations == null)
                throw new ArgumentNullException("nations");

            if (!nations.Any())
                throw new ApplicationException("nations list must include at least one Nation.");

            if (map == null)
                throw new ArgumentNullException("map");
            #endregion Guard Code

            Nations = nations;
            Map = map;
        }


        public void ResolveMovement()
        {
            #region Guard Code
            if (Nations == null)
                throw new ArgumentNullException("nations");

            if (!Nations.Any())
                throw new ApplicationException("nations list must include at least one Nation.");

            if (Map == null)
                throw new ArgumentNullException("map");
            #endregion Guard Code

            //For each nation, loop through their Tactical Units in transit and attempt to move them
            foreach (var nation in Nations)
            {
                MoveTacticalGroups(nation);
                MoveTacticalUnits(nation);
            }
        }


        /// <summary>
        /// Moves all in-transit tactical groups for the specified nation
        /// </summary>
        /// <param name="nation"></param>
        private void MoveTacticalGroups(Nation nation)
        {
            if (nation == null)
                throw new ArgumentNullException("nation");

            foreach (var tacticalGroup in nation.TacticalGroups.Where(x => x.IsInTransit))
            {
                MoveAndCheckForCombat(tacticalGroup);
            }
        }


        /// <summary>
        /// Moves all in-transit tactical units for the specified nation
        /// </summary>
        /// <param name="nation"></param>
        private void MoveTacticalUnits(Nation nation)
        {
            if (nation == null)
                throw new ArgumentNullException("nation");

            foreach (var tacticalUnit in nation.TacticalUnits.Where(x => x.IsInTransit && x.TacticalGroupId == null))
            {
                MoveAndCheckForCombat(tacticalUnit);
            }
        }


        private void MoveAndCheckForCombat(ITacticalUnit unit)
        {
            unit.CurrentPosition = GetNextPosition(unit.CurrentPosition, unit.Destination, unit.Speed);
            IEnumerable<ITacticalUnit> willFightWith;
            if (ShouldCombatEnsue(unit, out willFightWith))
            {
                SetCombatStance(unit);
                foreach (var opponent in willFightWith)
                {
                    SetCombatStance(opponent);
                }
            }
        }


        /// <summary>
        /// Gets the next position based on the current position, destination position, and speed
        /// </summary>
        /// <param name="currentPosition"></param>
        /// <param name="destinationPosition"></param>
        /// <param name="speed"></param>
        /// <returns></returns>
        private Position GetNextPosition(Position currentPosition, Position destinationPosition, short speed)
        {
            Position nextPosition = new Position(currentPosition.X, currentPosition.Y, currentPosition.Z);

            for (int spacesLeft = speed; spacesLeft > 0; spacesLeft--)
            {
                nextPosition.X = GetAdjustedPositionVector(nextPosition.X, destinationPosition.X, 1);
                nextPosition.Y = GetAdjustedPositionVector(nextPosition.Y, destinationPosition.Y, 1);
                nextPosition.Z = GetAdjustedPositionVector(nextPosition.Z, destinationPosition.Z, 1);
            }

            return nextPosition;
        }


        /// <summary>
        /// Gets the adjusted vector based on the current position, destination position, and adjust by amount (speed)
        /// </summary>
        /// <param name="currentVector"></param>
        /// <param name="destinationVector"></param>
        /// <param name="adjustByAmount"></param>
        /// <returns></returns>
        private int GetAdjustedPositionVector(int currentVector, int destinationVector, int adjustByAmount)
        {
            if (currentVector == destinationVector)
                return currentVector;

            int adjustedVector = currentVector;

            for (int spacesLeft = adjustByAmount; spacesLeft > 0; spacesLeft--)
            {
                if (currentVector == destinationVector)
                    return adjustedVector;

                if (currentVector < destinationVector)
                    adjustedVector++;
                else
                    adjustedVector--;
            }

            return adjustedVector;
        }


        /// <summary>
        /// Determines whether or not combat should ensure for an IMoveAndFight based on its position and the position/disposition of any other IMoveAndFights
        /// in the same space
        /// </summary>
        /// <param name="unit"></param>
        /// <param name="willFightWith"></param>
        /// <returns></returns>
        private bool ShouldCombatEnsue(ITacticalUnit unit, out IEnumerable<ITacticalUnit> willFightWith)
        {
            //Is there another ITacticalUnit present in the same location? And if so, is it hostile?
            throw new NotImplementedException();
        }


        /// <summary>
        /// Sets an IMoveAndFight's properties for combat
        /// </summary>
        /// <param name="unit">The object to modify</param>
        private void SetCombatStance(ITacticalUnit unit)
        {
            unit.Destination = unit.CurrentPosition; //Stop right there!
            unit.IsInCombat = true;
        }
    }
}
