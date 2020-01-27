using System;
using Foundation;
using UIKit;

namespace MemoryNotLeakSample.Views
{
    [Register("SecondViewController")]
    public partial class SecondViewController : UIViewController
    {
        int count = Counter.Default.Count;

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            InitializeUI();
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
            System.Diagnostics.Debug.WriteLine($"Finalized SecondViewController {count}");
        }

        [Export("disiplayAlertButtonEvent:")]
        void DisiplayAlertButtonEvent(NSObject sender)
            => PresentAlert("Alert");

        [Export("dismissViewButtonEvent:")]
        void DismissViewButtonEvent(NSObject sender)
            => DismissViewController(true, () =>
            {
                dismissViewButton?.RemoveFromSuperview();
                disiplayAlertButton?.RemoveFromSuperview();
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
                //dismissViewButton.TouchUpInside -= DismissViewButton_TouchUpInside;
                //disiplayAlertButton.TouchUpInside -= DisiplayAlertButton_TouchUpInside;
                dismissViewButton?.RemoveFromSuperview();
                disiplayAlertButton?.RemoveFromSuperview();
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
