using System.Windows.Forms;
using CustomizeControls;

namespace DVLD.PL.Theme;

public static class ThemeApplicator
{
    public static void ApplyThemeToAll(this Control? root)
    {
        if (root is null) return;

        ApplyToControl(root);

        foreach (Control child in root.Controls)
        {
            ApplyThemeToAll(child);
        }
    }

    private static void ApplyToControl(Control control)
    {
        switch (control)
        {
            case Form frm:
                ThemeManager.Current.ApplyCurrentFormTheme(frm);
                break;

            case NButton btn:
                btn.ApplyTheme();
                break;

            case NTextBox textBox:
                ThemeManager.Current.ApplyCurrentTextBoxTheme(textBox);
                break;

            case NCheckBox checkBox:
                ThemeManager.Current.ApplyCurrentCheckBoxTheme(checkBox);
                break;

            case ComboBox comboBox:
                ThemeManager.Current.ApplyCurrentComboBoxTheme(comboBox);
                break;

            case Label label:
                ThemeManager.Current.ApplyCurrentLabelTheme(label);
                break;

            case NDataGrid dataGrid:
                ThemeManager.Current.ApplyCurrentDataGridTheme(dataGrid);
                break;

            case Panel panel:
                ThemeManager.Current.ApplyCurrentPanelTheme(panel);
                break;

            case ToolStrip toolStrip:
                ThemeManager.Current.ApplyCurrentToolStripTheme(toolStrip);
                if (toolStrip is MenuStrip menuStrip && menuStrip.Renderer is NMenuRenderer menuRenderer)
                {
                    ThemeManager.Current.ApplyCurrentMenuTheme(menuRenderer);
                }
                break;
        }

        if (control.ContextMenuStrip?.Renderer is NMenuRenderer contextRenderer)
        {
            ThemeManager.Current.ApplyCurrentMenuTheme(contextRenderer);
        }
    }

    public static void ApplyTheme(this NButton btn)
    {
        switch (btn.ButtonType)
        {
            case enButtonType.Primary:
                ThemeManager.Current.ApplyCurrentPrimaryButtonTheme(btn);
                break;

            case enButtonType.Secondary:
                ThemeManager.Current.ApplyCurrentSecondaryButtonTheme(btn);
                break;

            case enButtonType.Danger:
                ThemeManager.Current.ApplyCurrentDangerButtonTheme(btn);
                break;

            case enButtonType.Disabled:
                ThemeManager.Current.ApplyCurrentDisabledButtonTheme(btn);
                break;
        }
    }
}