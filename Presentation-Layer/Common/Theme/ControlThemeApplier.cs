using CustomizeControls;
using DVLD.PL.ControlsTheme;

namespace DVLD.PL.Theme;

public static class ControlThemeApplier
{
    public static void ApplyButtonProperties(NButton btn, ButtonTheme bt, CommonTheme? common = null)
    {
        if (btn is null || bt is null) return;

        // Background State Colors
        btn.BackColor = bt.BackgroundStartColor;
        btn.BackgroundStartColor = bt.BackgroundStartColor;
        btn.BackgroundEndColor = bt.BackgroundEndColor;
        btn.HoverStartColor = bt.HoverStartColor;
        btn.HoverEndColor = bt.HoverEndColor;
        btn.PressedStartColor = bt.PressedStartColor;
        btn.PressedEndColor = bt.PressedEndColor;
        btn.DisabledStartColor = bt.DisabledStartColor;
        btn.DisabledEndColor = bt.DisabledEndColor;
        btn.GradientAngle = bt.GradientAngle;

        // Text State Colors
        btn.ForeColor = bt.TextColor;
        btn.TextColor = bt.TextColor;
        btn.HoverTextColor = bt.HoverTextColor;
        btn.DisabledTextColor = bt.DisabledTextColor;

        // Borders & Smoothness
        btn.BorderRadius = bt.BorderRadius;
        btn.BorderSize = bt.BorderSize;
        btn.BorderColor = bt.BorderColor;
        btn.HoverBorderColor = bt.HoverBorderColor;
        btn.DisabledBorderColor = bt.DisabledBorderColor;

        // Icon Color Tinting (Leave dimensions & offsets to the designer)
        btn.EnableIconTinting = bt.EnableIconTinting;
        btn.IconColor = bt.IconColor;
        btn.HoverIconColor = bt.HoverIconColor;

        // Shadows
        btn.ShadowColor = bt.ShadowColor;
        btn.ShadowSize = bt.ShadowSize;
        btn.ShadowOffset = bt.ShadowOffset;

        // Ripple
        btn.RippleColor = bt.RippleColor;
        btn.RippleSpeed = bt.RippleSpeed;
        btn.HoverAnimationSpeed = bt.HoverAnimationSpeed;

        // Preserve the button's specific size and style, only unify the font family
        if (common is not null && !string.IsNullOrEmpty(common.FontFamily))
        {
            btn.Font = new Font(common.FontFamily, btn.Font.Size, btn.Font.Style);
        }
    }

    public static void ApplyTextBoxProperties(NTextBox txtBox, TextBoxTheme tt, CommonTheme? common = null)
    {
        if (txtBox is null || tt is null) return;

        txtBox.FillColor = tt.Background;
        txtBox.DisabledFillColor = tt.DisabledBackground;
        txtBox.ForeColor = tt.TextColor;
        txtBox.BorderColor = tt.BorderColor;
        txtBox.BorderFocusColor = tt.FocusBorderColor;
        txtBox.DisabledBorderColor = tt.DisabledBorderColor;
        txtBox.ErrorBorderColor = tt.ErrorBorderColor;
        txtBox.PlaceholderColor = tt.PlaceholderColor;
        txtBox.BorderRadius = tt.BorderRadius;
        txtBox.BorderSize = tt.BorderSize;
        txtBox.EnableIconTinting = tt.EnableIconTinting;
        txtBox.IconColor = tt.IconColor;
        txtBox.HoverIconColor = tt.HoverIconColor;
        txtBox.ClearButtonColor = tt.ClearButtonColor;
        txtBox.ClearButtonHoverColor = tt.ClearButtonHoverColor;
        txtBox.SuggestBackground = tt.SuggestBackground;
        txtBox.SuggestTextColor = tt.SuggestTextColor;
        txtBox.SuggestHoverColor = tt.SuggestHoverColor;
        txtBox.SuggestBorderColor = tt.SuggestBorderColor;

        if (common is not null && !string.IsNullOrEmpty(common.FontFamily))
        {
            txtBox.Font = new Font(common.FontFamily, common.DefaultFontSize > 0 ? common.DefaultFontSize : txtBox.Font.Size);
        }
    }

    public static void ApplyCheckBoxProperties(NCheckBox chkBox, CheckBoxTheme ct, CommonTheme? common = null)
    {
        if (chkBox is null || ct is null) return;

        chkBox.BoxBackColor = ct.BoxBackground;
        chkBox.BoxBorderColor = ct.BoxBorder;
        chkBox.ForeColor = ct.TextColor;
        chkBox.CheckedColor = ct.CheckedColor;
        chkBox.HoverBorderColor = ct.HoverBorderColor;
        chkBox.DisabledColor = ct.DisabledColor;
        chkBox.CheckMarkColor = ct.CheckMarkColor;
        chkBox.DisabledTextColor = ct.DisabledTextColor;
        chkBox.SwitchOffTrackColor = ct.SwitchOffTrackColor;
        chkBox.SwitchThumbColor = ct.SwitchThumbColor;
        chkBox.CheckThickness = ct.CheckThickness;
        chkBox.BorderRadius = ct.BorderRadius;
        chkBox.BorderSize = ct.BorderSize;
        chkBox.EnableAnimation = ct.EnableAnimation;
        chkBox.AnimationSpeed = ct.AnimationSpeed;
        chkBox.EnableRipple = ct.EnableRipple;
        chkBox.RippleColor = ct.RippleColor;

        if (common is not null && !string.IsNullOrEmpty(common.FontFamily))
        {
            chkBox.Font = new Font(common.FontFamily, common.DefaultFontSize > 0 ? common.DefaultFontSize : chkBox.Font.Size);
        }
    }

