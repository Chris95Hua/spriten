using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Sproc
{
    /// <summary>
    /// User session
    /// </summary>
    public static class User
    {
        public enum Mode
        {
            Draw, Erase, Fill, Line, Shape, Select, ColorPicker
        }

        // global vars
        public static Color _PrimaryColor = Color.Black;
        public static Color _SecondaryColor = Color.White;
        public static int _UserMode = (int) Mode.Draw;        
    }
}
