using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Sproc
{
    public static class User
    {
        // constants
        public const Char DRAW = 'c';
        public const Char ERASE = 'e';
        public const Char FILL = 'f';
        public const Char LINE = 'l';

        // global vars
        public static Color _PrimaryColor = Color.Black;
        public static Color _SecondaryColor = Color.White;
        public static Char _UserMode = DRAW;        
    }
}
