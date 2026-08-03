# ModernLabel - ????? ?????

## ?????
`ModernLabel` ?? ???? ???? ???? ????? ?? ?????? ?? ?????? ????? ?????????? ??????? ????????.

---

## ?? ?????? ???????? ???????

### 1. ?????? (Appearance)
```csharp
modernLabel1.BackgroundColor = Color.FromArgb(30, 30, 30);
modernLabel1.BackgroundGradientStartColor = Color.FromArgb(45, 45, 45);
modernLabel1.BackgroundGradientEndColor = Color.FromArgb(25, 25, 25);
modernLabel1.BackgroundGradientMode = LinearGradientMode.Vertical;
modernLabel1.UseGradient = true;

modernLabel1.BorderColor = Color.FromArgb(100, 180, 255);
modernLabel1.BorderThickness = 2;
modernLabel1.BorderRadius = 8;
modernLabel1.BorderStyleCustom = DashStyle.Solid;

modernLabel1.Padding = new Padding(10, 8, 10, 8);
modernLabel1.Opacity = 1f; // 0 to 1
modernLabel1.CornerSmoothing = 1;
modernLabel1.UseAntialiasing = true;

// ??? ?????
modernLabel1.MultipleColors = new[] { Color.Red, Color.Green, Color.Blue };
modernLabel1.MultipleColorsOpacity = 0.3f;
```

### 2. ???? (Text)
```csharp
modernLabel1.Text = "Hello Modern Label";
modernLabel1.Font = new Font("Arial", 14, FontStyle.Bold);
modernLabel1.TextColor = Color.White;
modernLabel1.TextAlign = ContentAlignment.MiddleCenter;
modernLabel1.TextPadding = new Padding(5, 3, 5, 3);
modernLabel1.TextRenderingHint = TextRenderingHint.AntiAlias;
modernLabel1.TextTrimming = StringTrimming.EllipsisCharacter;
modernLabel1.TextFormatFlags = StringFormatFlags.NoWrap;
modernLabel1.WordWrap = false;
modernLabel1.RightToLeft = false;
modernLabel1.UseMnemonic = false;
```

### 3. ?????? ???? (Text Effects)
```csharp
// ????
modernLabel1.EnableTextShadow = true;
modernLabel1.TextShadowColor = Color.Black;
modernLabel1.TextShadowOffset = new Point(2, 2);
modernLabel1.TextShadowBlur = 2f;

// ??????
modernLabel1.EnableTextGlow = true;
modernLabel1.TextGlowColor = Color.Cyan;
modernLabel1.TextGlowRadius = 3f;

// ???? ???????
modernLabel1.EnableTextStroke = true;
modernLabel1.TextOutlineColor = Color.Black;
modernLabel1.TextOutlineThickness = 1.5f;
```

### 4. ??????? (Link / Clickable)
```csharp
modernLabel1.IsClickable = true;
modernLabel1.IsLink = true;
modernLabel1.LinkColor = Color.Blue;
modernLabel1.VisitedLinkColor = Color.Purple;
modernLabel1.HoverLinkColor = Color.LightBlue;
modernLabel1.UnderlineOnHover = true;
modernLabel1.CursorType = Cursors.Hand;
modernLabel1.LinkURL = "https://example.com";
modernLabel1.OpenLinkInBrowser = true;

// ?????
modernLabel1.LinkClicked += (s, e) => MessageBox.Show("?? ????? ??? ??????");
```

### 5. ????????? (Icon / Image)
```csharp
modernLabel1.Icon = Image.FromFile("path/to/icon.png");
modernLabel1.IconSize = new Size(20, 20);
modernLabel1.IconPadding = 5;
modernLabel1.IconAlignment = IconAlignment.Left; // Left, Right, Top, Bottom, Center
modernLabel1.IconTintColor = Color.White;
modernLabel1.IconHoverColor = Color.Cyan;
modernLabel1.IconVisible = true;
```

