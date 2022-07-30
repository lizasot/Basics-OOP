using FileManager.Commands.Base;
using FileManager.Commands;

namespace FileManager;

public class FileManagerLogic
{
    private readonly IUserInterface _UserInterface;
    private DirectoryInfo _CurrentDirectory = new("C:\\");
    public IReadOnlyDictionary<string, FileManagerCommand> Commands { get; }
    public DirectoryInfo CurrentDirectory 
    {
        get => _CurrentDirectory;
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

            if (commandName == "quit")
            {
                canWork = false;
                continue;
            }

            if (!Commands.TryGetValue(commandName, out var command))
            {
                _UserInterface.Write($"Неизвестная команда {commandName}.\nДля справки введите help, для выхода quit");
                continue;
            }

            try
            {
                command.Emit(args);
            }
            catch (Exception e)
            {
                _UserInterface.Write($"При выполнении команды {commandName} произошла ошибка:\n{e.Message}");
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

        //Список всех команд:
        var size = new CalcSizeCommand(_UserInterface, this);
        Commands = new Dictionary<string, FileManagerCommand>
        {
            { "size", size }
        };
    }
}
