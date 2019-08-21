using System;
using Foundation;
using UIKit;

namespace MemoryNotLeakSample.Views
{
    [Register("FirstViewController")]
    public partial class FirstViewController : UIViewController
    {
        [Weak] UIViewController secondViewController;

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            InitializeUI();

            nextViewButton.AddTarget(this, new ObjCRuntime.Selector("nextViewButtonEvent"), UIControlEvent.TouchUpInside);
        }

        [Export("nextViewButtonEvent")]
        void NextViewButtonEvent()
        {
            System.Diagnostics.Debug.WriteLine("---------------------------------");
            secondViewController = new SecondViewController();
            PresentViewController(secondViewController, true, null);
            Counter.Default.CountUp();
            System.Diagnostics.Debug.WriteLine("---Open SecondView------------------------------");
        }

        //[Export("NextViewClosedEvent:")]
        //public void NextViewClosedEvent()
        //{
        //    secondViewController.Dispose();
        //    secondViewController = null;
        //}

    }
}

