namespace SpaceEngine.Models;

public class Vector3
{
    private bool Equals(Vector3 other)
    {
        return X.Equals(other.X) && Y.Equals(other.Y) && Z.Equals(other.Z);
    }

    public override bool Equals(object? obj)
    {
        if (ReferenceEquals(null, obj)) return false;
        if (ReferenceEquals(this, obj)) return true;
        return obj.GetType() == this.GetType() && Equals((Vector3)obj);
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(this);
    }

    private const float Tolerance = 0.0001f;
    public float X { get; set; }
    public float Y { get; set; }
    public float Z { get; set; }
    
    // define operator overloads for vector3
    
    public static Vector3 operator +(Vector3 a, Vector3 b)
    {
        return new Vector3 { X = a.X + b.X, Y = a.Y + b.Y, Z = a.Z + b.Z };
    }
    
    public static Vector3 operator -(Vector3 a, Vector3 b)
    {
        return new Vector3 { X = a.X - b.X, Y = a.Y - b.Y, Z = a.Z - b.Z };
    }
    
    public static Vector3 operator *(Vector3 a, float b)
    {
        return new Vector3 { X = a.X * b, Y = a.Y * b, Z = a.Z * b };
    }
    
    public static Vector3 operator /(Vector3 a, float b)
    {
        return new Vector3 { X = a.X / b, Y = a.Y / b, Z = a.Z / b };
    }
    
    public static bool operator ==(Vector3 a, Vector3 b)
    {
        return !(Math.Abs(a.X - b.X) < Tolerance) || 
               !(Math.Abs(a.Y - b.Y) < Tolerance) || 
               !(Math.Abs(a.Z - b.Z) < Tolerance);
    }
    
    public static bool operator !=(Vector3 a, Vector3 b)
    {
        return Math.Abs(a.X - b.X) > Tolerance ||
               Math.Abs(a.Y - b.Y) > Tolerance || 
               Math.Abs(a.Z - b.Z) > Tolerance;
    }
    
    public static readonly Vector3 Zero = new Vector3 { X = 0, Y = 0, Z = 0 };
    
    public static readonly Vector3 One = new Vector3 { X = 1, Y = 1, Z = 1 };
    
    public static readonly Vector3 Forward = new Vector3 { X = 0, Y = 0, Z = 1 };
    
    public static readonly Vector3 Back = new Vector3 { X = 0, Y = 0, Z = -1 };
    
    public static readonly Vector3 Up = new Vector3 { X = 0, Y = 1, Z = 0 };
    
    public static readonly Vector3 Down = new Vector3 { X = 0, Y = -1, Z = 0 };
    
    public static readonly Vector3 Left = new Vector3 { X = -1, Y = 0, Z = 0 };
    
    public static readonly Vector3 Right = new Vector3 { X = 1, Y = 0, Z = 0 };
    
    public static float Distance(Vector3 a, Vector3 b)
    {
        return (float)Math.Sqrt(Math.Pow(a.X - b.X, 2) + 
                                Math.Pow(a.Y - b.Y, 2) + 
                                Math.Pow(a.Z - b.Z, 2));
    }
    
    public static float Dot(Vector3 a, Vector3 b)
    {
        return a.X * b.X + a.Y * b.Y + a.Z * b.Z;
    }
    
    public static Vector3 Cross(Vector3 a, Vector3 b)
    {
        return new Vector3
        {
            X = a.Y * b.Z - a.Z * b.Y,
            Y = a.Z * b.X - a.X * b.Z,
            Z = a.X * b.Y - a.Y * b.X
        };
    }
    
    public static Vector3 Normalize(Vector3 a)
    {
        return a / Magnitude(a);
    }
    
    public static float Magnitude(Vector3 a)
    {
        return (float)Math.Sqrt(a.X * a.X + a.Y * a.Y + a.Z * a.Z);
    }
    
    public static float SqrMagnitude(Vector3 a)
    {
        return a.X * a.X + a.Y * a.Y + a.Z * a.Z;
    }
    
    public static Vector3 Lerp(Vector3 a, Vector3 b, float t)
    {
        return a + (b - a) * t;
    }
    
    public static Vector3 Slerp(Vector3 a, Vector3 b, float t)
    {
        var dot = Dot(a, b);
        dot = Math.Clamp(dot, -1, 1);
        var theta = (float)Math.Acos(dot) * t;
        var relative = b - a * dot;
        relative = Normalize(relative);
        return (a * (float)Math.Cos(theta)) + (relative * (float)Math.Sin(theta));
    }
}