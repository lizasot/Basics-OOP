using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileManager.Commands.Base;

public abstract class FileManagerCommand
{
    public abstract void Emit(string[] args);
}
