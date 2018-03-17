using System;
using System.Drawing;
using System.Windows.Forms;
using KegelTimerApplication.UI.Extensions;
using KegelTimerApplication.UI.Models;

namespace KegelTimerApplication.UI.Helpers
{
    public class RichTextBoxLogProvider
    {
        public RichTextBox RichTextBox { get; set; }

        public RichTextBoxLogProvider(RichTextBox richTextBox)
        {
            RichTextBox = richTextBox;
        }

        public void Log(LogItem item)
        {
            foreach (var entry in item.Entries)
            {
                if (entry.UseDate)
                    RichTextBox.AppendText($"[{DateTime.Now:h:mm:ss tt}] ", SystemColors.Highlight);

                RichTextBox.AppendText(entry.Text, entry.Color);

                if (entry.UseNewLine)
                    RichTextBox.AppendText("\r\n");

                RichTextBox.ScrollToBottom();
            }
        }
    }
}