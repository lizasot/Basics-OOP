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
        commandList.AppendLine("cd <Путь_директории>: Сменить текущую директорию");
        commandList.AppendLine("new dir <Путь_директории>* <Имя_новой_папки>: Создать папку в указанную директорию");
        commandList.AppendLine("new file <Путь_директории>* <Имя_нового_файла>: Создать файл в указанную директорию");
        commandList.AppendLine("cp <Путь_файла/папки> <Путь_конечного_файла/папки>*: Копирует папку/файл в указанную директорию");
        commandList.AppendLine("reloc <Путь_файла/папки> <Путь_директории>*: Перемещает папку/файл в указанную директорию");
        commandList.AppendLine("rm <Путь_файла/папки>: Удаляет папку/файл");
        commandList.AppendLine("name <Новое_имя> <Путь_файла/папки>*: Устанавливает имя у указонного файла/папки");
        commandList.AppendLine("info <Путь_файла/папки>*: Выводит информацию о файле/папке");
        commandList.AppendLine("stat <Путь_файла>: Выводит сведения о содержимом файла");
        commandList.AppendLine("att <Путь_файла> <Archive | Hidden | ReadOnly>: Изменить атрибуты файла");
        commandList.AppendLine("ls <Путь_папки>* <Номер_страницы>*: Постраничный вывод содержимого папки");
        commandList.AppendLine("search <Путь_папки>* <Название> <Номер_страницы>*: Поиск файлов и папок по маске (с использованием символов \"?\" и \"*\")");
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
        else if (Directory.Exists($"{_CurrentDirectory.FullName}{path}"))
        {
            return new DirectoryCommandHandler(_UserInterface, new DirectoryInfo($"{_CurrentDirectory.FullName}{path}"));
        }
        throw new Exception($"Неправильно указан путь {path}.");
    }
    /// <summary>
    /// Собирает единый по смыслу аргумент в строку из полученного массива слов, разделённых пробелами.
    /// </summary>
    /// <param name="args">Массив строковых данных</param>
    /// <param name="begin">Начальный элемент массива, с которого начинается аргумент</param>
    /// <param name="end">Конечный элемент массива, на котором завершился поиск аргумента</param>
    /// <returns>Возвращает строку полного аргумента без кавычек</returns>
    /// <exception cref="Exception">Некорректный ввод данных.</exception>
    public string GetArg(string[] args, int begin, out int end)
    {
        if (args[begin][0] != '"')
        {
            end = begin;
            return args[begin];
        }
        else if (args[begin][args[begin].Length - 1] == '"')
        {
            end = begin;
            return args[begin][1..(args[begin].Length - 1)];
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
        throw new Exception("Некорректный ввод данных.");
    }
    public void Run()
    {
        _UserInterface.Write("Файловый менеджер");
        var canWork = true;
        _UserInterface.Output(PrintCommand());
        do
        {
            var input = _UserInterface.ReadLine($"{_CurrentDirectory.FullName}>");
            var args = input.Split(' ');
            var commandName = args[0];

            try
            {
                int end = 0;
                string arg;
                ICommands currObj;
                switch (commandName.ToLower())
                {
                    case "quit":
                        canWork = false;
                        break;
                    case "help":
                        _UserInterface.Output(PrintCommand());
                        break;
                    case "cd":
                        ChangeDirectory(GetArg(args, 1, out end));
                        break;
                    case "cd..":
                        ChangeDirectory(Path.GetDirectoryName(_CurrentDirectory.FullName));
                        break;
                    case "new":
                        if (args.Length > 2)
                        {
                            if (args[1] == "file")
                            {
                                arg = GetArg(args, 2, out end);
                                try
                                {
                                    currObj = CurrentObj(arg);
                                    arg = GetArg(args, end + 1, out end);
                                }
                                catch (Exception)
                                {
                                    currObj = CurrentObj(_CurrentDirectory.FullName);
                                }
                                currObj.CreateFile(arg);
                            }
                            else if (args[1] == "dir")
                            {
                                arg = GetArg(args, 2, out end);
                                try
                                {
                                    currObj = CurrentObj(arg);
                                    arg = GetArg(args, end + 1, out end);
                                }
                                catch (Exception)
                                {
                                    currObj = CurrentObj(_CurrentDirectory.FullName);
                                }
                                currObj.CreateDir(arg);
                            }
                            else { throw new ArgumentException(); }
                        }
                        else { throw new ArgumentException(); }
                        break;
                    case "cp":
                        arg = GetArg(args, 1, out end);
                        if (end == args.Length - 1)
                        {
                            CurrentObj(arg).Copy(_CurrentDirectory.FullName);
                        }
                        else
                        {
                            CurrentObj(arg).Copy(GetArg(args, end + 1, out end));
                        }
                        break;
                    case "reloc":
                        if (args.Length > 2)
                        {
                            CurrentObj(GetArg(args, 1, out end)).Relocate(GetArg(args, end + 1, out end));
                        }
                        else if (args.Length > 1)
                        {
                            CurrentObj(GetArg(args, 1, out end)).Relocate(_CurrentDirectory.FullName);
                        }
                        else { throw new ArgumentException(); }
                        break;
                    case "rm":
                        CurrentObj(GetArg(args, 1, out end)).Delete();
                        break;
                    case "name":
                        if (args.Length > 2)
                        {
                            var name = GetArg(args, 1, out end);
                            CurrentObj(GetArg(args, end + 1, out end)).Rename(name);
                        }
                        else { throw new ArgumentException(); }
                        break;
                    case "info":
                        if (args.Length == 1)
                        {
                            CurrentObj(_CurrentDirectory.FullName).Info();
                        }
                        else
                        {
                            CurrentObj(GetArg(args, 1, out end)).Info();
                        }
                        break;
                    case "stat":
                        CurrentObj(GetArg(args, 1, out end)).PrintStatistics();
                        break;
                    case "att":
                        CurrentObj(GetArg(args, 1, out end)).SetAttributes(GetArg(args, end +1, out end));
                        break;
                    case "ls":
                        if (args.Length > 1)
                        {
                            int page;
                            if (int.TryParse(args[1], out page))
                            {
                                CurrentObj(_CurrentDirectory.FullName).DrawTree(page);
                            }
                            else
                            {
                                currObj = CurrentObj(GetArg(args, 1, out end));
                                if (args.Length > end + 1)
                                {
                                    arg = GetArg(args, end + 1, out end);
                                    if (int.TryParse(arg, out page))
                                    {
                                        currObj.DrawTree(page);
                                    }
                                    else
                                    {
                                        throw new ArgumentException();
                                    }
                                }
                                else
                                {
                                    currObj.DrawTree(1);
                                }
                            }
                        }
                        else
                        {
                            CurrentObj(_CurrentDirectory.FullName).DrawTree(1);
                        }
                        break;
                    case "search":
                        arg = GetArg(args, 1, out end);
                        try
                        {
                            currObj = CurrentObj(arg);
                        }
                        catch (Exception)
                        {
                            currObj = CurrentObj(_CurrentDirectory.FullName);
                            end = 0;
                        }
                        arg = GetArg(args, end + 1, out end);
                        if (args.Length - 1 == end)
                        {
                            if (int.TryParse(arg, out int page))
                            {
                                currObj.Search(arg, page);
                            }
                            else
                                currObj.Search(arg, 1);
                        }
                        else
                        {
                            if (int.TryParse(GetArg(args, end + 1, out end), out int page))
                            {
                                currObj.Search(arg, page);
                            }
                            else
                                throw new ArgumentException(arg);
                        }
                        break;
                    default:
                        throw new Exception($"Команда {commandName} не найдена.\nПропишите help для справки или quit для завершения работы");
                }
            }
            catch (Exception e)
            {
                _UserInterface.Write(e.Message);
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
