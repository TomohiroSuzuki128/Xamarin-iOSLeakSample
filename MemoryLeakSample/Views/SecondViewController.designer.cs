using System;
using CoreGraphics;
using UIKit;

namespace MemoryLeakSample.Views
{
    public partial class SecondViewController
    {
        static readonly nfloat fontSize = 20f;

        void InitializeUI()
        {
            View.ContentMode = UIViewContentMode.ScaleToFill;
            View.LayoutMargins = new UIEdgeInsets(0, 16, 0, 16);
            View.Frame = new CGRect(0, 0, 375, 667);
            View.BackgroundColor = UIColor.FromRGB(224, 255, 224);
            View.AutoresizingMask = UIViewAutoresizing.FlexibleWidth
                                    | UIViewAutoresizing.FlexibleHeight;

            var disiplayAlertButton = new DisiplayAlertButton()
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

            disiplayAlertButton.SetTitle("Disiplay alert", UIControlState.Normal);
            disiplayAlertButton.SetTitleColor(UIColor.Blue, UIControlState.Normal);

            //disiplayAlertButton.TouchUpInside += DisiplayAlertButton_TouchUpInside;
            disiplayAlertButton.AddTarget(this, new ObjCRuntime.Selector("disiplayAlertButtonEvent:"), UIControlEvent.TouchUpInside);


            View.AddSubview(disiplayAlertButton);

            disiplayAlertButton.HeightAnchor.ConstraintEqualTo(40f).Active = true;
            disiplayAlertButton.CenterXAnchor.ConstraintEqualTo(View.CenterXAnchor).Active = true;
            disiplayAlertButton.CenterYAnchor.ConstraintEqualTo(View.CenterYAnchor, -40).Active = true;

            disiplayAlertButton.LeftAnchor.ConstraintEqualTo(View.LayoutMarginsGuide.LeftAnchor).Active = true;
            disiplayAlertButton.RightAnchor.ConstraintEqualTo(View.LayoutMarginsGuide.RightAnchor).Active = true;

            var dismissViewButton = new DismissViewButton()
            {
                Frame = new CGRect(0, 0, 375, 20),
                Opaque = false,
                ContentMode = UIViewContentMode.ScaleToFill,
                HorizontalAlignment = UIControlContentHorizontalAlignment.Center,
                VerticalAlignment = UIControlContentVerticalAlignment.Center,
                LineBreakMode = UILineBreakMode.MiddleTruncation,
                TranslatesAutoresizingMaskIntoConstraints = false,
                Font = UIFont.SystemFontOfSize(fontSize),
                AccessibilityIdentifier = "dismissViewButton",
            };

            dismissViewButton.SetTitle("Close", UIControlState.Normal);
            dismissViewButton.SetTitleColor(UIColor.Blue, UIControlState.Normal);

            //dismissViewButton.TouchUpInside += DismissViewButton_TouchUpInside;
            dismissViewButton.AddTarget(this, new ObjCRuntime.Selector("dismissViewButtonEvent:"), UIControlEvent.TouchUpInside);

            View.AddSubview(dismissViewButton);

            dismissViewButton.HeightAnchor.ConstraintEqualTo(40f).Active = true;
            dismissViewButton.CenterXAnchor.ConstraintEqualTo(View.CenterXAnchor).Active = true;
            dismissViewButton.CenterYAnchor.ConstraintEqualTo(View.CenterYAnchor, 40).Active = true;

            dismissViewButton.LeftAnchor.ConstraintEqualTo(View.LayoutMarginsGuide.LeftAnchor).Active = true;
            dismissViewButton.RightAnchor.ConstraintEqualTo(View.LayoutMarginsGuide.RightAnchor).Active = true;

        }
    }
}
