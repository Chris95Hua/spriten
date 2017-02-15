using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sproc.Utility
{
    class Logger
    {
        private static ILogger mLogger;

        /// <summary>
        /// Log message using EventLogger or to a file
        /// </summary>
        /// <param name="message">Message to be logged</param>
        public static void Log(string message)
        {
            // Debug log
            System.Diagnostics.Debug.WriteLine(message);

            // EventLog
            if (0 == 1)
            {
                mLogger = new EventLogger();
                mLogger.Log(message);
            }

            // Log to file
            if (0 == 1)
            {
                mLogger = new FileLogger();
                mLogger.Log(message);
            }
        }
    }
}
