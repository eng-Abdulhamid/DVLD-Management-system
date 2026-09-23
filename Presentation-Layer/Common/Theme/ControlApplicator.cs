using CustomizeControls;
using static DVLD.PL.Theme.ControlThemeApplier;
namespace DVLD.PL.Theme
{
    public class ControlApplicator : IControlApplicator
    {
        public Theme theme { get; init; }
        public ControlApplicator(Theme theme)
        {
            this.theme = theme;
        }
        public void ApplyCurrentCheckBoxTheme(NCheckBox chkBox)
        {
            ApplyCheckBoxProperties(chkBox, theme.CheckBox, theme.Common);
        }
        public void ApplyCurrentComboBoxTheme(ComboBox comboBox)
        {
            ApplyComboBoxProperties(comboBox, theme.ComboBox, theme.Common);
        }

        public void ApplyCurrentDangerButtonTheme(NButton btn)
        {
            ApplyButtonProperties(btn, theme.Buttons.Danger,theme.Common);
        }

        public void ApplyCurrentDataGridTheme(NDataGrid dataGrid)
        {
            ApplyDataGridProperties(dataGrid, theme.DataGrid, theme.Common);
        }

        public void ApplyCurrentDisabledButtonTheme(NButton btn)
        {
            ApplyButtonProperties(btn, theme.Buttons.Disabled, theme.Common);
        }

        public void ApplyCurrentFormTheme(Form frm)
        {
            ApplyFormProperties(frm, theme.Form, theme.Common);
        }

        public void ApplyCurrentLabelTheme(Label lbl)
        {
            ApplyLabelProperties(lbl, theme.Label, theme.Common);
        }

        public void ApplyCurrentMenuTheme(NMenuRenderer menu)
        {
            ApplyMenuProperties(menu, theme.Menu);
        }

        public void ApplyCurrentNotificationTheme(NotificationBuilder notification)
        {
            ApplyNotificationProperties(notification, theme.Notification);
        }

        public void ApplyCurrentPanelTheme(Panel panel)
        {
            ApplyPanelProperties(panel, theme.Panel);
        }

        public void ApplyCurrentPrimaryButtonTheme(NButton btn)
        {
            ApplyButtonProperties(btn, theme.Buttons.Primary, theme.Common);
        }

        public void ApplyCurrentSecondaryButtonTheme(NButton btn)
        {
            ApplyButtonProperties(btn, theme.Buttons.Secondary, theme.Common);
        }

        public void ApplyCurrentTextBoxTheme(NTextBox txtBox)
        {
            ApplyTextBoxProperties(txtBox, theme.TextBox, theme.Common);
        }

        public void ApplyCurrentToolStripTheme(ToolStrip toolStrip)
        {
            ApplyToolStripProperties(toolStrip, theme.ToolStrip, theme.Common);
        }
    }
}
