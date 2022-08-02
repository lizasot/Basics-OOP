namespace FileManager;

using System.Configuration;
using System.Text;

public class ConsoleInterface : IUserInterface
{
    private Window _MainWindow;
    private Window _InfoWindow;
    private Window _InputWindow;
    private ConsoleColor _ForegroundColor;
    private ConsoleColor _BackgroundColor;
    private ConsoleColor _BorderColor;
    private int _Width = 120;
    private int _Height = 30;

    public void Start()
    {
        ConfigurationManager.AppSettings.Set("PageLines", "17");
    }
    public void Write(string text)
    {
        _InfoWindow.Say(_ForegroundColor, text, true);
    }
    public void Output(string text)
    {
        _MainWindow.Say(_ForegroundColor, text, true);
    }
    public string ReadLine(string prompt)
    {
        _InputWindow.Say(_ForegroundColor, prompt, false);
        return ProcessEnterCommand(_Width - 2, prompt);
    }

    private string ProcessEnterCommand(int width, string prompt)
    {
        (int left, int top) = Console.GetCursorPosition();
        StringBuilder command = new StringBuilder();
        ConsoleKeyInfo keyInfo;
        char key;

        do
        {
            (int currentLeft, int currentTop) = Console.GetCursorPosition();
            keyInfo = Console.ReadKey(true);
            key = keyInfo.KeyChar;

            if (keyInfo.Key != ConsoleKey.Enter && key != '\0' && currentLeft < width)
            {
                command.Append(key);
                Console.Write(key);
            }

            if (keyInfo.Key == ConsoleKey.Backspace)
            {
                if (command.Length > 0)
                {
                    command.Remove(command.Length - 1, 1);
                }
                if (currentLeft > left)
                {
                    Console.SetCursorPosition(currentLeft - 1, top);
                    Console.Write(" ");
                    Console.SetCursorPosition(currentLeft - 1, top);
                }
                else
                {
                    command.Clear();
                    Console.SetCursorPosition(left, top);
                }
            }

            if (keyInfo.Key == ConsoleKey.UpArrow)
            {
                //вывести прошлую команду
                _InputWindow.Say(_ForegroundColor, $"{prompt}{}", false);
            }
            else if (keyInfo.Key == ConsoleKey.DownArrow)
            {
                //вывести последующую команду
            }
            else
            {
                //currentCommand = 0;
            }
        }
        while (keyInfo.Key != ConsoleKey.Enter);
        if (command.Length > 0)
        {
            //добавить команду в историю команд
        }

        return command.ToString();
    }

    public void Close(string text)
    {
        Console.Clear();
        Console.WriteLine(text);
        Console.ReadKey(true);
    }

    public ConsoleInterface()
    {
        _ForegroundColor = ConsoleColor.White;
        _BackgroundColor = ConsoleColor.DarkGray;
        _BorderColor = ConsoleColor.Yellow;

        Console.Title = "File Manager";
        Console.BackgroundColor = _BackgroundColor;
        Console.SetWindowSize(_Width, _Height);
        Console.SetBufferSize(_Width, _Height);

        int mainWindowHeight = 19;
        int infoWindowHeight = 9;
        int inputWindowHeight = 3;
        _MainWindow = new Window(_BorderColor, 0, 0, _Width, mainWindowHeight, false, true);
        _InfoWindow = new Window(_BorderColor, 0, mainWindowHeight - 1, _Width, infoWindowHeight, true, true);
        _InputWindow = new Window(_BorderColor, 0, mainWindowHeight + infoWindowHeight - 2, _Width, inputWindowHeight, true, false);

        Console.SetCursorPosition(1, 1);

        _MainWindow.Draw(_ForegroundColor);
        _InfoWindow.Draw(_ForegroundColor);
        _InputWindow.Say(_ForegroundColor, "Ввод команды: ", false);
    }
    public ConsoleInterface(ConsoleColor foregroundColor, ConsoleColor backgroundColor, ConsoleColor borderColor)
    {
        _ForegroundColor = foregroundColor;
        _BackgroundColor = backgroundColor;
        _BorderColor = borderColor;

        Console.Title = "File Manager";
        Console.BackgroundColor = _BackgroundColor;
        Console.SetWindowSize(_Width, _Height);
        Console.SetBufferSize(_Width, _Height);

        int mainWindowHeight = 19;
        int infoWindowHeight = 9;
        int inputWindowHeight = 3;
        _MainWindow = new Window(_BorderColor, 0, 0, _Width, mainWindowHeight, false, true);
        _InfoWindow = new Window(_BorderColor, 0, mainWindowHeight - 1, _Width, infoWindowHeight, true, true);
        _InputWindow = new Window(_BorderColor, 0, mainWindowHeight + infoWindowHeight - 2, _Width, inputWindowHeight, true, false);

        Console.SetCursorPosition(1, 1);

        _MainWindow.Draw(_ForegroundColor);
        _InfoWindow.Draw(_ForegroundColor);
        _InputWindow.Say(_ForegroundColor, "Ввод команды: ", false);
    }
}