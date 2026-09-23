using System.Drawing;
using System.Windows.Forms;

namespace DVLD.PL.Home
{
    partial class frmAppearanceSettings
    {
        private System.ComponentModel.IContainer components = null;

        private Panel pnlMainLayout;
        private Panel pnlLeftControls;
        private Panel pnlCustomOptions;
        private Panel pnlPreviewContainer;
        private Panel pnlPreviewCard;
        private Panel pnlActionsFooter;

        private Label lblTitleAppearance;
        private Label lblThemeMode;
        private ComboBox cmbThemeMode;

        private Label lblAccentColor;
        private ComboBox cmbAccentColor;

        private Label lblBorderRadius;
        private NumericUpDown numBorderRadius;

        private Label lblDarkTone;
        private ComboBox cmbDarkTone;

        private Label lblLightTone;
        private ComboBox cmbLightTone;

        private Label lblUIDensity;
        private ComboBox cmbUIDensity;

        private Label lblButtonStyle;
        private ComboBox cmbButtonStyle;

        private CustomizeControls.NCheckBox chkPerformanceMode;
        private CustomizeControls.NCheckBox chkAlternatingRows;
        private CustomizeControls.NCheckBox chkLivePreview;

        private Label lblPreviewHeader;
        private Label lblPreviewSampleText;
        private Label lblPreviewMutedText;
        private CustomizeControls.NButton btnPreviewPrimary;
        private CustomizeControls.NButton btnPreviewSecondary;
        private CustomizeControls.NButton btnPreviewDanger;
        private CustomizeControls.NButton btnPreviewDisabled;
        private CustomizeControls.NTextBox txtPreviewInput;
        private CustomizeControls.NCheckBox chkPreviewCheck;
        private ComboBox cmbPreviewCombo;

        private CustomizeControls.NButton btnSaveAndApply;
        private CustomizeControls.NButton btnResetDefault;
        private CustomizeControls.NButton btnCancel;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            pnlMainLayout = new Panel();
            pnlPreviewContainer = new Panel();
            pnlPreviewCard = new Panel();
            lblPreviewHeader = new Label();
            btnPreviewPrimary = new CustomizeControls.NButton();
            btnPreviewSecondary = new CustomizeControls.NButton();
            btnPreviewDanger = new CustomizeControls.NButton();
            btnPreviewDisabled = new CustomizeControls.NButton();
            txtPreviewInput = new CustomizeControls.NTextBox();
            chkPreviewCheck = new CustomizeControls.NCheckBox();
            cmbPreviewCombo = new ComboBox();
            lblPreviewSampleText = new Label();
            lblPreviewMutedText = new Label();
            pnlLeftControls = new Panel();
            lblTitleAppearance = new Label();
            lblThemeMode = new Label();
            cmbThemeMode = new ComboBox();
            pnlCustomOptions = new Panel();
            lblAccentColor = new Label();
            cmbAccentColor = new ComboBox();
            lblBorderRadius = new Label();
            numBorderRadius = new NumericUpDown();
            lblDarkTone = new Label();
            cmbDarkTone = new ComboBox();
            lblLightTone = new Label();
            cmbLightTone = new ComboBox();
            lblUIDensity = new Label();
            cmbUIDensity = new ComboBox();
            lblButtonStyle = new Label();
            cmbButtonStyle = new ComboBox();
            chkPerformanceMode = new CustomizeControls.NCheckBox();
            chkAlternatingRows = new CustomizeControls.NCheckBox();
            chkLivePreview = new CustomizeControls.NCheckBox();
            pnlActionsFooter = new Panel();
            btnSaveAndApply = new CustomizeControls.NButton();
            btnResetDefault = new CustomizeControls.NButton();
            btnCancel = new CustomizeControls.NButton();

            pnlMainLayout.SuspendLayout();
            pnlPreviewContainer.SuspendLayout();
            pnlPreviewCard.SuspendLayout();
            pnlLeftControls.SuspendLayout();
            pnlCustomOptions.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numBorderRadius).BeginInit();
            pnlActionsFooter.SuspendLayout();
            SuspendLayout();

            // headerControl
            headerControl.Size = new Size(920, 36);
            headerControl.TitleText = "Appearance & Theme Settings";

            // pnlMainLayout
            pnlMainLayout.Dock = DockStyle.Fill;
            pnlMainLayout.Location = new Point(2, 38);
            pnlMainLayout.Name = "pnlMainLayout";
            pnlMainLayout.Padding = new Padding(16);
            pnlMainLayout.Size = new Size(916, 560);
            pnlMainLayout.TabIndex = 1;
            pnlMainLayout.Controls.Add(pnlPreviewContainer);
            pnlMainLayout.Controls.Add(pnlLeftControls);
            pnlMainLayout.Controls.Add(pnlActionsFooter);

