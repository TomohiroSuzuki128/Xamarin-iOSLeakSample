using System;
using Foundation;
using UIKit;

namespace MemoryLeakSample.Views
{
    [Register("SecondViewController")]
    public partial class SecondViewController : UIViewController
    {
        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            InitializeUI();
        }

        ~SecondViewController()
        {
            System.Diagnostics.Debug.WriteLine("call SecondViewController finalizer.");
        }

        public override void ViewDidDisappear(bool animated)
        {
            base.ViewDidDisappear(animated);
        }

        [Export("disiplayAlertButtonEvent:")]
        void DisiplayAlertButtonEvent(NSObject sender)
            => PresentAlert("Alert");

        [Export("dismissViewButtonEvent:")]
        void DismissViewButtonEvent(NSObject sender)
            => DismissViewController(true, () =>
            {
                var dismissViewButton = sender as DismissViewButton;
                dismissViewButton.TouchUpInside -= DismissViewButton_TouchUpInside;
                dismissViewButton.RemoveFromSuperview();
                GC.Collect();
                GC.WaitForPendingFinalizers();
            });

        void DisiplayAlertButton_TouchUpInside(object sender, EventArgs e)
            => PresentAlert("Alert");

        void DismissViewButton_TouchUpInside(object sender, EventArgs e)
            => DismissViewController(true, () =>
            {
                var dismissViewButton = sender as DismissViewButton;
                dismissViewButton.TouchUpInside -= DismissViewButton_TouchUpInside;
                dismissViewButton.RemoveFromSuperview();
                GC.Collect();
                GC.WaitForPendingFinalizers();
            });

        void PresentAlert(string message)
        {
            var alertController = UIAlertController.Create(string.Empty, message, UIAlertControllerStyle.Alert);
            alertController.AddAction(UIAlertAction.Create("Close", UIAlertActionStyle.Cancel, null));
            PresentViewController(alertController, true, null);
        }

    }
}

