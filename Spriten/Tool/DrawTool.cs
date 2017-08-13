using System.Drawing;

using Spriten.CustomControl;

namespace Spriten.Tool
{
    public interface DrawTool
    {
        void Initialize(Canvas canvas);
        Rectangle Use(Rectangle rect);
    }
}
