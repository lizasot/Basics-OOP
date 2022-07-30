using FileManager.CommandHandlers.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileManager.CommandHandlers;

public class FileCommandHandler : CommandHandler
{
    private readonly IUserInterface _UserInterface;
    private readonly FileInfo _File;

    public override void Copy(string path)
    {
    }

    public override void Create(string path)
    {
        _UserInterface.Write($"File {_File.Name} to {path}");
    }

    public override void Delete()
    {
    }

    public override void DrawTree()
    {
        throw new NotImplementedException();
    }

    public override void Info()
    {
    }

    public override void PrintStatistics()
    {
    }

    public override void Relocate(string path)
    {
    }

    public override void Rename(string name)
    {
    }
    public FileCommandHandler(IUserInterface userInterface, FileInfo file)
    {
        _UserInterface = userInterface;
        _File = file;
    }
}
