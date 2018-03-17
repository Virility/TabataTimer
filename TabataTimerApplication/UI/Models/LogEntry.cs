using System.Drawing;

namespace KegelTimerApplication.UI.Models
{
    public class LogEntry
    {
        public string Text { get; set; }

        public bool UseDate { get; set; }

        public bool UseNewLine { get; set; }

        public Color Color { get; set; }

        public LogEntry(string text, bool useDate = true, bool useNewLine = true, Color? color = null)
        {
            Text = text;
            UseDate = useDate;
            UseNewLine = useNewLine;
            Color = color ?? Color.DarkGray;
        }
    }
}