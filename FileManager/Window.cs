using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileManager;

public class Window
{
    private ConsoleColor _ColorBorder;
    private int _X;
    private int _Y;
    private int _Width;
    private int _Height;
    private bool _TopIntermediate;
    private bool _BottomIntermediate;

    /// <summary>
    /// Отрисовывает созданное окно в консоли.
    /// </summary>
    /// <param name="foregroundColor">Текущий цвет шрифта</param>
    public void Draw(ConsoleColor foregroundColor)
    {
        Console.ForegroundColor = _ColorBorder;

        //запоминаем, куда нужно будет вернуть курсор
        (int leftCurrent, int topCurrent) = Console.GetCursorPosition();

        //Верхняя граница
        Console.SetCursorPosition(_X, _Y);
        if (_TopIntermediate)
        {
            Console.Write("╠");
        }
        else
        {
            Console.Write("╔");
        }
        for (int i = 0; i < _Width - 2; i++)
            Console.Write("═");
        if (_TopIntermediate)
        {
            Console.Write("╣");
        }
        else
        {
            Console.Write("╗");
        }

        //Левая и правая граница
        Console.SetCursorPosition(_X, _Y + 1);
        for (int i = 0; i < _Height - 1; i++)
        {
            Console.Write("║");
            for (int j = 0; j < _Width - 2; j++)
            {
                Console.Write(" ");
            }
            Console.Write("║");
            Console.SetCursorPosition(_X, _Y + 1 + i);
        }

        //Нижняя граница
        if (_BottomIntermediate)
        {
            Console.Write("╠");
        }
        else
        {
            Console.Write("╚");
        }
        for (int i = 0; i < _Width - 2; i++)
            Console.Write("═");
        if (_BottomIntermediate)
        {
            Console.Write("╣");
        }
        else
        {
            Console.Write("╝");
        }

        Console.SetCursorPosition(leftCurrent, topCurrent);

        //возвращаем прежний цвет шрифта
        Console.ForegroundColor = foregroundColor;
    }

    public void Say(ConsoleColor foregroundColor, string message, bool returnCursor)
    {
        Draw(foregroundColor);

        //запоминаем, куда нужно будет вернуть курсор
        (int leftCurrent, int topCurrent) = Console.GetCursorPosition();
        Console.SetCursorPosition(_X + 1, _Y + 1);
        Console.Write(message);
        if (returnCursor)
        {
            Console.SetCursorPosition(leftCurrent, topCurrent);
        }
    }

    /// <summary>
    /// Создание окна для дальнейшей отрисовки
    /// </summary>
    /// <param name="colorBorder">Цвет границ</param>
    /// <param name="x"></param>
    /// <param name="y"></param>
    /// <param name="width"></param>
    /// <param name="height"></param>
    /// <param name="topIntermediate"></param>
    /// <param name="bottomIntermediate"></param>
    public Window(ConsoleColor colorBorder, int x, int y, int width, int height, bool topIntermediate, bool bottomIntermediate)
    {
        _ColorBorder = colorBorder;
        _X = x;
        _Y = y;
        _Width = width;
        _Height = height;
        _TopIntermediate = topIntermediate;
        _BottomIntermediate = bottomIntermediate;
    }
}
