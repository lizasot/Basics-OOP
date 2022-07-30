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
        _File.CopyTo(path);
    }

    public override void Create(string path)
    {
        throw new Exception("Указан файл, а необходима директория.");
    }

    public override void Delete()
    {
        _File.Delete();
    }

    public override void DrawTree(int page)
    {
        throw new Exception("Указан файл, а необходима директория.");
    }

    public override void Info()
    {
        _UserInterface.Write($"Сведения о файле {_File.Name}.\nРазмер: {_File.Length}\nАтрибуты: {_File.Attributes}");
    }

    public override void PrintStatistics()
    {
        using (StreamReader sr = File.OpenText(_File.FullName))
        {
            int totalSymbCount = 0;
            int lineCount = 0;
            int symbCount = 0; //без пробелов
            while (sr.Peek() != -1)
            {
                char c = (char)sr.Read();
                if (c == '\n')
                    lineCount++;
                if (c != ' ')
                    symbCount++;
                totalSymbCount++;
            }
            _UserInterface.Output($"Статистика файла {_File.Name}.\nКоличество символов: {totalSymbCount}.\nКоличество символов без пробелов: {symbCount}.\nКоличество строк: {lineCount}.");
        }
    }

    public override void Relocate(string path)
    {
        _File.MoveTo(path);
    }

    public override void Rename(string name)
    {        
        File.Move(_File.FullName, $"{Path.GetFullPath(_File.FullName)}{name}");
    }
    public FileCommandHandler(IUserInterface userInterface, FileInfo file)
    {
        _UserInterface = userInterface;
        _File = file;
    }
}
