using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileManager.CommandHandlers;

public class HistoryCommands
{
    private StringBuilder CommandList;
    private int IndexCurrentCommand;

    public string GetCurrentCommand()
    {
        string[] oldCommands = CommandList.ToString().Split('\n');
        return oldCommands[IndexCurrentCommand];
    }

    public string GetNext()
    {
        string[] oldCommands = CommandList.ToString().Split('\n');
        if (IndexCurrentCommand < oldCommands.Length - 1)
        {
            IndexCurrentCommand++;
        }
        return oldCommands[IndexCurrentCommand];
    }
    public string GetPrev()
    {
        string[] oldCommands = CommandList.ToString().Split('\n');
        if (IndexCurrentCommand > 0)
        {
            IndexCurrentCommand--;
        }
        return oldCommands[IndexCurrentCommand];
    }

    public void Add(string command)
    {
        CommandList.AppendLine(command);
    }

    public void Reset()
    {
        IndexCurrentCommand = 0;
    }

    public HistoryCommands()
    {
        CommandList = new StringBuilder();
        IndexCurrentCommand = 0;
    }
}