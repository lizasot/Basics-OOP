using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Builds;
public class Creator
{
    private static int _TotalBuild;
    private static Dictionary<int, Build> _BuildList;
    public static int TotalBuild { get; }
    public static Dictionary<int, Build> BuildList
    {
        get { return _BuildList ?? (_BuildList = new Dictionary<int, Build>()); }
    }
    private static int GenerateIDBuild()
    {
        return ++_TotalBuild;
    }
    public static Build CreateBuild()
    {
        var build = new Build();
        build.ID = GenerateIDBuild();
        BuildList.Add(build.ID, build);
        return build;
    }
    public static Build CreateBuild(int value)
    {
        var build = new Build(value);
        build.ID = GenerateIDBuild();
        BuildList.Add(build.ID, build);
        return build;
    }
    public static Build CreateBuild(int height, int floors, int apartments, int entrances)
    {
        var build = new Build(height, floors, apartments, entrances);
        build.ID = GenerateIDBuild();
        BuildList.Add(build.ID, build);
        return build;
    }

    public static bool RemoveBuild(int id)
    {
        return BuildList.Remove(id);
    }

    private Creator()
    {
        _TotalBuild = 0;
        _BuildList = new Dictionary<int, Build>();
    }
}
