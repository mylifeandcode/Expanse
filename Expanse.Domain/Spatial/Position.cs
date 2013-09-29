using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Expanse.Domain.Spatial
{
    public class Position : IEquatable<Position>
    {
        public int X { get; set; }
        public int Y { get; set; }
        public int Z { get; set; }

        public Position(int x, int y, int z)
        {
            X = x;
            Y = y;
            Z = z;
        }

        public bool Equals(Position other)
        {
            return this.X == other.X
                && this.Y == other.Y
                && this.Z == other.Z;
        }
    }
}
