using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using TabataTimerApplication.UI.Extensions;
using TabataTimerApplication.UI.Models;
using Timer = System.Timers.Timer;

namespace TabataTimerApplication.UI.Helpers
{
    public class RichTextBoxLogProvider
    {
        private readonly Queue<LogItem> _richTextBoxLogQueue;
        private readonly Timer _logTimer;

        public RichTextBox RichTextBox { get; set; }

        public RichTextBoxLogProvider(RichTextBox richTextBox)
        {
            RichTextBox = richTextBox;
            _richTextBoxLogQueue = new Queue<LogItem>();
            _logTimer = new Timer(100);
            _logTimer.Elapsed += delegate
            {
                InternalLog();
            };
            _logTimer.Start();
        }

        public void Log(LogItem item)
        {
            _richTextBoxLogQueue.Enqueue(item);
        }

        private void InternalLog()
        {
            if (_richTextBoxLogQueue.Count == 0)
                return;

            var logAction = new Action(() =>
            {
                for (var i = 0; i < _richTextBoxLogQueue.Count; i++)
                {
                    var item = _richTextBoxLogQueue.Dequeue();
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
            });

            RichTextBox.Invoke(logAction);
        }
    }
}