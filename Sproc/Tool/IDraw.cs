using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Sproc.Tool
{
    public interface IDraw
    {
        void Initialize();
        void PaintPoint(Point point, Graphics graphics);
        void CleanUp();
    }
}
