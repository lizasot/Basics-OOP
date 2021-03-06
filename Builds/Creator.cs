using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Builds;
public static class Creator
{
    private static int _TotalBuild;
    private static Dictionary<int, Build> _BuildList;
    public static int TotalBuild
    {
        get { return _TotalBuild; }
    }
    public static IReadOnlyDictionary<int, Build> BuildList => _BuildList ??= new Dictionary<int, Build>();
    private static int GenerateIDBuild()
    {
        return ++_TotalBuild;
    }
    public static Build CreateBuild()
    {
        var build = new Build();
        build.ID = GenerateIDBuild();
        _BuildList.Add(build.ID, build);
        return build;
    }
    public static Build CreateBuild(int value)
    {
        var build = new Build(value);
        build.ID = GenerateIDBuild();
        _BuildList.Add(build.ID, build);
        return build;
    }
    public static Build CreateBuild(int height, int floors, int apartments, int entrances)
    {
        var build = new Build(height, floors, apartments, entrances);
        build.ID = GenerateIDBuild();
        _BuildList.Add(build.ID, build);
        return build;
    }
    public static bool RemoveBuild(int id)
    {
        return _BuildList.Remove(id);
    }
}
