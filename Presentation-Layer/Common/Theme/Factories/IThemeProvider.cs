using DVLD.PL.ControlsTheme;
namespace DVLD.PL.Theme
{
    public interface IThemeProvider
    {
        public Theme BuildTheme();
        public ThemeColors GetThemeColors();
        public CommonTheme GetCommonTheme();
        public FormTheme GetFormTheme();
        public ButtonThemes GetButtonThemes();
        public TextBoxTheme GetTextBoxTheme();
        public CheckBoxTheme GetCheckBoxTheme();
        public ComboBoxTheme GetComboBoxTheme();
        public DataGridTheme GetDataGridTheme();
        public LabelTheme GetLabelTheme();
        public PanelTheme GetPanelTheme();
        public ToolStripTheme GetToolStripTheme();
        public MenuTheme GetMenuTheme();
        public NotificationTheme GetNotificationTheme();
    }
}
