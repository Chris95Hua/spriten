using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

using Sproc.Component;

namespace Sproc.Tool
{
    public interface ITool
    {
        void Initialize(Layer layer);
        void Use(Point point);
        void CleanUp();
    }
}
