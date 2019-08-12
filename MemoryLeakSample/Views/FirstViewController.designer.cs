using System;
using CoreGraphics;
using UIKit;

namespace MemoryLeakSample.Views
{
    public partial class MainViewController
    {
        static readonly nfloat fontSize = 20f;

        UIButton button;

        void InitializeUI()
        {
            View.ContentMode = UIViewContentMode.ScaleToFill;
            View.LayoutMargins = new UIEdgeInsets(0, 16, 0, 16);
            View.Frame = new CGRect(0, 0, 375, 667);
            View.BackgroundColor = UIColor.White;
            View.AutoresizingMask = UIViewAutoresizing.FlexibleWidth
                                    | UIViewAutoresizing.FlexibleHeight;

            button = new UIButton(UIButtonType.RoundedRect)
            {
                Frame = new CGRect(0, 0, 375, 20),
                Opaque = false,
                ContentMode = UIViewContentMode.ScaleToFill,
                HorizontalAlignment = UIControlContentHorizontalAlignment.Center,
                VerticalAlignment = UIControlContentVerticalAlignment.Center,
                LineBreakMode = UILineBreakMode.MiddleTruncation,
                TranslatesAutoresizingMaskIntoConstraints = false,
                Font = UIFont.SystemFontOfSize(fontSize),
                AccessibilityIdentifier = "button",
            };

            button.SetTitle("アラート表示", UIControlState.Normal);
            View.AddSubview(button);

            button.HeightAnchor.ConstraintEqualTo(40f).Active = true;
            button.CenterXAnchor.ConstraintEqualTo(View.CenterXAnchor).Active = true;
            button.CenterYAnchor.ConstraintEqualTo(View.CenterYAnchor).Active = true;

            button.LeftAnchor.ConstraintEqualTo(View.LayoutMarginsGuide.LeftAnchor).Active = true;
            button.RightAnchor.ConstraintEqualTo(View.LayoutMarginsGuide.RightAnchor).Active = true;
        }
    }
}
