namespace CodexTest 
{
    /// <summary>
    /// Represents a point in 3D space with X, Y, and Z coordinates.
    /// </summary>
    /// <remarks>
    /// Initializes a new instance of <see cref="Point3D"/> with the specified coordinates.
    /// </remarks>
    /// <param name="x">The X‐coordinate.</param>
    /// <param name="y">The Y‐coordinate.</param>
    /// <param name="z">The Z‐coordinate.</param>
    public struct Point3D(double x, double y, double z)
    {
        /// <summary>The X‐coordinate of this point.</summary>
        public double X = x;

        /// <summary>The Y‐coordinate of this point.</summary>
        public double Y = y;

        /// <summary>The Z‐coordinate of this point.</summary>
        public double Z = z;

        /// <summary>
        /// Returns a string representation of this <see cref="Point3D"/> in the form "(X, Y, Z)".
        /// </summary>
        /// <returns>A string formatted as "(X, Y, Z)".</returns>
        public override readonly string ToString() => $"({X}, {Y}, {Z})";

        /// <summary>
        /// Calculates and returns the squared distance between this point and another point.
        /// Avoids the expensive square‐root operation when you only need to compare distances.
        /// </summary>
        /// <param name="other">The other <see cref="Point3D"/> to which the squared distance is measured.</param>
        /// <returns>
        /// The squared Euclidean distance between this point and <paramref name="other"/>,
        /// computed as (dx*dx + dy*dy + dz*dz).
        /// </returns>
        public readonly double SquaredDistanceTo(Point3D other)
        {
            double dx = X - other.X;
            double dy = Y - other.Y;
            double dz = Z - other.Z;
            return dx * dx + dy * dy + dz * dz;
        }

        /// <summary>
        /// Calculates and returns the Euclidean (straight‐line) distance between this point and another point.
        /// </summary>
        /// <param name="other">The other <see cref="Point3D"/> to which the distance is measured.</param>
        /// <returns>The Euclidean distance between this point and <paramref name="other"/>.</returns>
        public readonly double DistanceTo(Point3D other)
        {
            return Math.Sqrt(SquaredDistanceTo(other));
        }

        //
        // ─── VECTOR‐RELATED OPERATORS ───────────────────────────────────────────────
        //

        /// <summary>
        /// Subtracting two points yields the <see cref="Vector3D"/> that goes from <paramref name="b"/> to <paramref name="a"/>.
        /// In other words, (a – b) = (dx, dy, dz), which you can treat as a vector.
        /// </summary>
        /// <param name="a">The point to subtract from (the “end” of the vector).</param>
        /// <param name="b">The point being subtracted (the “start" of the vector).</param>
        /// <returns>
        /// A <see cref="Vector3D"/> whose components are (a.X – b.X, a.Y – b.Y, a.Z – b.Z).
        /// </returns>
        public static Vector3D operator -(Point3D a, Point3D b)
            => new(a.X - b.X, a.Y - b.Y, a.Z - b.Z);

        /// <summary>
        /// Adding a <see cref="Vector3D"/> to a <see cref="Point3D"/> translates the point by that vector.
        /// </summary>
        /// <param name="p">The original point.</param>
        /// <param name="v">The vector to add.</param>
        /// <returns>
        /// A new <see cref="Point3D"/> whose coordinates are (p.X + v.X, p.Y + v.Y, p.Z + v.Z).
        /// </returns>
        public static Point3D operator +(Point3D p, Vector3D v)
            => new(p.X + v.X, p.Y + v.Y, p.Z + v.Z);

        /// <summary>
        /// Subtracting a <see cref="Vector3D"/> from a <see cref="Point3D"/> translates the point in the opposite direction.
        /// </summary>
        /// <param name="p">The original point.</param>
        /// <param name="v">The vector to subtract.</param>
        /// <returns>
        /// A new <see cref="Point3D"/> whose coordinates are (p.X – v.X, p.Y – v.Y, p.Z – v.Z).
        /// </returns>
        public static Point3D operator -(Point3D p, Vector3D v)
            => new(p.X - v.X, p.Y - v.Y, p.Z - v.Z);

        //
        // ─── EQUALITY ────────────────────────────────────────────────────────────────
        //

        /// <summary>
        /// Checks if two points have exactly the same coordinates.
        /// </summary>
        /// <param name="a">The first point.</param>
        /// <param name="b">The second point.</param>
        /// <returns>
        /// True if a.X == b.X, a.Y == b.Y, and a.Z == b.Z; otherwise false.
        /// </returns>
        public static bool operator ==(Point3D a, Point3D b)
            => a.X == b.X && a.Y == b.Y && a.Z == b.Z;

        /// <summary>
        /// Checks if two points differ in at least one coordinate.
        /// </summary>
        /// <param name="a">The first point.</param>
        /// <param name="b">The second point.</param>
        /// <returns>True if any of the coordinates differ; otherwise false.</returns>
        public static bool operator !=(Point3D a, Point3D b)
            => !(a == b);

        /// <summary>
        /// Determines whether this instance and a specified object, which must be a <see cref="Point3D"/>, have the same value.
        /// </summary>
        public override readonly bool Equals(object? obj)
            => obj is Point3D p && this == p;

        /// <summary>
        /// Returns the hash code for this point, based on its coordinates.
        /// </summary>
        public override readonly int GetHashCode()
            => HashCode.Combine(X, Y, Z);
    }
}
