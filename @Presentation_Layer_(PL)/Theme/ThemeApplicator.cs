using CustomizeControls;
namespace DVLD.PL.Theme
{
    public static class ThemeApplicator
    {
        public static void Apply(Control root)
        {
            if (root == null)
                return;

            ApplyToControl(root);

            foreach (Control control in root.Controls)
            {
                Apply(control);
            }
        }

        private static void ApplyToControl(Control control)
        {
            switch (control)
            {
                case Form frm:
                    frm.ApplyStandardFormTheme();
                    break;

                case Panel panel:
                    panel.ApplyPanelStyle();
                    break;

                case NTextBox textBox:
                    textBox.ApplyTextBoxStyle();
                    break;

                case ComboBox comboBox:
                    comboBox.ApplyComboBoxStyle();
                    break;
                case Label label:
                    label.ApplyLabelStyle();
                    break;
                case NCheckBox checkBox:
                    checkBox.ApplyCheckBoxStyle();
                    break;

                case DataGridView dataGrid:
                    dataGrid.ApplyDataGridStyle();
                    break;
                case NButton btn:
                    btn.ApplyButtonTheme();
                    break;
            }
        }
        private static void ApplyButtonTheme(this NButton btn)
        {
            switch (btn.ButtonType)
            {
                case enButtonType.Primary:
                    btn.ApplyPrimaryStyle();
                    break;

                case enButtonType.Secondary:
                    btn.ApplySecondaryStyle();
                    break;

                case enButtonType.Danger:
                    btn.ApplyDangerStyle();
                    break;

                case enButtonType.Disabled:
                    btn.ApplyDisabledStyle();
                    break;
            }
        }
    }
}