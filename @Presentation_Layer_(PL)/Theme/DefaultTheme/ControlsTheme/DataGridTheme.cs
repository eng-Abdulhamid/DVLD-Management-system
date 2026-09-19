namespace DVLD.PL.Theme
{
    public static class DataGridTheme
    {
        public static int RowHeight { get; set; } = 42;

        public static int HeaderHeight { get; set; } = 44;

        public static float HeaderFontSize { get; set; } = 10F;

        public static float CellFontSize { get; set; } = 9.5F;

        public static int HorizontalPadding { get; set; } = 12;

        public static void ApplyDataGridStyle(this DataGridView dgv)
        {
            if (dgv == null)
                return;

            ApplyGeneralSettings(dgv);
            ApplyHeaderStyle(dgv);
            ApplyDefaultCellStyle(dgv);
            ApplyAlternatingRowStyle(dgv);
        }

        private static void ApplyGeneralSettings(DataGridView dgv)
        {
            var colors = ThemeManager.Current;

            dgv.BackgroundColor = colors.Surface;
            dgv.BorderStyle = BorderStyle.None;
            dgv.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgv.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;

            dgv.EnableHeadersVisualStyles = false;

            dgv.GridColor = colors.Border;

            dgv.RowHeadersVisible = false;

            dgv.RowTemplate.Height = RowHeight;
            dgv.ColumnHeadersHeight = HeaderHeight;

            dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgv.MultiSelect = false;

            dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private static void ApplyHeaderStyle(DataGridView dgv)
        {
            var colors = ThemeManager.Current;

            dgv.ColumnHeadersDefaultCellStyle = new DataGridViewCellStyle
            {
                Alignment = DataGridViewContentAlignment.MiddleLeft,
                BackColor = colors.Background,
                Font = CommonTheme.CreateFont(
                    HeaderFontSize,
                    FontStyle.Bold),
                ForeColor = colors.TextSecondary,
                SelectionBackColor = colors.Background,
                SelectionForeColor = colors.TextSecondary,
                Padding = new Padding(HorizontalPadding, 0, 0, 0)
            };
        }

        private static void ApplyDefaultCellStyle(DataGridView dgv)
        {
            var colors = ThemeManager.Current;

            dgv.DefaultCellStyle = CreateCellStyle(
                colors.Surface,
                colors.TextPrimary);
        }

        private static void ApplyAlternatingRowStyle(DataGridView dgv)
        {
            var colors = ThemeManager.Current;

            dgv.AlternatingRowsDefaultCellStyle = CreateCellStyle(
                colors.Background,
                colors.TextPrimary);
        }

        private static DataGridViewCellStyle CreateCellStyle(
            Color background,
            Color foreground)
        {
            var colors = ThemeManager.Current;

            return new DataGridViewCellStyle
            {
                Alignment = DataGridViewContentAlignment.MiddleLeft,
                BackColor = background,
                Font = CommonTheme.CreateFont(CellFontSize),
                ForeColor = foreground,
                SelectionBackColor = colors.SelectionBg,
                SelectionForeColor = colors.SelectionText,
                Padding = new Padding(HorizontalPadding, 0, 0, 0)
            };
        }
    }
}