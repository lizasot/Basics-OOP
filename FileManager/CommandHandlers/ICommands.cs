using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileManager.CommandHandlers;

public interface ICommands
{
    void Create(string path, string name);
    void CreateFile(string name);
    void CreateDir(string name);
    void Copy(string path);
    void Relocate(string path);
    void Delete();
    void Rename(string name);
    void Info();
    void SetAttributes(string attribute);
    void PrintStatistics();
    void DrawTree(int page);
    void Search(string mask,int page);
}