### 6. ??????? (Badge)
```csharp
modernLabel1.BadgeText = "New";
modernLabel1.BadgeColor = Color.Red;
modernLabel1.BadgeTextColor = Color.White;
modernLabel1.BadgeFont = new Font("Arial", 8);
modernLabel1.BadgePosition = BadgePosition.TopRight;
modernLabel1.BadgePadding = new Padding(4, 2, 4, 2);
modernLabel1.BadgeVisible = true;
```

### 7. ?????? ???????? (Animation)
```csharp
modernLabel1.EnableAnimation = true;

// ????? ?????? ????????
// AnimationType.None, FadeIn, FadeOut, SlideLeft, SlideRight, SlideUp, SlideDown,
// ZoomIn, ZoomOut, Bounce, Pulse, ColorTransition, SizeTransition,
// RotateClockwise, RotateCounterClockwise, Shake, Wave, Flip

modernLabel1.AnimationType = AnimationType.FadeIn;
modernLabel1.AnimationDuration = 500; // milliseconds
modernLabel1.AnimationEasing = AnimationEasing.EaseOutQuad;
modernLabel1.FadeIn = true;
modernLabel1.FadeOut = false;
modernLabel1.HoverAnimation = true;
modernLabel1.ClickAnimation = true;

// ????? ?????? ????????
modernLabel1.AnimationStartColor = Color.White;
modernLabel1.AnimationEndColor = Color.Cyan;
modernLabel1.AnimationColorSequence = new[] { Color.Red, Color.Green, Color.Blue };

// ??? ?????? ????????
modernLabel1.StartAnimation(AnimationType.Bounce);
modernLabel1.StopAnimation();

// ?????
modernLabel1.AnimationCompleted += (s, e) => MessageBox.Show("?????? ?????? ????????");
```

#### ????? ??????? (Easing Types)
- Linear
- EaseInQuad, EaseOutQuad, EaseInOutQuad
- EaseInCubic, EaseOutCubic, EaseInOutCubic
- EaseInQuart, EaseOutQuart, EaseInOutQuart
- EaseInQuint, EaseOutQuint, EaseInOutQuint
- EaseInSine, EaseOutSine, EaseInOutSine
- EaseInExpo, EaseOutExpo, EaseInOutExpo
- EaseInCirc, EaseOutCirc, EaseInOutCirc
- EaseInElastic, EaseOutElastic, EaseInOutElastic
- EaseInBack, EaseOutBack, EaseInOutBack
- EaseInBounce, EaseOutBounce, EaseInOutBounce

### 8. ??????? ???????? (Marquee / Scrolling Text)
```csharp
modernLabel1.EnableMarquee = true;
modernLabel1.MarqueeSpeed = 2;
modernLabel1.MarqueeDirection = MarqueeDirection.LeftToRight; // LeftToRight, RightToLeft, TopToBottom, BottomToTop
modernLabel1.MarqueePauseOnHover = true;
modernLabel1.MarqueeLoop = true;

modernLabel1.StartMarquee();
modernLabel1.StopMarquee();
```

### 9. ??????? (Interaction / State)
```csharp
// ??? ??????? ?????
modernLabel1.HoverBackColor = Color.FromArgb(50, 50, 50);
modernLabel1.HoverTextColor = Color.Cyan;
modernLabel1.HoverBorderColor = Color.Cyan;
modernLabel1.UseHoverEffect = true;
modernLabel1.HoverAnimationDuration = 300;

// ??? ?????
modernLabel1.PressedBackColor = Color.FromArgb(20, 20, 20);

// ??? ???????
modernLabel1.FocusedBorderColor = Color.LimeGreen;
modernLabel1.UseFocusEffect = true;

// ??? ???????
modernLabel1.DisabledBackColor = Color.FromArgb(40, 40, 40);
modernLabel1.DisabledTextColor = Color.Gray;

// ????? ???????
modernLabel1.HoverStart += (s, e) => Console.WriteLine("??? ???????");
modernLabel1.HoverEnd += (s, e) => Console.WriteLine("?????? ???????");
```

