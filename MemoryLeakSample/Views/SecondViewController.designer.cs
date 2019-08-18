using System;
using CoreGraphics;
using UIKit;

namespace MemoryLeakSample.Views
{
    public partial class SecondViewController
    {
        static readonly nfloat fontSize = 20f;

        [Weak]
        UIButton disiplayAlertButton;

        [Weak]
        UIButton dismissViewButton;

        [Weak]
        NSLayoutConstraint disiplayAlertButtonHeightAnchor;

        [Weak]
        NSLayoutConstraint disiplayAlertButtonCenterXAnchor;

        [Weak]
        NSLayoutConstraint disiplayAlertButtonCenterYAnchor;

        [Weak]
        NSLayoutConstraint disiplayAlertButtonLeftAnchor;

        [Weak]
        NSLayoutConstraint disiplayAlertButtonRightAnchor;

        void InitializeUI()
        {
            View.ContentMode = UIViewContentMode.ScaleToFill;
            View.LayoutMargins = new UIEdgeInsets(0, 16, 0, 16);
            View.Frame = new CGRect(0, 0, 375, 667);
            View.BackgroundColor = UIColor.FromRGB(224, 255, 224);
            View.AutoresizingMask = UIViewAutoresizing.FlexibleWidth
                                    | UIViewAutoresizing.FlexibleHeight;

            disiplayAlertButton = new DisiplayAlertButton()
            {
                Frame = new CGRect(0, 0, 375, 20),
                Opaque = false,
                ContentMode = UIViewContentMode.ScaleToFill,
                HorizontalAlignment = UIControlContentHorizontalAlignment.Center,
                VerticalAlignment = UIControlContentVerticalAlignment.Center,
                LineBreakMode = UILineBreakMode.MiddleTruncation,
                TranslatesAutoresizingMaskIntoConstraints = false,
                Font = UIFont.SystemFontOfSize(fontSize),
                //AccessibilityIdentifier = "button",
            };

            disiplayAlertButton.SetTitle("Disiplay alert", UIControlState.Normal);
            disiplayAlertButton.SetTitleColor(UIColor.Blue, UIControlState.Normal);
            View.AddSubview(disiplayAlertButton);

            disiplayAlertButtonHeightAnchor = disiplayAlertButton.HeightAnchor.ConstraintEqualTo(40f);
            disiplayAlertButtonCenterXAnchor = disiplayAlertButton.CenterXAnchor.ConstraintEqualTo(View.CenterXAnchor);
            disiplayAlertButtonCenterYAnchor = disiplayAlertButton.CenterYAnchor.ConstraintEqualTo(View.CenterYAnchor, -40);

            disiplayAlertButtonLeftAnchor = disiplayAlertButton.LeftAnchor.ConstraintEqualTo(View.LayoutMarginsGuide.LeftAnchor);
            disiplayAlertButtonRightAnchor = disiplayAlertButton.RightAnchor.ConstraintEqualTo(View.LayoutMarginsGuide.RightAnchor);

            disiplayAlertButtonHeightAnchor.Active = true;
            disiplayAlertButtonCenterXAnchor.Active = true;
            disiplayAlertButtonCenterYAnchor.Active = true;

            disiplayAlertButtonLeftAnchor.Active = true;
            disiplayAlertButtonRightAnchor.Active = true;

            dismissViewButton = new DismissViewButton()
            {
                Frame = new CGRect(0, 0, 375, 20),
                Opaque = false,
                ContentMode = UIViewContentMode.ScaleToFill,
                HorizontalAlignment = UIControlContentHorizontalAlignment.Center,
                VerticalAlignment = UIControlContentVerticalAlignment.Center,
                LineBreakMode = UILineBreakMode.MiddleTruncation,
                TranslatesAutoresizingMaskIntoConstraints = false,
                Font = UIFont.SystemFontOfSize(fontSize),
                //AccessibilityIdentifier = "dismissViewButton",
            };

            dismissViewButton.SetTitle("Close", UIControlState.Normal);
            dismissViewButton.SetTitleColor(UIColor.Blue, UIControlState.Normal);
            View.AddSubview(dismissViewButton);

            dismissViewButton.HeightAnchor.ConstraintEqualTo(40f).Active = true;
            dismissViewButton.CenterXAnchor.ConstraintEqualTo(View.CenterXAnchor).Active = true;
            dismissViewButton.CenterYAnchor.ConstraintEqualTo(View.CenterYAnchor, 40).Active = true;

            dismissViewButton.LeftAnchor.ConstraintEqualTo(View.LayoutMarginsGuide.LeftAnchor).Active = true;
            dismissViewButton.RightAnchor.ConstraintEqualTo(View.LayoutMarginsGuide.RightAnchor).Active = true;

        }
    }
}
