using System.Diagnostics;

namespace Spriten.Utility
{
    class EventLogger : ILogger
    {
        public void Log(string message)
        {
            EventLog el = new EventLog("");

            el.Source = "Spriten";

            el.WriteEntry(message);
        }
    }
}
