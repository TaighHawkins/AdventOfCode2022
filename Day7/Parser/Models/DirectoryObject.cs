namespace Day7.Parser.Models;

public abstract class DirectoryObject
{
    public DirectoryObject? Parent { get; }
    public string Name { get; }

    protected DirectoryObject(DirectoryObject? parent, string name)
    {
        Parent = parent;
        Name = name;
    }
    public abstract int GetSize();
    public abstract ObjectType GetObjectType();
    public abstract IEnumerable<DirectoryObject> GetChildren();
    public virtual void AddChild(DirectoryObject o) { }
}