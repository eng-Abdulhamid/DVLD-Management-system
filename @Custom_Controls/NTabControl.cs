using System;
using System.Windows.Forms;

namespace Modern_Controls.CustomControls
{
    public class NTabControl : TabControl
    {
        public NTabControl()
        {
            SetStyle(ControlStyles.AllPaintingInWmPaint |
                     ControlStyles.OptimizedDoubleBuffer |
                     ControlStyles.ResizeRedraw |
                     ControlStyles.UserPaint, false);
        }

        protected override void WndProc(ref Message m)
        {
            if (m.Msg == 0x1328 && !DesignMode)
            {
                m.Result = (IntPtr)1;
                return;
            }

            base.WndProc(ref m);
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == (Keys.Control | Keys.Tab) ||
                keyData == (Keys.Control | Keys.Shift | Keys.Tab))
            {
                return true;
            }

            return base.ProcessCmdKey(ref msg, keyData);
        }
    }
}