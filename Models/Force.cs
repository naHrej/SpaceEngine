namespace SpaceEngine.Models;

public class Force
{
    public int Id { get; set; }
    public SpaceObject Source { get; set; } = null!;
    public int SourceId { get; set; }
    public SpaceObject Target { get; set; } = null!;
    public int TargetId { get; set; }
    public Vector3 ForceVector { get; set; } = Vector3.Zero;
    public Vector3 TorqueVector { get; set; } = Vector3.Zero;
}