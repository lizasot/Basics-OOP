using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileManager.CommandHandler;

public interface ICommands
{
    void Create();
    void Create(string path);
    void Copy(string path);
    void Relocate(string path);
    void Delete();
    void Rename();
    void Info();
}
