namespace FileManager;
using VisualObjects;

public class ConsoleManager
{
    private ConsoleColor _ForegroundColor;
    private ConsoleColor _BackgroundColor;
    private ConsoleColor _BorderColor;
    private int _Width = 120;
    private int _Height = 30;
    public void Run()
    {
        Console.Title = "File Manager";
        Console.BackgroundColor = _BackgroundColor;
        Console.SetWindowSize(_Width, _Height);
        Console.SetBufferSize(_Width, _Height);

        int mainWindowHeight = 19;
        int infoWindowHeight = 9;
        int inputWindowHeight = 3;
        var mainWindow = new Window(_BorderColor, 0, 0, _Width, mainWindowHeight, false, true);
        var infoWindow = new Window(_BorderColor, 0, mainWindowHeight - 1, _Width, infoWindowHeight, true, true);
        var inputWindow = new Window(_BorderColor, 0, mainWindowHeight + infoWindowHeight - 2, _Width, inputWindowHeight, true, false);

        Console.SetCursorPosition(1, 1);

        mainWindow.Draw(_ForegroundColor);
        infoWindow.Draw(_ForegroundColor);
        inputWindow.Draw(_ForegroundColor);
        infoWindow.Say(_ForegroundColor, "Информация.", true);
        inputWindow.Say(_ForegroundColor, "Ввод команды: ", false);

        Console.ReadLine();
    }
    public void Shutdown() { }

    public ConsoleManager()
    {
        _ForegroundColor = ConsoleColor.White;
        _BackgroundColor = ConsoleColor.DarkGray;
        _BorderColor = ConsoleColor.Yellow;
    }
    public ConsoleManager(ConsoleColor foregroundColor, ConsoleColor backgroundColor, ConsoleColor borderColor)
    {
        _ForegroundColor = foregroundColor;
        _BackgroundColor = backgroundColor;
        _BorderColor = borderColor;
    }
}