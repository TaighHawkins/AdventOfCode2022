namespace Day7.Parser.Models;

public abstract class DirectoryObject
{
    internal protected DirectoryObject _parent;

    protected DirectoryObject(DirectoryObject parent)
    {
        _parent = parent;
    }
    public abstract int GetSize();
    public abstract ObjectType GetObjectType();
    public abstract string GetName();
    public abstract IEnumerable<DirectoryObject> GetChildren();
    public abstract void AddChild(DirectoryObject? o);

    public DirectoryObject GetParent()
    {
        return _parent;
    }
}