using System;
using Foundation;
using UIKit;

namespace DeepDive05.Views
{
    [Register("SecondViewController")]
    public partial class SecondViewController : UIViewController
    {
        int count = Counter.Default.Count;

        UIButton button;

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            InitializeUI();

            button = new MyButton();
            View.AddSubview(button);

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

            button?.RemoveFromSuperview();

            button?.Dispose();
        }

        [Export("dismissViewButtonEvent:")]
        void DismissViewButtonEvent(NSObject sender)
            => DismissViewController(true, () =>
            {
                dismissViewButton?.RemoveFromSuperview();
                GC.Collect();
                GC.WaitForPendingFinalizers();
                GC.Collect();
                System.Diagnostics.Debug.WriteLine("---Close SecondView------------------------------");
            });

    }
}

