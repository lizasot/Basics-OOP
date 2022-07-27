using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Figures;

public interface IMove2D
{
    bool Move(int x);
    bool Move(int x, int y);
}
