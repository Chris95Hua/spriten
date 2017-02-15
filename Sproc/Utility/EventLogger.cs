using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace Sproc.Utility
{
    class EventLogger : ILogger
    {
        public void Log(string message)
        {
            EventLog el = new EventLog("");

            el.Source = "Sproc";

            el.WriteEntry(message);
        }
    }
}
