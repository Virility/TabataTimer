using System.Drawing;

namespace TabataTimerApplication.UI.Models
{
    public class LogItem
    {
        public LogEntry[] Entries { get; set; }

        public LogItem(LogEntry[] entries)
        {
            Entries = entries;
        }

        public static LogItem Create(LogEntry[] entries)
        {
            return new LogItem(entries);
        }

        public static LogItem Create(string text, bool useDate = true, bool useNewLine = true, Color? color = null)
        {
            return Create(new[] { new LogEntry(text, useDate, useNewLine, color) });
        }
    }
}