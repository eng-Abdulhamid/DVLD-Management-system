using System;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;
using CustomizeControls;
using DVLD.PL.Global;
using DVLD.PL.Theme;

namespace DVLD.PL.Home;

public partial class frmAppearanceSettings : BaseForm
{
    private readonly ThemeSettingsStore _settingsStore = new();
    private ThemeAppSettings _currentSettings = new();
    private bool _isInitializing = true;

    public frmAppearanceSettings()
    {
        InitializeComponent();
        SetContextTitle("Appearance & Theme");
        InitializePresetsData();
    }

    private void InitializePresetsData()
    {
        cmbThemeMode.DataSource = Enum.GetValues<enMode>();

        cmbAccentColor.DataSource = ThemePalettePresets.AccentPresets;
        cmbAccentColor.DisplayMember = "Name";
        cmbAccentColor.ValueMember = "Color";

        cmbDarkTone.DataSource = Enum.GetValues<enDarkTone>();
        cmbLightTone.DataSource = Enum.GetValues<enLightTone>();
        cmbUIDensity.DataSource = Enum.GetValues<enUIDensity>();
        cmbButtonStyle.DataSource = Enum.GetValues<enButtonStyleMode>();
    }

    protected override async Task InitializeDataAsync()
    {
        _isInitializing = true;
        _currentSettings = await _settingsStore.LoadAsync();
        BindSettingsToControls(_currentSettings);
        _isInitializing = false;

        UpdateControlsVisibility();
        UpdateLivePreview();
    }

    private void BindSettingsToControls(ThemeAppSettings settings)
    {
        cmbThemeMode.SelectedItem = settings.Mode;

        var prefs = settings.Preferences;
        SetAccentColorSelection(prefs.AccentColor);

        numBorderRadius.Value = Math.Clamp(prefs.BorderRadius, (int)numBorderRadius.Minimum, (int)numBorderRadius.Maximum);
        cmbDarkTone.SelectedItem = prefs.DarkTone;
        cmbLightTone.SelectedItem = prefs.LightTone;
        cmbUIDensity.SelectedItem = prefs.Density;
        cmbButtonStyle.SelectedItem = prefs.ButtonStyle;

        chkPerformanceMode.Checked = prefs.PerformanceMode;
        chkAlternatingRows.Checked = prefs.EnableAlternatingRows;
    }

    private void SetAccentColorSelection(Color color)
    {
        for (int i = 0; i < ThemePalettePresets.AccentPresets.Count; i++)
        {
            if (ThemePalettePresets.AccentPresets[i].Color.ToArgb() == color.ToArgb())
            {
                cmbAccentColor.SelectedIndex = i;
                return;
            }
        }
        cmbAccentColor.SelectedIndex = 0;
    }

    private ThemePreferences CollectPreferencesFromUI()
    {
        Color selectedAccent = cmbAccentColor.SelectedValue is Color c
            ? c
            : Color.FromArgb(99, 102, 241);

        return new ThemePreferences
        {
            AccentColor = selectedAccent,
            BorderRadius = (int)numBorderRadius.Value,
            FontFamily = "Segoe UI",
            FontSize = 9.5f,
            DarkTone = cmbDarkTone.SelectedValue is enDarkTone dt ? dt : enDarkTone.DeepSlate,
            LightTone = cmbLightTone.SelectedValue is enLightTone lt ? lt : enLightTone.SnowGray,
            Density = cmbUIDensity.SelectedValue is enUIDensity den ? den : enUIDensity.Normal,
            ButtonStyle = cmbButtonStyle.SelectedValue is enButtonStyleMode bs ? bs : enButtonStyleMode.Gradient,
            PerformanceMode = chkPerformanceMode.Checked,
            EnableAlternatingRows = chkAlternatingRows.Checked
        };
    }

    private void TriggerLivePreviewIfEnabled()
    {
        if (_isInitializing || !chkLivePreview.Checked) return;
        UpdateLivePreview();
    }