### 10. ??????? (Layout)
```csharp
modernLabel1.AutoEllipsis = false;
modernLabel1.MinimumSize = new Size(50, 20);
modernLabel1.MaximumSize = new Size(int.MaxValue, int.MaxValue);
modernLabel1.PreferredSize = Size.Empty;
```

### 11. ??????? ?????? (Accessibility)
```csharp
modernLabel1.AccessibleText = "??? ??????";
modernLabel1.LocalizationKey = "label.key";
modernLabel1.UseRTL = false;
```

### 12. ?????? (Performance)
```csharp
modernLabel1.UseOptimizedDrawing = true;
modernLabel1.UseCachedTextLayout = true;
modernLabel1.InvalidateOnResize = true;
modernLabel1.RedrawOnParentResize = true;
```

### 13. ????? (Advanced)
```csharp
modernLabel1.AllowTextSelection = false;
modernLabel1.CopyOnDoubleClick = false;
modernLabel1.AllowHtml = false;
modernLabel1.AllowMarkdown = false;
modernLabel1.CustomShapePath = null; // GraphicsPath ????
modernLabel1.ClipToShape = false;
modernLabel1.UseCustomRenderer = false;
```

---

## ?? ????? ?????????

### ???? 1: Label ???? ?? ???? ???????
```csharp
ModernLabel lblTitle = new ModernLabel();
lblTitle.Text = "?????? ??";
lblTitle.Font = new Font("Segoe UI", 18, FontStyle.Bold);
lblTitle.TextColor = Color.White;
lblTitle.BackgroundGradientStartColor = Color.FromArgb(45, 85, 200);
lblTitle.BackgroundGradientEndColor = Color.FromArgb(25, 50, 150);
lblTitle.UseGradient = true;
lblTitle.BorderRadius = 10;
lblTitle.BorderColor = Color.Cyan;
lblTitle.BorderThickness = 2;
lblTitle.Padding = new Padding(15, 10, 15, 10);
lblTitle.EnableTextShadow = true;
lblTitle.TextShadowColor = Color.Black;
lblTitle.TextShadowOffset = new Point(2, 2);
this.Controls.Add(lblTitle);
```

### ???? 2: Rlink ????????
```csharp
ModernLabel lblLink = new ModernLabel();
lblLink.Text = "????? ??????";
lblLink.IsLink = true;
lblLink.LinkColor = Color.Blue;
lblLink.HoverLinkColor = Color.LightBlue;
lblLink.UnderlineOnHover = true;
lblLink.LinkURL = "https://example.com";
lblLink.OpenLinkInBrowser = true;
lblLink.Cursor = Cursors.Hand;
this.Controls.Add(lblLink);
```

### ???? 3: Label ?? ???? ???????
```csharp
ModernLabel lblNotification = new ModernLabel();
lblNotification.Text = "???????";
lblNotification.Icon = Image.FromFile("notification.png");
lblNotification.IconSize = new Size(20, 20);
lblNotification.IconAlignment = IconAlignment.Left;
lblNotification.BadgeText = "5";
lblNotification.BadgeColor = Color.Red;
lblNotification.BadgePosition = BadgePosition.TopRight;
lblNotification.BadgeVisible = true;
this.Controls.Add(lblNotification);
```

### ???? 4: Label ?? ???? ??????
```csharp
ModernLabel lblAnimated = new ModernLabel();
lblAnimated.Text = "?? ?????";
lblAnimated.EnableAnimation = true;
lblAnimated.AnimationType = AnimationType.Bounce;
lblAnimated.AnimationDuration = 1000;
lblAnimated.AnimationEasing = AnimationEasing.EaseOutBounce;
lblAnimated.HoverAnimation = true;
lblAnimated.AnimationCompleted += (s, e) => lblAnimated.StartAnimation();
this.Controls.Add(lblAnimated);
lblAnimated.StartAnimation();
```

