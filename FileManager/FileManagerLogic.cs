using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileManager;

public class FileManagerLogic
{
    private readonly IUserInterface _UserInterface;
    private string _CurrentDir;

    public void Run()
    {
        _UserInterface.Write("Файловый менеджер");
        _UserInterface.ReadLine($"{_CurrentDir}>");

        Shutdown();
    }
    public void Shutdown() 
    {
        _UserInterface.Close("Завершение работы...");
    }

    public FileManagerLogic(IUserInterface userInterface)
    {
        _CurrentDir = Directory.GetCurrentDirectory(); 
        _UserInterface = userInterface;
    }
}
