using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileManager.CommandHandlers.Base;

public abstract class CommandHandler : ICommands
{
    public abstract void Copy(string path);
    public abstract void Create(string path);
    public abstract void Delete();
    public abstract void DrawTree();
    public abstract void Info();
    public abstract void PrintStatistics();
    public abstract void Relocate(string path);
    public abstract void Rename(string name);
}
