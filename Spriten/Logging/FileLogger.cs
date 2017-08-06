using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Spriten.Utility
{
    class FileLogger : ILogger
    {
        public string mFilePath = @"C:\IDGLog.txt";
        public void Log(string message)
        {
            StreamWriter sw = new StreamWriter(mFilePath);

            sw.WriteLine(message);

            sw.Dispose();
        }
    }
}
