using DVLD.PL.ControlsTheme;

namespace DVLD.PL.Theme
{
    public class Theme
    {
        public ThemeColors Colors { get; init; } = null!;

        public CommonTheme Common { get; init; } = null!;

        public FormTheme Form { get; init; } = null!;

        public ButtonThemes Buttons { get; init; } = null!;

        public TextBoxTheme TextBox { get; init; } = null!;

        public CheckBoxTheme CheckBox { get; init; } = null!;

        public ComboBoxTheme ComboBox { get; init; } = null!;

        public DataGridTheme DataGrid { get; init; } = null!;

        public LabelTheme Label { get; init; } = null!;

        public PanelTheme Panel { get; init; } = null!;

        public ToolStripTheme ToolStrip { get; init; } = null!;

        public MenuTheme Menu { get; init; } = null!;

        public NotificationTheme Notification { get; init; } = null!;
    }
}