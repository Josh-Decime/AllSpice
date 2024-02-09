namespace AllSpice.Models;

public abstract class RepoItem<TypeId>
{
    public TypeId Id { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
}