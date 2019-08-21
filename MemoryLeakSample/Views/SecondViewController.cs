using System;
using Foundation;
using UIKit;

namespace MemoryLeakSample.Views
{
    [Register("SecondViewController")]
    public partial class SecondViewController : UIViewController
    {
        int count = Counter.Default.Count;

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            InitializeUI();

            disiplayAlertButton.TouchUpInside += DisiplayAlertButton_TouchUpInside;
            dismissViewButton.TouchUpInside += DismissViewButton_TouchUpInside;
        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);

            System.Diagnostics.Debug.WriteLine($"Disposed SecondViewController {count}");

            GC.Collect();
            GC.WaitForPendingFinalizers();
            GC.Collect();
        }

        ~SecondViewController()
        {
            GC.Collect();
            GC.WaitForPendingFinalizers();
            GC.Collect();
            System.Diagnostics.Debug.WriteLine("Finalized SecondViewController");
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
                GC.Collect();
                GC.WaitForPendingFinalizers();
                GC.Collect();
                System.Diagnostics.Debug.WriteLine("---Close SecondView------------------------------");

            });

        void DisiplayAlertButton_TouchUpInside(object sender, EventArgs e)
            => PresentAlert("Alert");

        void DismissViewButton_TouchUpInside(object sender, EventArgs e)
            => DismissViewController(true, () =>
            {
                GC.Collect();
                GC.WaitForPendingFinalizers();
                GC.Collect();
                System.Diagnostics.Debug.WriteLine("---Close SecondView------------------------------");
            });

        void PresentAlert(string message)
        {
            var alertController = UIAlertController.Create(string.Empty, message, UIAlertControllerStyle.Alert);
            alertController.AddAction(UIAlertAction.Create("Close", UIAlertActionStyle.Cancel, null));
            PresentViewController(alertController, true, null);
        }

    }
}

