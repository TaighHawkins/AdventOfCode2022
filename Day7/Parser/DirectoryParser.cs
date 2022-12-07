using Day7.Parser.Models;
using Directory = Day7.Parser.Models.Directory;
using File = Day7.Parser.Models.File;

namespace Day7.Parser;

public class DirectoryParser
{
    private readonly string[] _input;
    private readonly DirectoryObject _root = new Directory(null, "/");
    private const string dir = nameof(dir);
    private const string cd = nameof(cd);
    private const string ls = nameof(ls);
    private const string DOLLAR = "$";
    private const string Up = "..";

    public DirectoryParser(string[] input)
    {
        _input = input;
    }

    public void ParseInput()
    {
        DirectoryObject currentDirectory = _root;
        for (var ii = 1; ii < _input.Length; ii++)
        {
            var split = _input[ii].Split(' ');
            switch (split[0])
            {
                case DOLLAR:
                    switch (split[1])
                    {
                        case cd:
                            string name = IdentifyName(split[2..]);
                            currentDirectory = name switch
                            {
                                Up => currentDirectory.GetParent(),
                                _ => currentDirectory.GetChildren()
                                    .Single(x => x.GetObjectType() == ObjectType.Directory && x.GetName() == name)
                            };
                            break;
                        case ls:
                            ii++;
                            AddChildrenToCurrent(currentDirectory, ref ii);
                            break;
                    }
                    break;
            }
        }
    }

    public Dictionary<string, int> GetDirectorySizes()
    {
        if (_root is null)
        {
            ParseInput();
        }
        
        var dict = new Dictionary<string, int>()
        {
            { _root.GetName(), _root.GetSize() }
        };

        GetSizesOfChildren(ref dict, 
            _root.GetChildren().Where(x => x.GetObjectType() == ObjectType.Directory),
            "");
        return dict;
    }

    private static void GetSizesOfChildren(ref Dictionary<string, int> dict, IEnumerable<DirectoryObject> children, string prefix)
    {
        foreach (var child in children)
        {
            var childName = $"{prefix}/{child.GetName()}";
            dict.Add(childName, child.GetSize());
            GetSizesOfChildren(ref dict, 
                child.GetChildren().Where(x => x.GetObjectType() == ObjectType.Directory),
                childName);
        }
    }

    private void AddChildrenToCurrent(DirectoryObject current, ref int index)
    {
        for (;; index++)
        {
            var line = _input[index];
            var split = line.Split(' ');
            switch (split[0])
            {
                case dir:
                    current.AddChild(new Directory(current, IdentifyName(split[1..])));
                    break;
                default:
                    var size = int.Parse(split[0]);
                    current.AddChild(new File(current, IdentifyName(split[1..]), size));
                    break;
            }

            var next = index + 1;
            if (next >= _input.Length || _input[index + 1].StartsWith(DOLLAR))
            {
                break;
            }
        }
    }

    private static string IdentifyName(params string[] namePieces)
    {
        string name = string.Join(" ", namePieces);
        return string.Equals("/", name, StringComparison.OrdinalIgnoreCase) ? "root" : name;
    }
}