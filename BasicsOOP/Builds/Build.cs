using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicsOOP.Builds;
public class Build
{
    private static int TotalBuild = 0;
    private int _ID;
    private int _Height;
    private int _Floors;
    private int _Apartments;
    private int _Entrances;

    public int ID
    {
        get { return _ID; }
    }
    public int Height
    {
        get { return _Height; }
        set
        {
            if (value > 0)
            {
                _Height = value;
            }
        }
    }
    public int Floors
    {
        get { return _Floors; }
        set
        {
            if (value > 0)
            {
                _Floors = value;
            }
        }
    }
    public int Apartments
    {
        get { return _Apartments; }
        set
        {
            if (value > 0)
            {
                _Apartments = value;
            }
        }
    }
    public int Entrances
    {
        get { return _Entrances; }
        set
        {
            if (value > 0)
            {
                _Entrances = value;
            }
        }
    }
    private static int GenerateIDBuild()
    {
        return ++TotalBuild;
    }

    public double FloorHeight()
    {
        return (double)_Height / (double)_Floors;
    }
    public int ApartmentsInEntrance()
    {
        return _Apartments / _Entrances;
    }
    public int ApartmentsPerFloor()
    {
        return _Apartments / (_Floors*_Entrances);
    }

    public Build()
    {
        _ID = GenerateIDBuild();
        _Height = 1;
        _Floors = 1;
        _Entrances = 1;
        _Apartments = 1;
    }
    public Build(int value)
    {
        _ID = GenerateIDBuild();
        Height = value;
        Floors = value;
        Entrances = value;
        Apartments = value;
    }
    public Build(int height, int floors, int apartments, int entrances)
    {
        _ID = GenerateIDBuild();
        Height = height;
        Floors = floors;
        Apartments = apartments;
        Entrances = entrances;
    }
}