            // pnlActionsFooter
            pnlActionsFooter.Dock = DockStyle.Bottom;
            pnlActionsFooter.Height = 52;
            pnlActionsFooter.Padding = new Padding(0, 8, 0, 0);
            pnlActionsFooter.Controls.Add(btnCancel);
            pnlActionsFooter.Controls.Add(btnResetDefault);
            pnlActionsFooter.Controls.Add(btnSaveAndApply);

            // btnSaveAndApply
            btnSaveAndApply.Anchor = AnchorStyles.Right | AnchorStyles.Top;
            btnSaveAndApply.ButtonType = CustomizeControls.enButtonType.Primary;
            btnSaveAndApply.Location = new Point(746, 8);
            btnSaveAndApply.Size = new Size(170, 38);
            btnSaveAndApply.Text = "Save & Apply Theme";
            btnSaveAndApply.Click += btnSaveAndApply_Click;

            // btnResetDefault
            btnResetDefault.Anchor = AnchorStyles.Left | AnchorStyles.Top;
            btnResetDefault.ButtonType = CustomizeControls.enButtonType.Secondary;
            btnResetDefault.Location = new Point(0, 8);
            btnResetDefault.Size = new Size(130, 38);
            btnResetDefault.Text = "Reset Defaults";
            btnResetDefault.Click += btnResetDefault_Click;

            // btnCancel
            btnCancel.Anchor = AnchorStyles.Right | AnchorStyles.Top;
            btnCancel.ButtonType = CustomizeControls.enButtonType.Secondary;
            btnCancel.Location = new Point(630, 8);
            btnCancel.Size = new Size(106, 38);
            btnCancel.Text = "Close";
            btnCancel.Click += btnClose_Click;

            // pnlLeftControls
            pnlLeftControls.Dock = DockStyle.Left;
            pnlLeftControls.Width = 420;
            pnlLeftControls.AutoScroll = true;
            pnlLeftControls.Padding = new Padding(0, 0, 16, 0);
            pnlLeftControls.Controls.Add(chkLivePreview);
            pnlLeftControls.Controls.Add(pnlCustomOptions);
            pnlLeftControls.Controls.Add(cmbThemeMode);
            pnlLeftControls.Controls.Add(lblThemeMode);
            pnlLeftControls.Controls.Add(lblTitleAppearance);

            // lblTitleAppearance
            lblTitleAppearance.Text = "Theme Customization";
            lblTitleAppearance.Font = new Font("Segoe UI Semibold", 13F, FontStyle.Bold);
            lblTitleAppearance.Location = new Point(0, 0);
            lblTitleAppearance.Size = new Size(380, 30);

            // lblThemeMode
            lblThemeMode.Text = "Operating Theme Mode";
            lblThemeMode.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblThemeMode.Location = new Point(2, 36);
            lblThemeMode.Size = new Size(200, 18);

            // cmbThemeMode
            cmbThemeMode.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbThemeMode.Location = new Point(2, 58);
            cmbThemeMode.Size = new Size(380, 26);
            cmbThemeMode.SelectedIndexChanged += SettingControl_ValueChanged;

            // pnlCustomOptions
            pnlCustomOptions.Location = new Point(0, 94);
            pnlCustomOptions.Size = new Size(390, 360);
            pnlCustomOptions.Controls.Add(lblAccentColor);
            pnlCustomOptions.Controls.Add(cmbAccentColor);
            pnlCustomOptions.Controls.Add(lblBorderRadius);
            pnlCustomOptions.Controls.Add(numBorderRadius);
            pnlCustomOptions.Controls.Add(lblDarkTone);
            pnlCustomOptions.Controls.Add(cmbDarkTone);
            pnlCustomOptions.Controls.Add(lblLightTone);
            pnlCustomOptions.Controls.Add(cmbLightTone);
            pnlCustomOptions.Controls.Add(lblUIDensity);
            pnlCustomOptions.Controls.Add(cmbUIDensity);
            pnlCustomOptions.Controls.Add(lblButtonStyle);
            pnlCustomOptions.Controls.Add(cmbButtonStyle);
            pnlCustomOptions.Controls.Add(chkPerformanceMode);
            pnlCustomOptions.Controls.Add(chkAlternatingRows);

