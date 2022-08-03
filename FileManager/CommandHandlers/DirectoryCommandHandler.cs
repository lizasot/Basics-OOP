using FileManager.CommandHandlers.Base;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileManager.CommandHandlers;
public class DirectoryCommandHandler : CommandHandler
{
    private readonly IUserInterface _UserInterface;
    private readonly DirectoryInfo _Directory;

    private void CopyCatalogue(DirectoryInfo dir, string destinationDir)
    {
        DirectoryInfo[] dirs = dir.GetDirectories();

        // Создаёт текущий каталог в папке назначения
        Directory.CreateDirectory(destinationDir);

        // Файлы в исходном каталоге копируются в конечный
        foreach (FileInfo file in dir.GetFiles())
        {
            string targetFilePath = Path.Combine(destinationDir, file.Name);
            file.CopyTo(targetFilePath);
        }

        //На каждую папку в текущем каталоге вызывается этот же метод рекурсивно
        foreach (DirectoryInfo subDir in dirs)
        {
            string newDestinationDir = Path.Combine(destinationDir, subDir.Name);
            CopyCatalogue(subDir, newDestinationDir);
        }
    }

    public override void Copy(string path)
    {
        string newDestinationDir = Path.Combine(path, _Directory.Name);
        CopyCatalogue(_Directory, newDestinationDir);
    }

    private void DeleteCatalogue(string sourceDir)
    {
        var dir = new DirectoryInfo(sourceDir);
        if (!dir.Exists)
            throw new DirectoryNotFoundException($"Исходный каталог не найден: {dir.FullName}");

        DirectoryInfo[] dirs = dir.GetDirectories();

        // Каждый файл в текущем каталоге удаляется
        foreach (FileInfo file in dir.GetFiles())
        {
            file.Delete();
        }

        //На каждую папку в текущем каталоге вызывается этот же метод рекурсивно
        foreach (DirectoryInfo subDir in dirs)
        {
            DeleteCatalogue(subDir.FullName);
        }

        // После удаления предыдущих каталогов и файлов (если есть), удаляется текущий каталог
        Directory.Delete(sourceDir);
    }

    public override void Delete()
    {
        _UserInterface.Write($"Вы уверены, что хотите удалить следующий каталог и всё его содержимое:\n{_Directory.FullName}?");
        if (_UserInterface.ReadLine("Введите \"да\" для продолжения удаления объекта > ") == "да")
        {
            DeleteCatalogue(_Directory.FullName);
        }
        else
        {
            _UserInterface.Write("Удаление отменено.");
        }
    }

    private long CalcSize(DirectoryInfo dir)
    {
        if (!dir.Exists)
            throw new DirectoryNotFoundException($"Исходный каталог не найден: {dir.FullName}");
        DirectoryInfo[] dirs = dir.GetDirectories();
        long size = 0;
        foreach (FileInfo file in dir.GetFiles())
        {
            size += file.Length;
        }
        foreach (DirectoryInfo subDir in dirs)
        {
            size += CalcSize(subDir);
        }
        return size;
    }

    public override void Info()
    {
        long len = CalcSize(_Directory);
        _UserInterface.Write($"Сведения о каталоге {_Directory.Name}.\nРазмер: {len}\nАтрибуты: {_Directory.Attributes}");
    }

    public override void PrintStatistics()
    {
        throw new Exception("Указана директория, а необходим файл.");
    }

    public override void Relocate(string path)
    {
        Copy(path);
        DeleteCatalogue(_Directory.FullName);
    }

    public override void Rename(string name)
    {
        Directory.Move(_Directory.FullName, $"{Path.GetDirectoryName(_Directory.FullName)}\\{name}");
    }

    public override void Create(string path, string name)
    {
        throw new NotImplementedException();
    }

    public override void CreateDir(string name)
    {
        if (Directory.Exists(Path.GetDirectoryName(name)))
        {
            Directory.CreateDirectory(name);
        }
        else
        {
            Directory.CreateDirectory($"{_Directory.FullName}\\{name}");
        }
    }

    public override void CreateFile(string name)
    {
        if (Directory.Exists(Path.GetDirectoryName(name)))
        {
            File.Create(name);
        }
        else
        {
            File.Create($"{_Directory.FullName}\\{name}");
        }
    }

    private void AddAllFiles(StringBuilder tree, FileInfo[] subFiles, string indent)
    {
        for (int i = 0; i < subFiles.Length; i++)
        {
            tree.Append(indent);
            tree.Append((i == subFiles.Length - 1) ? "└" : "├");
            tree.Append(subFiles[i].Name + "\n");
        }
    }

