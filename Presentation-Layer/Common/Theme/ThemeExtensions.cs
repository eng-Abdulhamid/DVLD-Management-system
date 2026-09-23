using CustomizeControls;

namespace DVLD.PL.Theme;

public static class ThemeExtensions
{
    public static void ApplyPrimary(this NButton btn)
    {
        ThemeManager.Current.ApplyCurrentPrimaryButtonTheme(btn);
    }

    public static void ApplySecondary(this NButton btn)
    {
        ThemeManager.Current.ApplyCurrentSecondaryButtonTheme(btn);
    }

    public static void ApplyDanger(this NButton btn)
    {
        ThemeManager.Current.ApplyCurrentDangerButtonTheme(btn);
    }

    public static void ApplyDisabled(this NButton btn)
    {
        ThemeManager.Current.ApplyCurrentDisabledButtonTheme(btn);
    }

    public static void ApplyTheme(this NTextBox txt)
    {
        ThemeManager.Current.ApplyCurrentTextBoxTheme(txt);
    }

    public static void ApplyTheme(this NCheckBox chk)
    {
        ThemeManager.Current.ApplyCurrentCheckBoxTheme(chk);
    }

    public static void ApplyTheme(this ComboBox cmb)
    {
        ThemeManager.Current.ApplyCurrentComboBoxTheme(cmb);
    }

    public static void ApplyTheme(this NDataGrid dgv)
    {
        ThemeManager.Current.ApplyCurrentDataGridTheme(dgv);
    }

    public static void ApplyTheme(this Form frm)
    {
        ThemeManager.Current.ApplyCurrentFormTheme(frm);
    }

    public static void ApplyTheme(this Label lbl)
    {
        ThemeManager.Current.ApplyCurrentLabelTheme(lbl);
    }

    public static void ApplyTheme(this Panel pnl)
    {
        ThemeManager.Current.ApplyCurrentPanelTheme(pnl);
    }

    public static void ApplyTheme(this ToolStrip ts)
    {
        ThemeManager.Current.ApplyCurrentToolStripTheme(ts);
    }

    public static void ApplyTheme(this NMenuRenderer menu)
    {
        ThemeManager.Current.ApplyCurrentMenuTheme(menu);
    }

    public static void ApplyTheme(this NotificationBuilder notification)
    {
        ThemeManager.Current.ApplyCurrentNotificationTheme(notification);
    }
}