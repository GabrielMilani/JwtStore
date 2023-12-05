namespace JwtStore.Shared.Entities;

public abstract class Entity : IEquatable<int>
{
    public int Id { get; private set; }

    public bool Equals(int id)
        => Id == id;

    public override int GetHashCode()
        => Id.GetHashCode();
}