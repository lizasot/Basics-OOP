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
        if (Directory.Exists(path))
        {
            if (path[path.Length - 1] != '\\')
            {
                File.Copy(_File.FullName, $"{path}\\{_File.Name}");
            }
            else
            {
                File.Copy(_File.FullName, $"{path}{_File.Name}");
            }
        }
        else
        {
            File.Copy(_File.FullName, path);
        }
    }

    public override void Delete()
    {
        _UserInterface.Write($"Вы уверены, что хотите удалить следующий файл:\n{_File.FullName}?");
        if (_UserInterface.ReadLine("Введите \"да\" для продолжения удаления объекта > ") == "да")
        {
            _File.Delete();
        }
        else
        {
            _UserInterface.Write("Удаление отменено.");
        }
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
        if (Directory.Exists(path))
        {
            if (path[path.Length - 1] != '\\')
            {
                _File.MoveTo($"{path}\\{_File.Name}");
            }
            else
            {
                _File.MoveTo($"{path}{_File.Name}");
            }
        }
        else
        {
            _File.MoveTo(path);
        }
    }

    public override void Rename(string name)
    {
        File.Move(_File.FullName, $"{Path.GetDirectoryName(_File.FullName)}\\{name}");
    }

    public override void Create(string path, string name)
    {
        File.Create($"{path}{name}");
    }

    public override void CreateDir(string name)
    {
        throw new Exception("Указан файл, а необходима директория.");
    }

    public override void CreateFile(string name)
    {
        throw new Exception("Указан файл, а необходима директория.");
    }

    public override void SetAttributes(string attribute)
    {
        //Archive | Hidden | ReadOnly
        FileAttributes attributes = File.GetAttributes(_File.FullName);
        switch (attribute.ToLower())
        {
            case "archive":
                if ((attributes & FileAttributes.Archive) == FileAttributes.Archive)
                {
                    //убирает Archive
                    File.SetAttributes(_File.FullName, attributes & ~FileAttributes.Archive);
                }
                else
                {
                    //устанавливает Archive
                    File.SetAttributes(_File.FullName, attributes | FileAttributes.Archive);
                }
                break;
            case "hidden":
                if ((attributes & FileAttributes.Hidden) == FileAttributes.Hidden)
                {
                    //убирает Hidden
                    File.SetAttributes(_File.FullName, attributes & ~FileAttributes.Hidden);
                }
                else
                {
                    //устанавливает Hidden
                    File.SetAttributes(_File.FullName, attributes | FileAttributes.Hidden);
                }
                break;
            case "readonly":
                if ((attributes & FileAttributes.ReadOnly) == FileAttributes.ReadOnly)
                {
                    //убирает Hidden
                    File.SetAttributes(_File.FullName, attributes & ~FileAttributes.ReadOnly);
                }
                else
                {
                    //устанавливает Hidden
                    File.SetAttributes(_File.FullName, attributes | FileAttributes.ReadOnly);
                }
                break;
            default:
                throw new Exception("Неизвестное имя атрибута");
        }
    }

    public override void Search(string mask, int page)
    {
        throw new Exception("Указан файл, а необходима директория.");
    }

    public FileCommandHandler(IUserInterface userInterface, FileInfo file)
    {
        _UserInterface = userInterface;
        _File = file;
    }
}
