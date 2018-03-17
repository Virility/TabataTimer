using System;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace KegelTimerApplication.UI.Extensions
{
    public static class RichTextBoxExtensions
    {
        private const int WmVscroll = 277;
        private const int SbPagebottom = 7;

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        private static extern int SendMessage(IntPtr hWnd, int wMsg, IntPtr wParam, IntPtr lParam);

        public static void ScrollToBottom(this RichTextBox richTextBox)
        {
            // Scroll to bottom of the richTextBox by using it's handle and native method.
            SendMessage(richTextBox.Handle, WmVscroll, (IntPtr)SbPagebottom, IntPtr.Zero);
        }

        public static void AppendText(this RichTextBox richTextBox, string content, Color color)
        {
            // Set selection start to the end of the richTextBox
            richTextBox.SelectionStart = richTextBox.TextLength;

            // Set selected characters to none
            richTextBox.SelectionLength = 0;

            // Set color to selected text
            richTextBox.SelectionColor = color;

            // Add content to richTextBox
            richTextBox.AppendText(content);

            // Set color to original
            richTextBox.SelectionColor = richTextBox.ForeColor;

            // Set font to original
            // (needed because sometimes the content
            // breaks the font for the next appended text)
            richTextBox.SelectionFont = richTextBox.Font;
        }
    }
}