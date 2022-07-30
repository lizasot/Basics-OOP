using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileManager.CommandHandler.Base;

public abstract class CommandHandler : ICommands
{
    private readonly IUserInterface _UserInterface;

    public void Copy(string path)
    {
        throw new NotImplementedException();
    }

    public void Create()
    {
        throw new NotImplementedException();
    }

    public void Create(string path)
    {
        throw new NotImplementedException();
    }

    public void Delete()
    {
        throw new NotImplementedException();
    }

    public void Info()
    {
        throw new NotImplementedException();
    }

    public void Relocate(string path)
    {
        throw new NotImplementedException();
    }

    public void Rename()
    {
        throw new NotImplementedException();
    }
    public CommandHandler(IUserInterface userInterface)
    {
        _UserInterface = userInterface;
    }
}
