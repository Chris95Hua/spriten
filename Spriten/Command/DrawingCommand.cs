using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spriten.Command
{
    // drawing - points, color
    // fill - area, color
    // layer modification - group, move
    public class DrawingCommand : ICommand<int>
    {
        public int Do(int input)
        {
            return -1;
        }

        public int Undo(int input)
        {
            return -1;
        }
    }
}