            // lblAccentColor
            lblAccentColor.Text = "Primary Accent Color";
            lblAccentColor.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblAccentColor.Location = new Point(2, 8);
            lblAccentColor.Size = new Size(200, 18);

            // cmbAccentColor
            cmbAccentColor.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbAccentColor.Location = new Point(2, 28);
            cmbAccentColor.Size = new Size(380, 26);
            cmbAccentColor.SelectedIndexChanged += SettingControl_ValueChanged;

            // lblBorderRadius
            lblBorderRadius.Text = "Corner Smoothness (Border Radius)";
            lblBorderRadius.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblBorderRadius.Location = new Point(2, 64);
            lblBorderRadius.Size = new Size(260, 18);

            // numBorderRadius
            numBorderRadius.Location = new Point(2, 84);
            numBorderRadius.Size = new Size(380, 26);
            numBorderRadius.Minimum = 0;
            numBorderRadius.Maximum = 24;
            numBorderRadius.Value = 8;
            numBorderRadius.ValueChanged += SettingControl_ValueChanged;

            // lblDarkTone
            lblDarkTone.Text = "Dark Theme Palette Tone";
            lblDarkTone.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblDarkTone.Location = new Point(2, 120);
            lblDarkTone.Size = new Size(200, 18);

            // cmbDarkTone
            cmbDarkTone.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbDarkTone.Location = new Point(2, 140);
            cmbDarkTone.Size = new Size(380, 26);
            cmbDarkTone.SelectedIndexChanged += SettingControl_ValueChanged;

            // lblLightTone
            lblLightTone.Text = "Light Theme Palette Tone";
            lblLightTone.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblLightTone.Location = new Point(2, 120);
            lblLightTone.Size = new Size(200, 18);

            // cmbLightTone
            cmbLightTone.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbLightTone.Location = new Point(2, 140);
            cmbLightTone.Size = new Size(380, 26);
            cmbLightTone.SelectedIndexChanged += SettingControl_ValueChanged;

            // lblUIDensity
            lblUIDensity.Text = "User Interface Spacing (Density)";
            lblUIDensity.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblUIDensity.Location = new Point(2, 176);
            lblUIDensity.Size = new Size(240, 18);

            // cmbUIDensity
            cmbUIDensity.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbUIDensity.Location = new Point(2, 196);
            cmbUIDensity.Size = new Size(380, 26);
            cmbUIDensity.SelectedIndexChanged += SettingControl_ValueChanged;

            // lblButtonStyle
            lblButtonStyle.Text = "Button Surface Fill Style";
            lblButtonStyle.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblButtonStyle.Location = new Point(2, 232);
            lblButtonStyle.Size = new Size(200, 18);

            // cmbButtonStyle
            cmbButtonStyle.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbButtonStyle.Location = new Point(2, 252);
            cmbButtonStyle.Size = new Size(380, 26);
            cmbButtonStyle.SelectedIndexChanged += SettingControl_ValueChanged;

            // chkAlternatingRows
            chkAlternatingRows.Location = new Point(4, 292);
            chkAlternatingRows.Size = new Size(240, 24);
            chkAlternatingRows.Text = "Alternating Grid Row Colors";
            chkAlternatingRows.Checked = true;
            chkAlternatingRows.CheckedChanged += SettingControl_ValueChanged;

            // chkPerformanceMode
            chkPerformanceMode.Location = new Point(4, 324);
            chkPerformanceMode.Size = new Size(240, 24);
            chkPerformanceMode.Text = "Performance Mode (No Shadows)";
            chkPerformanceMode.Checked = false;
            chkPerformanceMode.CheckedChanged += SettingControl_ValueChanged;

            // chkLivePreview
            chkLivePreview.Location = new Point(4, 462);
            chkLivePreview.Size = new Size(220, 24);
            chkLivePreview.Text = "Enable Live Interactive Preview";
            chkLivePreview.Checked = true;
            chkLivePreview.CheckedChanged += chkLivePreview_CheckedChanged;

            // pnlPreviewContainer
            pnlPreviewContainer.Dock = DockStyle.Fill;
            pnlPreviewContainer.Padding = new Padding(12);
            pnlPreviewContainer.Controls.Add(pnlPreviewCard);