    public static void ApplyComboBoxProperties(ComboBox comboBox, ComboBoxTheme cb, CommonTheme? common = null)
    {
        if (comboBox is null || cb is null) return;

        comboBox.BackColor = cb.Background;
        comboBox.ForeColor = cb.Foreground;
        comboBox.FlatStyle = FlatStyle.Flat;
    }

    public static void ApplyDataGridProperties(NDataGrid dataGrid, DataGridTheme dt, CommonTheme? common = null)
    {
        if (dataGrid is null || dt is null) return;

        dataGrid.BackgroundColor = dt.Background;
        dataGrid.GridColor = dt.GridColor;
        dataGrid.BorderStyle = BorderStyle.None;
        dataGrid.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
        dataGrid.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
        dataGrid.EnableHeadersVisualStyles = false;

        string fontFamily = common is not null && !string.IsNullOrEmpty(common.FontFamily)
            ? common.FontFamily
            : "Segoe UI";

        dataGrid.ColumnHeadersDefaultCellStyle.BackColor = dt.HeaderBackground;
        dataGrid.ColumnHeadersDefaultCellStyle.ForeColor = dt.HeaderForeground;
        dataGrid.ColumnHeadersDefaultCellStyle.SelectionBackColor = dt.HeaderSelectionBackground;
        dataGrid.ColumnHeadersDefaultCellStyle.SelectionForeColor = dt.HeaderSelectionForeground;

        dataGrid.DefaultCellStyle.BackColor = dt.CellBackground;
        dataGrid.DefaultCellStyle.ForeColor = dt.CellForeground;
        dataGrid.DefaultCellStyle.SelectionBackColor = dt.SelectionBackground;
        dataGrid.DefaultCellStyle.SelectionForeColor = dt.SelectionForeground;

        dataGrid.AlternatingRowsDefaultCellStyle.BackColor = dt.AlternatingRowBackground;
        dataGrid.AlternatingRowsDefaultCellStyle.ForeColor = dt.AlternatingRowForeground;
        dataGrid.AlternatingRowsDefaultCellStyle.SelectionBackColor = dt.SelectionBackground;
        dataGrid.AlternatingRowsDefaultCellStyle.SelectionForeColor = dt.SelectionForeground;
    }

    public static void ApplyFormProperties(Form frm, FormTheme ft, CommonTheme? common = null)
    {
        if (frm is null || ft is null) return;

        frm.BackColor = ft.Background;
        frm.ForeColor = ft.Foreground;

        if (common is not null && !string.IsNullOrEmpty(common.FontFamily))
        {
            frm.Font = new Font(common.FontFamily, common.DefaultFontSize > 0 ? common.DefaultFontSize : frm.Font.Size);
        }
    }

    public static void ApplyLabelProperties(Label lbl, LabelTheme lt, CommonTheme? common = null)
    {
        if (lbl is null || lt is null) return;

        lbl.ForeColor = lt.PrimaryColor;
    }

    public static void ApplyMenuProperties(NMenuRenderer menu, MenuTheme mt)
    {
        if (menu is null || mt is null) return;

        menu.ColorTable.CustomBackground = mt.Background;
        menu.ColorTable.CustomBorder = mt.Border;
        menu.ColorTable.CustomItemSelected = mt.ItemHoverBackground;
        menu.ColorTable.CustomItemPressed = mt.ItemPressedBackground;
        menu.ColorTable.CustomSeparator = mt.Separator;

        menu.ItemTextColor = mt.ItemText;
        menu.ItemHoverTextColor = mt.ItemHoverText;
        menu.ItemPressedTextColor = mt.ItemPressedText;
        menu.DisabledTextColor = mt.DisabledText;
        menu.AccentColor = mt.Accent;
        menu.ArrowColor = mt.Arrow;
        menu.DangerTextColor = mt.DangerText;
        menu.DangerHoverBackground = mt.DangerHoverBackground;
        menu.BorderSize = mt.BorderSize;
        menu.ItemHorizontalPadding = mt.ItemHorizontalPadding;
        menu.ItemVerticalPadding = mt.ItemVerticalPadding;
        menu.SeparatorHeight = mt.SeparatorHeight;
        menu.AccentSize = mt.AccentSize;
    }

    public static void ApplyNotificationProperties(NotificationBuilder notification, NotificationTheme nt)
    {
        if (notification is null || nt is null) return;

        notification.ConfigureVisuals(
            background: nt.Background,
            textColor: nt.TextColor,
            borderColor: nt.BorderColor,
            progressBarColor: nt.ProgressBarColor,
            successColor: nt.SuccessColor,
            dangerColor: nt.DangerColor,
            warningColor: nt.WarningColor,
            infoColor: nt.InfoColor,
            titleFontSize: nt.TitleFontSize,
            messageFontSize: nt.MessageFontSize,
            borderSize: nt.BorderSize,
            borderRadius: nt.BorderRadius,
            padding: nt.Padding
        );
    }

    public static void ApplyPanelProperties(Panel panel, PanelTheme pt)
    {
        if (panel is null || pt is null) return;

        panel.BackColor = pt.Background;
        panel.ForeColor = pt.Foreground;
    }

    public static void ApplyToolStripProperties(ToolStrip toolStrip, ToolStripTheme tt, CommonTheme? common = null)
    {
        if (toolStrip is null || tt is null) return;

        toolStrip.BackColor = tt.Background;
        toolStrip.ForeColor = tt.Foreground;
    }
}