### ???? 5: Marquee Label
```csharp
ModernLabel lblMarquee = new ModernLabel();
lblMarquee.Text = "??? ?? ????? ?? ?????? ??? ??????... ";
lblMarquee.EnableMarquee = true;
lblMarquee.MarqueeSpeed = 3;
lblMarquee.MarqueeDirection = MarqueeDirection.LeftToRight;
lblMarquee.MarqueePauseOnHover = true;
lblMarquee.MarqueeLoop = true;
this.Controls.Add(lblMarquee);
lblMarquee.StartMarquee();
```

### ???? 6: ???? ?????? ?????
```csharp
ModernLabel lblColorAnim = new ModernLabel();
lblColorAnim.Text = "????? ??????";
lblColorAnim.TextColor = Color.White;
lblColorAnim.BackgroundColor = Color.FromArgb(30, 30, 30);
lblColorAnim.PlayColorAnimation(Color.Red, Color.Cyan, 2000);
lblColorAnim.AnimationCompleted += (s, e) => 
{
    lblColorAnim.PlayColorAnimation(Color.Cyan, Color.Red, 2000);
};
this.Controls.Add(lblColorAnim);
```

### ???? 7: ????? ???????
```csharp
ModernLabel lblMultiColor = new ModernLabel();
lblMultiColor.Text = "?? ????";
lblMultiColor.MultipleColors = new[] 
{ 
    Color.Red, 
    Color.Orange, 
    Color.Yellow, 
    Color.Green, 
    Color.Blue, 
    Color.Purple 
};
lblMultiColor.MultipleColorsOpacity = 0.2f;
this.Controls.Add(lblMultiColor);
```

---

## ?? ?????? ???????? ????????

### ????? ???? ?????? ???????
```csharp
private void RunSequenceAnimation(ModernLabel label)
{
    AnimationType[] animations = new[]
    {
        AnimationType.FadeIn,
        AnimationType.Bounce,
        AnimationType.ZoomIn,
        AnimationType.Shake
    };

    int index = 0;

    label.AnimationCompleted += (s, e) =>
    {
        index++;
        if (index < animations.Length)
        {
            label.StartAnimation(animations[index]);
        }
        else
        {
            index = 0;
            label.StartAnimation(animations[index]);
        }
    };

    label.StartAnimation(animations[0]);
}
```

---

## ?? ???? ???????

| ????? | ??????? | ????? | ?????? ?????????? |
|-------|---------|-------|------------------|
| Appearance | BackgroundColor | Color | FromArgb(30, 30, 30) |
| Appearance | BorderColor | Color | FromArgb(100, 180, 255) |
| Appearance | BorderRadius | int | 8 |
| Text | TextColor | Color | White |
| Text | TextAlign | ContentAlignment | MiddleCenter |
| Text | Font | Font | Arial, 10 |
| TextEffects | EnableTextShadow | bool | false |
| TextEffects | EnableTextGlow | bool | false |
| Animation | EnableAnimation | bool | false |
| Animation | AnimationDuration | int | 500 |
| Marquee | EnableMarquee | bool | false |
| Marquee | MarqueeSpeed | int | 2 |
| Interaction | UseHoverEffect | bool | true |
| Badge | BadgeVisible | bool | false |
| Badge | BadgePosition | BadgePosition | TopRight |

---

## ?? ????? ??????

1. **????? ??????? ??????**: ?????? `UseOptimizedDrawing = true` ??? Labels ???????
2. **???? ?????? ???????? ????????**: ?? ???? ???? ?????? ????? ?? ??? ?????
3. **?????? AntiAliasing ????**: ?? ???? ??? ?????? ?? ?????? ???????
4. **????? ????????**: ?????? `Opacity = 1` ??? ??? ?????? ????????

---

## ?? ??????? ???????

**???????**: ???? ??? ????
**????**: ?????? `TextRenderingHint = TextRenderingHint.AntiAlias`

**???????**: ?????? ???????? ?????
**????**: ??? ?? `AnimationDuration` ?? ?????? `UseOptimizedDrawing = true`

**???????**: ?????? ??? ?????
**????**: ???? ?? `BadgeVisible = true` ? `BadgeText` ??? ??????

---

?? ????? `ModernLabel` ?????! ?????? ???????! ??
