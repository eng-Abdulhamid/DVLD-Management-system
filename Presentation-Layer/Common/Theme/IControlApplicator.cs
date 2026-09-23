using CustomizeControls;
namespace DVLD.PL.Theme
{
    public interface IControlApplicator
    {
        public Theme theme { get; init; }
        public void ApplyCurrentPrimaryButtonTheme(NButton btn);
        public void ApplyCurrentSecondaryButtonTheme(NButton btn);
        public void ApplyCurrentDisabledButtonTheme(NButton btn);
        public void ApplyCurrentDangerButtonTheme(NButton btn);
        public void ApplyCurrentCheckBoxTheme(NCheckBox chkBox);
        public void ApplyCurrentComboBoxTheme(ComboBox comboBox);
        public void ApplyCurrentDataGridTheme(NDataGrid dataGrid);
        public void ApplyCurrentFormTheme(Form frm);
        public void ApplyCurrentLabelTheme(Label lbl);
        public void ApplyCurrentMenuTheme(NMenuRenderer menu);
        public void ApplyCurrentNotificationTheme(NotificationBuilder notification);
        public void ApplyCurrentPanelTheme(Panel panel);
        public void ApplyCurrentTextBoxTheme(NTextBox txtBox);
        public void ApplyCurrentToolStripTheme(ToolStrip toolStrip);

    }
}
