namespace Day7.Parser.Models;

public class File : DirectoryObject
{
    private readonly int _size;

    public File(DirectoryObject? parent, string name, int size) : base(parent, name)
    {
        _size = size;
    }
    
    public override ObjectType GetObjectType()
    {
        return ObjectType.File;
    }

    public override IEnumerable<DirectoryObject> GetChildren()
    {
        return Array.Empty<DirectoryObject>();
    }

    public override int GetSize()
    {
        return _size;
    }
}