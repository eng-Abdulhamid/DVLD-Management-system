namespace DVLD.PL.ControlsTheme
{
    public sealed class CommonTheme
    {
        public string FontFamily { get; init; } =
            "Segoe UI";

        public float DefaultFontSize { get; init; }

        public int DefaultBorderRadius { get; init; }

        public int DefaultBorderSize { get; init; }

        public bool EnableAnimations { get; init; }

        public bool EnableRippleEffects { get; init; }

        public bool EnableShadows { get; init; }
    }
}