    private void GetTree(StringBuilder tree, DirectoryInfo dir, string indent, bool lastDirectory)
    {
        tree.Append(indent);
        tree.Append(lastDirectory ? "└" : "├");
        tree.Append(dir.Name + "\n");

        indent += lastDirectory ? " " : "│ ";

        FileInfo[] subFiles = dir.GetFiles();
        DirectoryInfo[] subDirs = dir.GetDirectories();
        for (int i = 0; i < subDirs.Length; i++)
        {
            GetTree(tree, subDirs[i], indent, ((i == subDirs.Length - 1) && (subFiles.Length == 0)));
        }
        AddAllFiles(tree, subFiles, indent);
    }

    public override void DrawTree(int page)
    {
        StringBuilder tree = new StringBuilder();
        GetTree(tree, _Directory, "", true);
        if (!int.TryParse(ConfigurationManager.AppSettings.Get("PageLines"), out int pageLines))
        {
            pageLines = 16;
        }
        string[] lines = tree.ToString().Split('\n');
        int totalPage = (lines.Length + pageLines - 1) / pageLines;
        if (page > totalPage)
        {
            page = totalPage;
        }
        else if (page <= 0)
        {
            page = 1;
        }
        var output = new StringBuilder();
        for (int i = (pageLines * (page - 1)), counter = 0; i < (pageLines * page); i++, counter++)
        {
            if (i < lines.Length - 1)
            {
                output.AppendLine(lines[i]);
            }
            else
            {
                output.Append("\n");
            }
        }
        string infoPage = $"{page} из {totalPage}";
        output.Append(infoPage);
        _UserInterface.Output(output.ToString());
    }

    public override void SetAttributes(string attribute)
    {
        throw new Exception("Указана директория, а необходим файл.");
    }

    private bool CorrectName(string name, string mask)
    {
        bool correct = true;
        int iName = 0;
        int iUnknownSymb = -1;

        for (int i = 0; i < mask.Length; i++)
        {
            if (iUnknownSymb == i)
            {
                if (iName >= name.Length)
                {
                    correct = false;
                    break;
                }

                if (mask[i] == '?' && iName + 1 < name.Length)
                {
                    iUnknownSymb++;
                    iName++;
                    continue;
                }

                while (name[iName] != mask[i])
                {
                    iName++;
                    if (iName >= name.Length)
                    {
                        correct = false;
                        break;
                    }
                }
            }

            if (mask[i] != '?' && mask[i] != '*')
            {
                if (iName >= name.Length)
                {
                    correct = false;
                    break;
                }

                if (mask[i] == name[iName])
                {
                    iName++;
                    continue;
                }
                else
                {
                    correct = false;
                    break;
                }
            }
            else
            {
                if (mask[i] == '?')
                {
                    if (iName >= name.Length)
                    {
                        correct = false;
                        break;
                    }
                    iName++;
                    continue;
                }
                else //'*'
                {
                    iUnknownSymb = i + 1;
                    continue;
                }
            }
        }

        return correct;
    }

    private void CheckAllFiles(StringBuilder foundObj, FileInfo[] subFiles, string mask)
    {
        for (int i = 0; i < subFiles.Length; i++)
        {
            if (CorrectName(subFiles[i].Name, mask))
            {
                foundObj.Append($"{subFiles[i].FullName}\n");
            }
        }
    }

    private void GetObjList(StringBuilder foundObj, DirectoryInfo dir, string mask)
    {
        if (CorrectName(dir.Name,mask))
        {
            foundObj.Append($"{dir.FullName}\n");
        }
        FileInfo[] subFiles = dir.GetFiles();
        DirectoryInfo[] subDirs = dir.GetDirectories();
        for (int i = 0; i < subDirs.Length; i++)
        {
            GetObjList(foundObj, subDirs[i], mask);
        }
        CheckAllFiles(foundObj, subFiles, mask);
    }

    public override void Search(string mask, int page)
    {
        StringBuilder foundObj = new StringBuilder();
        GetObjList(foundObj, _Directory, mask);
        if (!int.TryParse(ConfigurationManager.AppSettings.Get("PageLines"), out int pageLines))
        {
            pageLines = 16;
        }
        string[] lines = foundObj.ToString().Split('\n');
        int totalPage = (lines.Length + pageLines - 1) / pageLines;
        if (page > totalPage)
        {
            page = totalPage;
        }
        else if (page <= 0)
        {
            page = 1;
        }
        var output = new StringBuilder();
        for (int i = (pageLines * (page - 1)), counter = 0; i < (pageLines * page); i++, counter++)
        {
            if (i < lines.Length - 1)
            {
                output.AppendLine(lines[i]);
            }
            else
            {
                output.Append("\n");
            }
        }
        string infoPage = $"{page} из {totalPage}";
        output.Append(infoPage);
        _UserInterface.Output(output.ToString());
    }

    public DirectoryCommandHandler(IUserInterface userInterface, DirectoryInfo directory)
    {
        _UserInterface = userInterface;
        _Directory = directory;
    }
}
