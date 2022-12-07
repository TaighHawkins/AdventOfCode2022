namespace Day7.Parser.Models;

public class File : DirectoryObject
{
    private readonly string _name;
    private readonly int _size;

    public File(DirectoryObject? parent, string name, int size) : base(parent)
    {
        _name = name;
        _size = size;
    }
    
    public override ObjectType GetObjectType()
    {
        return ObjectType.File;
    }

    public override string GetName()
    {
        return _name;
    }

    public override IEnumerable<DirectoryObject> GetChildren()
    {
        return Array.Empty<DirectoryObject>();
    }

    public override void AddChild(DirectoryObject? o)
    {
        throw new InvalidOperationException("Unable to add children to a file");
    }

    public override int GetSize()
    {
        return _size;
    }
}