            // pnlPreviewCard
            pnlPreviewCard.Dock = DockStyle.Fill;
            pnlPreviewCard.Padding = new Padding(24);
            pnlPreviewCard.Controls.Add(cmbPreviewCombo);
            pnlPreviewCard.Controls.Add(chkPreviewCheck);
            pnlPreviewCard.Controls.Add(txtPreviewInput);
            pnlPreviewCard.Controls.Add(btnPreviewDisabled);
            pnlPreviewCard.Controls.Add(btnPreviewDanger);
            pnlPreviewCard.Controls.Add(btnPreviewSecondary);
            pnlPreviewCard.Controls.Add(btnPreviewPrimary);
            pnlPreviewCard.Controls.Add(lblPreviewMutedText);
            pnlPreviewCard.Controls.Add(lblPreviewSampleText);
            pnlPreviewCard.Controls.Add(lblPreviewHeader);

            // lblPreviewHeader
            lblPreviewHeader.Text = "LIVE INTERACTIVE PREVIEW";
            lblPreviewHeader.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            lblPreviewHeader.ForeColor = Color.FromArgb(148, 163, 184);
            lblPreviewHeader.Location = new Point(24, 20);
            lblPreviewHeader.Size = new Size(300, 22);

            // lblPreviewSampleText
            lblPreviewSampleText.Text = "Driving & Vehicle Licensing Portal";
            lblPreviewSampleText.Font = new Font("Segoe UI Semibold", 13F, FontStyle.Bold);
            lblPreviewSampleText.Location = new Point(24, 48);
            lblPreviewSampleText.Size = new Size(350, 26);

            // lblPreviewMutedText
            lblPreviewMutedText.Text = "This preview demonstrates changes immediately as you adjust settings.";
            lblPreviewMutedText.Font = new Font("Segoe UI", 9F);
            lblPreviewMutedText.Location = new Point(24, 76);
            lblPreviewMutedText.Size = new Size(400, 20);

            // btnPreviewPrimary
            btnPreviewPrimary.ButtonType = CustomizeControls.enButtonType.Primary;
            btnPreviewPrimary.Location = new Point(24, 114);
            btnPreviewPrimary.Size = new Size(130, 36);
            btnPreviewPrimary.Text = "Save Action";

            // btnPreviewSecondary
            btnPreviewSecondary.ButtonType = CustomizeControls.enButtonType.Secondary;
            btnPreviewSecondary.Location = new Point(164, 114);
            btnPreviewSecondary.Size = new Size(130, 36);
            btnPreviewSecondary.Text = "Cancel Action";

            // btnPreviewDanger
            btnPreviewDanger.ButtonType = CustomizeControls.enButtonType.Danger;
            btnPreviewDanger.Location = new Point(24, 160);
            btnPreviewDanger.Size = new Size(130, 36);
            btnPreviewDanger.Text = "Delete Record";

            // btnPreviewDisabled
            btnPreviewDisabled.ButtonType = CustomizeControls.enButtonType.Disabled;
            btnPreviewDisabled.Enabled = false;
            btnPreviewDisabled.Location = new Point(164, 160);
            btnPreviewDisabled.Size = new Size(130, 36);
            btnPreviewDisabled.Text = "Disabled State";

            // txtPreviewInput
            txtPreviewInput.Location = new Point(24, 214);
            txtPreviewInput.Size = new Size(380, 40);
            txtPreviewInput.PlaceholderText = "Type something to test input styling...";
            txtPreviewInput.Text = "Active Driver Record: #1042";

            // chkPreviewCheck
            chkPreviewCheck.Location = new Point(24, 270);
            chkPreviewCheck.Size = new Size(200, 24);
            chkPreviewCheck.Text = "Active Driver License";
            chkPreviewCheck.Checked = true;

            // cmbPreviewCombo
            cmbPreviewCombo.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbPreviewCombo.Location = new Point(24, 306);
            cmbPreviewCombo.Size = new Size(380, 26);
            cmbPreviewCombo.Items.AddRange(new object[] { "Class 1 - Small Motorcycle", "Class 3 - Ordinary Driving License", "Class 5 - Agricultural Vehicle" });
            cmbPreviewCombo.SelectedIndex = 1;

            // frmAppearanceSettings
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(920, 600);
            MinimumSize = new Size(880, 560);
            Controls.Add(pnlMainLayout);
            Name = "frmAppearanceSettings";
            Text = "Appearance & Theme Settings";

            pnlMainLayout.ResumeLayout(false);
            pnlPreviewContainer.ResumeLayout(false);
            pnlPreviewCard.ResumeLayout(false);
            pnlLeftControls.ResumeLayout(false);
            pnlCustomOptions.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)numBorderRadius).EndInit();
            pnlActionsFooter.ResumeLayout(false);
            ResumeLayout(false);
        }
    }
}