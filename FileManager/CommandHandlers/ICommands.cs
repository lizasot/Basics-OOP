using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileManager.CommandHandlers;

public interface ICommands
{
    void Create(string path);
    void Copy(string path);
    void Relocate(string path);
    void Delete();
    void Rename(string name);
    void Info();
    public void PrintStatistics();
    public void DrawTree(int page);
}
