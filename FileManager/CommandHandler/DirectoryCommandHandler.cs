using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileManager.CommandHandler;

public class DirectoryCommandHandler
{
    private DirectoryInfo _Directory;
    public void DrawTree()
    {

    }
    public DirectoryCommandHandler(DirectoryInfo directory)
    {
        _Directory = directory;
    }
}
