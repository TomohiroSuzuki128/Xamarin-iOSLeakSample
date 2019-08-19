using System;
using CoreGraphics;
using UIKit;

namespace MemoryLeakSample.Views
{
    public partial class FirstViewController
    {
        static readonly nfloat fontSize = 20f;

        UIButton nextViewButton;

        void InitializeUI()
        {
            View.ContentMode = UIViewContentMode.ScaleToFill;
            View.LayoutMargins = new UIEdgeInsets(0, 16, 0, 16);
            View.Frame = new CGRect(0, 0, 375, 667);
            View.BackgroundColor = UIColor.White;
            View.AutoresizingMask = UIViewAutoresizing.FlexibleWidth
                                    | UIViewAutoresizing.FlexibleHeight;

            nextViewButton = new UIButton(UIButtonType.RoundedRect)
            {
                Frame = new CGRect(0, 0, 375, 20),
                Opaque = false,
                ContentMode = UIViewContentMode.ScaleToFill,
                HorizontalAlignment = UIControlContentHorizontalAlignment.Center,
                VerticalAlignment = UIControlContentVerticalAlignment.Center,
                LineBreakMode = UILineBreakMode.MiddleTruncation,
                TranslatesAutoresizingMaskIntoConstraints = false,
                Font = UIFont.SystemFontOfSize(fontSize),
                AccessibilityIdentifier = "nextViewButton",
            };

            nextViewButton.SetTitle("Next View", UIControlState.Normal);
            View.AddSubview(nextViewButton);

            nextViewButton.HeightAnchor.ConstraintEqualTo(40f).Active = true;
            nextViewButton.CenterXAnchor.ConstraintEqualTo(View.CenterXAnchor).Active = true;
            nextViewButton.CenterYAnchor.ConstraintEqualTo(View.CenterYAnchor).Active = true;

            nextViewButton.LeftAnchor.ConstraintEqualTo(View.LayoutMarginsGuide.LeftAnchor).Active = true;
            nextViewButton.RightAnchor.ConstraintEqualTo(View.LayoutMarginsGuide.RightAnchor).Active = true;
        }
    }
}
