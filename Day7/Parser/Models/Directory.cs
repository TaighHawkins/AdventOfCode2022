namespace Day7.Parser.Models;

public class Directory : DirectoryObject
{
    private readonly List<DirectoryObject> _children = new();

    public Directory(DirectoryObject? parent, string name) : base(parent, name)
    {
    }

    public override IEnumerable<DirectoryObject> GetChildren()
    {
        return _children;
    }

    public override ObjectType GetObjectType()
    {
        return ObjectType.Directory;
    }

    public override int GetSize()
    {
        return _children.Sum(child => child.GetSize());
    }

    public override void AddChild(DirectoryObject o)
    {
        _children.Add(o);
    }
}