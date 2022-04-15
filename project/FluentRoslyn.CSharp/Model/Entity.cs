namespace FluentRoslyn.CSharp.Model;

public record Entity
{
    public EntityName Name { get; }

    public Entity(string nameSingular, string namePlural)
    {
        Name = new(nameSingular, namePlural);
    }

    public string IdentifierType => $"{Name.Singular}Identity";
}