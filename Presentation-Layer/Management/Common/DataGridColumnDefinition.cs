using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace DVLD.PL.Management
{
    public class DataGridColumnDefinition
    {
        public string Key { get; set; } = string.Empty;
        public string HeaderText { get; set; } = string.Empty;
        public string DataPropertyName { get; set; } = string.Empty;
        public int Width { get; set; } = 100;

        [Browsable(false)]
        public ToolStripMenuItem? ToolStripItem { get; internal set; }
    }
}
