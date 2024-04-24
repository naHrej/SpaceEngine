namespace SpaceEngine.Models;

public class SpaceObject
{
    public int Id { get; set; }
    public int Dbref { get; set; } = -1;
    public Vector3 Position { get; set; } = Vector3.Zero;
    public Vector3 Velocity { get; set; } = Vector3.Zero;
    public Vector3 Acceleration { get; set; } = Vector3.Zero;
    public Vector3 AccelerationDelta { get; set; } = Vector3.Zero;
    public Vector3 Rotation { get; set; } = Vector3.Zero;
    public Vector3 RotationDelta { get; set; } = Vector3.Zero;
    public List<Force> Forces { get; set; } = new List<Force>();
    public float Mass { get; set; } = 0;
    public float Volume { get; set; } = 0;
}