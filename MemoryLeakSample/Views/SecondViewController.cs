using System;
using Foundation;
using UIKit;

namespace MemoryLeakSample.Views
{
    public partial class SecondViewController : UIViewController
    {
        UIAlertController alertController;

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            InitializeUI();

            //disiplayAlertButton.TouchUpInside += DisiplayAlertButton_TouchUpInside;
            dismissViewButton.TouchUpInside += DismissViewButton_TouchUpInside;

            //disiplayAlertButton.AddTarget(this, new ObjCRuntime.Selector("disiplayAlertButtonEvent:"), UIControlEvent.TouchUpInside);
            //dismissViewButton.AddTarget(this, new ObjCRuntime.Selector("dismissViewButtonEvent:"), UIControlEvent.TouchUpInside);
        }

        public override void ViewDidDisappear(bool animated)
        {
            base.ViewDidDisappear(animated);

            //disiplayAlertButton.TouchUpInside -= DisiplayAlertButton_TouchUpInside;
            dismissViewButton.TouchUpInside -= DismissViewButton_TouchUpInside;

            //disiplayAlertButton.RemoveTarget(this, new ObjCRuntime.Selector("disiplayAlertButtonEvent:"), UIControlEvent.TouchUpInside);
            //dismissViewButton.RemoveTarget(this, new ObjCRuntime.Selector("dismissViewButtonEvent:"), UIControlEvent.TouchUpInside);

            disiplayAlertButtonHeightAnchor.Active = false;
            disiplayAlertButtonCenterXAnchor.Active = false;
            disiplayAlertButtonCenterYAnchor.Active = false;

            disiplayAlertButtonLeftAnchor.Active = false;
            disiplayAlertButtonRightAnchor.Active = false;

            disiplayAlertButton?.RemoveFromSuperview();
            dismissViewButton?.RemoveFromSuperview();

            disiplayAlertButton?.Dispose();
            dismissViewButton?.Dispose();

            disiplayAlertButton = null;
            dismissViewButton = null;
        }

        //[Export("disiplayAlertButtonEvent:")]
        //void DisiplayAlertButtonEvent(NSObject sender)
        //    => PresentAlert("Alert");

        //[Export("dismissViewButtonEvent:")]
        //void DismissViewButtonEvent(NSObject sender)
        //    => DismissViewController(true, null);

        //void DisiplayAlertButton_TouchUpInside(object sender, EventArgs e)
        //    => PresentAlert("Alert");

        void DismissViewButton_TouchUpInside(object sender, EventArgs e)
            => DismissViewController(true, () =>
            {
                GC.Collect();
                GC.WaitForPendingFinalizers();
            });

        //void PresentAlert(string message)
        //{
        //    alertController = UIAlertController.Create(string.Empty, message, UIAlertControllerStyle.Alert);
        //    alertController.AddAction(UIAlertAction.Create("Close", UIAlertActionStyle.Cancel, null));
        //    PresentViewController(alertController, true, null);
        //}

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);

            disiplayAlertButton = null;
            dismissViewButton = null;
        }

    }
}

