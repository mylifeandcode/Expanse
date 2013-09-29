﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Expanse.Domain.Entities;
using Expanse.Domain.Spatial;

namespace Expanse.Engines
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

    public class MovementEngine : IMovementEngine
    {
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

        public List<Nation> Nations { get; set; }
        public TacticalMap Map { get; set; }

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
                tacticalGroup.CurrentPosition = GetNextPosition(tacticalGroup.CurrentPosition, tacticalGroup.DestinationPosition, tacticalGroup.Speed);
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

            foreach (var tacticalUnit in nation.TacticalUnits.Where(x => x.IsInTransit))
            {
                tacticalUnit.CurrentPosition = GetNextPosition(tacticalUnit.CurrentPosition, tacticalUnit.DestinationPosition, tacticalUnit.SpeedCurrent);
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
    }
}
