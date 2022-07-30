using FileManager.CommandHandlers.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileManager.CommandHandlers;
public class DirectoryCommandHandler : CommandHandler
{
    private readonly IUserInterface _UserInterface;
    private readonly DirectoryInfo _Directory;

    public override void Copy(string path)
    {
    }

    public override void Create(string path)
    {
    }

    public override void Delete()
    {
    }

    public override void DrawTree()
    {
    }

    public override void Info()
    {
    }

    public override void PrintStatistics()
    {
        throw new NotImplementedException();
    }

    public override void Relocate(string path)
    {
    }

    public override void Rename(string name)
    {
    }

    public DirectoryCommandHandler(IUserInterface userInterface, DirectoryInfo directory)
    {
        _UserInterface = userInterface;
        _Directory = directory;
    }
}
