using System;
using System.Collections.Generic;
using Expanse.Domain.Things;
using Expanse.Domain.Spatial;
using Expanse.Engines;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Expanse.UnitTests.Engines
{
    [TestClass]
    public class MovementEngineUnitTests
    {
        private List<Nation> _nations;
        private TacticalMap _map;

        [TestInitialize]
        public void Setup()
        {
            _nations = new List<Nation>();
            _nations.Add(new Nation() { Name = "Nation1" });
            _nations.Add(new Nation() { Name = "Nation2" });

            _map = new TacticalMap();
        }


        [TestMethod, TestCategory("Engines")]
        public void MovementEngine_ResolveMovement_Should_Move_Tactical_Unit()
        {
            //ASSIGN
            Position startingPosition = new Position(5, 5, 5);
            Position destinationPosition = new Position(4, 3, 9);
            TacticalUnit tacticalUnit = new TacticalUnit()
            {
                CurrentPosition = startingPosition,
                Destination = destinationPosition,
                Speed = 3
            };

            _nations[0].TacticalUnits.Add(tacticalUnit);

            MovementEngine engine = new MovementEngine(_nations, _map);

            //ACT
            engine.ResolveMovement();

            //ASSERT
            Assert.IsFalse(startingPosition.Equals(tacticalUnit.CurrentPosition));
            Assert.AreEqual(4, tacticalUnit.CurrentPosition.X);
            Assert.AreEqual(3, tacticalUnit.CurrentPosition.Y);
            Assert.AreEqual(8, tacticalUnit.CurrentPosition.Z);
        }


        [TestMethod, TestCategory("Engines")]
        public void MovementEngine_ResolveMovement_Should_Move_Tactical_Group()
        {
            //Should move the tactical group and its tactical units, but should not move the tactical units again AFTER moving the group

            //ASSIGN
            Position startingPosition = new Position(5, 5, 5);
            Position destinationPosition = new Position(4, 3, 9);
            TacticalUnit tacticalUnit = new TacticalUnit()
            {
                CurrentPosition = startingPosition,
                Destination = destinationPosition,
                Speed = 3
            };

            TacticalGroup tacticalGroup = new TacticalGroup
            {
                CurrentPosition = startingPosition,
                Destination = destinationPosition
            };

            //tacticalGroup.TacticalUnits.Add(tacticalUnit);
            tacticalGroup.AddTacticalUnit(tacticalUnit);

            _nations[0].TacticalUnits.Add(tacticalUnit);
            _nations[0].TacticalGroups.Add(tacticalGroup);

            MovementEngine engine = new MovementEngine(_nations, _map);

            //ACT
            engine.ResolveMovement();

            //ASSERT
            Assert.IsFalse(startingPosition.Equals(tacticalUnit.CurrentPosition));
            Assert.IsFalse(startingPosition.Equals(tacticalGroup.CurrentPosition));
            Assert.AreEqual(4, tacticalUnit.CurrentPosition.X);
            Assert.AreEqual(3, tacticalUnit.CurrentPosition.Y);
            Assert.AreEqual(8, tacticalUnit.CurrentPosition.Z);
            Assert.AreEqual(4, tacticalGroup.CurrentPosition.X);
            Assert.AreEqual(3, tacticalGroup.CurrentPosition.Y);
            Assert.AreEqual(8, tacticalGroup.CurrentPosition.Z);
        }
    }
}
