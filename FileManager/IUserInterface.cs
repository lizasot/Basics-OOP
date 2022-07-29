using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileManager;

public interface IUserInterface
{
    void Write(string text);
    void Output(string text);
    string? ReadLine(string? prompt);
    void Close(string text);
}
