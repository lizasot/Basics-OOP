using FileManager.Commands.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileManager.Commands;

public class CalcSizeCommand : FileManagerCommand
{
    private readonly IUserInterface _UserInterface;
    private readonly FileManagerLogic _FileManagerLogic;
    public override void Emit(string[] args)
    {
        if (args.Length > 1)
        {
            if (Directory.Exists(args[2]))
            {
                var dir = new DirectoryInfo(args[2]);
                long dirLen = 0;
                foreach (var file in dir.EnumerateFiles())
                {
                    dirLen += file.Length;
                }
                _UserInterface.Write($"Размер директории {dir.Name}: {dirLen}");
            }
            else if (File.Exists(args[2]))
            {
                var file = new FileInfo(args[2]);
                _UserInterface.Write($"Размер файла {file.Name}: {file.Length}");
            }
            else
            {
                throw new ArgumentException();
            }
        }
        else
        {
            var dir = _FileManagerLogic.CurrentDirectory;
            long dirLen = 0;
            foreach (var file in dir.EnumerateFiles())
            {
                dirLen += file.Length;
            }
            _UserInterface.Write($"Размер директории {dir.Name}: {dirLen}");
        }
    }

    public CalcSizeCommand(IUserInterface userInterface, FileManagerLogic fileManagerLogic)
    {
        _UserInterface = userInterface;
        _FileManagerLogic = fileManagerLogic;
    }
}
