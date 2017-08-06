using System.Drawing;

using Spriten.CustomControl;

namespace Spriten.Tool
{
    public abstract class DrawTool
    {        
        public abstract void Initialize(Canvas canvas);
        public abstract Rectangle Use(Rectangle rect);
    }
}