    private void UpdateLivePreview()
    {
        enMode selectedMode = cmbThemeMode.SelectedValue is enMode mode ? mode : enMode.DefaultDark;
        ThemePreferences currentPrefs = CollectPreferencesFromUI();

        IThemeProvider provider = selectedMode switch
        {
            enMode.DefaultLight => new DefaultLightThemeProvider(),
            enMode.DefaultDark => new DefaultDarkThemeProvider(),
            enMode.CustomDark => new CustomDarkThemeProvider(currentPrefs),
            enMode.CustomLight => new CustomLightThemeProvider(currentPrefs),
            _ => new DefaultDarkThemeProvider()
        };

        Theme.Theme previewTheme = provider.BuildTheme();
        IControlApplicator previewApplicator = new ControlApplicator(previewTheme);

        ApplyThemeToPreviewCard(previewApplicator);
    }

    private void ApplyThemeToPreviewCard(IControlApplicator applicator)
    {
        pnlPreviewContainer.BackColor = applicator.theme.Form.Background;
        pnlPreviewCard.BackColor = applicator.theme.Panel.Background;

        applicator.ApplyCurrentPrimaryButtonTheme(btnPreviewPrimary);
        applicator.ApplyCurrentSecondaryButtonTheme(btnPreviewSecondary);
        applicator.ApplyCurrentDangerButtonTheme(btnPreviewDanger);
        applicator.ApplyCurrentDisabledButtonTheme(btnPreviewDisabled);

        applicator.ApplyCurrentTextBoxTheme(txtPreviewInput);
        applicator.ApplyCurrentCheckBoxTheme(chkPreviewCheck);
        applicator.ApplyCurrentComboBoxTheme(cmbPreviewCombo);

        lblPreviewSampleText.ForeColor = applicator.theme.Label.PrimaryColor;
        lblPreviewMutedText.ForeColor = applicator.theme.Label.MutedColor;
    }

    private void UpdateControlsVisibility()
    {
        enMode selectedMode = cmbThemeMode.SelectedValue is enMode mode ? mode : enMode.DefaultDark;
        bool isCustom = selectedMode is enMode.CustomDark or enMode.CustomLight;
        bool isDark = selectedMode is enMode.CustomDark or enMode.DefaultDark;

        pnlCustomOptions.Enabled = isCustom;
        lblDarkTone.Visible = isCustom && isDark;
        cmbDarkTone.Visible = isCustom && isDark;

        lblLightTone.Visible = isCustom && !isDark;
        cmbLightTone.Visible = isCustom && !isDark;
    }

    private void SettingControl_ValueChanged(object? sender, EventArgs e)
    {
        UpdateControlsVisibility();
        TriggerLivePreviewIfEnabled();
    }

    private void chkLivePreview_CheckedChanged(object? sender, EventArgs e)
    {
        if (chkLivePreview.Checked)
        {
            UpdateLivePreview();
        }
    }

    private async void btnSaveAndApply_Click(object? sender, EventArgs e)
    {
        btnSaveAndApply.IsLoading = true;
        btnSaveAndApply.Enabled = false;

        enMode selectedMode = cmbThemeMode.SelectedValue is enMode mode ? mode : enMode.DefaultDark;
        ThemePreferences currentPrefs = CollectPreferencesFromUI();

        _currentSettings = new ThemeAppSettings
        {
            Mode = selectedMode,
            Preferences = currentPrefs
        };

        await _settingsStore.SaveAsync(_currentSettings);

        ThemeManager.SetMode(_currentSettings.Mode, _currentSettings.Preferences);
        this.ApplyThemeToAll();

        btnSaveAndApply.IsLoading = false;
        btnSaveAndApply.Enabled = true;

        new NotificationBuilder()
            .WithTitle("Theme Updated")
            .WithMessage("Appearance settings applied and saved successfully.")
            .WithType(IconType.Success)
            .WithDuration(3)
            .Show();
    }

    private void btnResetDefault_Click(object? sender, EventArgs e)
    {
        _isInitializing = true;
        var defaultSettings = new ThemeAppSettings();
        BindSettingsToControls(defaultSettings);
        _isInitializing = false;

        UpdateControlsVisibility();
        UpdateLivePreview();
    }

    private void btnClose_Click(object? sender, EventArgs e)
    {
        Close();
    }
}