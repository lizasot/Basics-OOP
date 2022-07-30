using System.Text;
using FileManager.CommandHandlers;

namespace FileManager;

public class FileManagerLogic
{
    private readonly IUserInterface _UserInterface;
    private DirectoryInfo _CurrentDirectory = new("C:\\");
    public DirectoryInfo CurrentDirectory 
    {
        get => _CurrentDirectory;
    }
    public string PrintCommand()
    {
        var commandList = new StringBuilder();
        commandList.AppendLine("Список команд:");
        commandList.AppendLine("cd: Сменить текущую директорию");
        commandList.AppendLine("new: Создать папку/файл в указанную директорию");
        commandList.AppendLine("cp: Копирует папку/файл в указанную директорию");
        commandList.AppendLine("reloc: Перемещает папку/файл в указанную директорию");
        commandList.AppendLine("rm: Удаляет папку/файл");
        commandList.AppendLine("name: Устанавливает имя у указонного файла/папки");
        commandList.AppendLine("info: Выводит информацию о файле/папке");
        commandList.AppendLine("stat: Выводит сведения о содержимом файла");
        commandList.AppendLine("ls: Постраничный вывод содержимого папки");
        commandList.AppendLine("quit: Выход из программы");
        return commandList.ToString();
    }
    public void ChangeDirectory(string path)
    {
        if (Directory.Exists(path))
        {
            _CurrentDirectory = new(path);
        }
        else
        {
            throw new Exception($"Неправильно указан путь {path}.");
        }
    }
    public ICommands CurrentObj(string path)
    {
        if (Directory.Exists(path))
        {
            return new DirectoryCommandHandler(_UserInterface, new DirectoryInfo(path));
        }
        else if (File.Exists(path))
        {
            return new FileCommandHandler(_UserInterface, new FileInfo(path));
        }
        throw new Exception($"Неправильно указан путь {path}.");
    }
    /// <summary>
    /// Находит путь среди полученного массива.
    /// </summary>
    /// <param name="args">Массив строковых данных</param>
    /// <param name="begin">Начальный элемент массива, с которого начинается путь</param>
    /// <param name="end">Конечный элемент массива, на котором завершился поиск пути</param>
    /// <returns>Возвращает строку полного пути без кавычек</returns>
    /// <exception cref="Exception">Путь не удалось составить</exception>
    public string GetPath(string[] args, int begin, out int end)
    {
        if (args[begin][0] != '"')
        {
            end = begin;
            return args[1];
        }
        else
        {
            var path = new StringBuilder();
            path.Append(args[begin][1..]);
            for (int i = begin + 1; i < args.Length; i++)
            {
                path.Append(" ");
                if (args[i][args[i].Length - 1] == '"')
                {
                    path.Append(args[i][..(args[i].Length - 1)]);
                    end = i;
                    return path.ToString();
                }
                else
                {
                    path.Append(args[i]);
                }
            }
        }
        throw new Exception("Неправильно указан путь.");
    }
    public void Run()
    {
        _UserInterface.Write("Файловый менеджер");
        var canWork = true;
        do
        {
            var input = _UserInterface.ReadLine($"{_CurrentDirectory.FullName}>");
            var args = input.Split(' ');
            var commandName = args[0];

            try
            {
                int end = 0;
                switch (commandName.ToLower())
                {
                    case "quit":
                        canWork = false;
                        break;
                    case "help":
                        _UserInterface.Output(PrintCommand());
                        break;
                    case "cd":
                        ChangeDirectory(GetPath(args, 1, out end));
                        break;
                    case "new":
                        if (args.Length > 2)
                        {
                            CurrentObj(GetPath(args, 1, out end)).Create(GetPath(args, end + 1, out end));
                        }
                        else if (args.Length > 1)
                        {
                            CurrentObj(GetPath(args, 1, out end)).Create(_CurrentDirectory.FullName);
                        }
                        else { throw new ArgumentException(); }
                        break;
                    case "cp":
                        if (args.Length > 2)
                        {
                            CurrentObj(GetPath(args, 1, out end)).Copy(GetPath(args, end + 1, out end));
                        }
                        else if (args.Length > 1)
                        {
                            CurrentObj(GetPath(args, 1, out end)).Copy(_CurrentDirectory.FullName);
                        }
                        else { throw new ArgumentException(); }
                        break;
                    case "reloc":
                        if (args.Length > 2)
                        {
                            CurrentObj(GetPath(args, 1, out end)).Relocate(GetPath(args, end + 1, out end));
                        }
                        else if (args.Length > 1)
                        {
                            CurrentObj(GetPath(args, 1, out end)).Relocate(_CurrentDirectory.FullName);
                        }
                        else { throw new ArgumentException(); }
                        break;
                    case "rm":
                        CurrentObj(GetPath(args, 1, out end)).Delete();
                        break;
                    case "name":
                        CurrentObj(GetPath(args, 1, out end)).Rename(GetPath(args, end + 1, out end));
                        break;
                    case "info":
                        CurrentObj(GetPath(args, 1, out end)).Info();
                        break;
                    case "stat":
                        CurrentObj(GetPath(args, 1, out end)).PrintStatistics();
                        break;
                    case "ls":
                        var dir = CurrentObj(GetPath(args, 1, out end));
                        if (args.Length > end && int.TryParse(args[end + 1], out int page))
                        {
                            dir.DrawTree(page);
                        }
                        else
                        {
                            dir.DrawTree(1);
                        }
                        break;
                    default:
                        throw new Exception($"Команда {commandName} не найдена.\nПропишите help для справки или quit для завершения работы");
                }
            }
            catch (Exception e)
            {
                _UserInterface.Write(e.Message);
                throw;
            }
        } while (canWork);

        Shutdown();
    }
    public void Shutdown() 
    {
        _UserInterface.Close("Завершение работы...");
    }

    public FileManagerLogic(IUserInterface userInterface)
    {
        _UserInterface = userInterface;
    }
}
