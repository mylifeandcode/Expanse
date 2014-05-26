using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Expanse.Domain.Spatial;

namespace Expanse.Domain.Things
{
    public class TacticalGroup
    {
        #region Fields

        private Guid _id;
        private List<TacticalUnit> _tacticalUnits;

        #endregion Fields

        #region Properties

        public IReadOnlyList<TacticalUnit> TacticalUnits { get { return _tacticalUnits; } }
        
        public bool IsInTransit
        {
            get
            {
                /*
                if (TacticalUnits == null || !TacticalUnits.Any())
                    return false;
                else
                    return TacticalUnits.Any(x => x.IsInTransit);
                */

                if (CurrentPosition == null || DestinationPosition == null)
                    return false;
                else
                    return !CurrentPosition.Equals(DestinationPosition);
            }
        }

        public Position CurrentPosition 
        {
            get
            {
                if (this.TacticalUnits != null && this.TacticalUnits.Any())
                    return this.TacticalUnits.First().CurrentPosition; //All should have the same current position
                else
                    return null;
            }

            set
            {
                if (this.TacticalUnits != null && this.TacticalUnits.Any())
                {
                    this.TacticalUnits.ToList().ForEach(x => x.CurrentPosition = value);
                }
            }
        }

        public Position DestinationPosition { get; set; }
        public short Speed
        {
            get
            {
                if (!IsInTransit)
                    return 0;
                else if (TacticalUnits == null || !TacticalUnits.Any())
                    return 0;
                else
                    return TacticalUnits.Min(x => x.SpeedCurrent); //Can only move as fast as the slowest member of the group
            }
        }

        public bool IsInCombat
        {
            get { return this.TacticalUnits != null && this.TacticalUnits.Any(x => x.IsInCombat); }

            set
            {
                if (this.TacticalUnits != null)
                    this.TacticalUnits.ToList().ForEach(x => x.IsInCombat = value);
            }
        }

        #endregion Properties


        public TacticalGroup()
        {
            _id = new Guid();
            _tacticalUnits = new List<TacticalUnit>();
        }


        #region Public Methods

        public void AddTacticalUnit(TacticalUnit tacticalUnit)
        {
            tacticalUnit.TacticalGroupId = _id;
            _tacticalUnits.Add(tacticalUnit);
        }


        public void RemoveTacticalUnit(TacticalUnit tacticalUnit)
        {
            tacticalUnit.TacticalGroupId = null;
            _tacticalUnits.Remove(tacticalUnit);
        }

        #endregion Public Methods
    }
}
