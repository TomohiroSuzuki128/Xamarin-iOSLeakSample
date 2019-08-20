using System;
using Foundation;
using UIKit;

namespace MemoryNotLeakSample.Views
{
    [Register("FirstViewController")]
    public partial class FirstViewController : UIViewController
    {
        UIViewController secondViewController;

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            InitializeUI();

            nextViewButton.AddTarget(this, new ObjCRuntime.Selector("nextViewButtonEvent"), UIControlEvent.TouchUpInside);
        }

        [Export("nextViewButtonEvent")]
        void NextViewButtonEvent()
        {
            secondViewController = new SecondViewController();
            PresentViewController(secondViewController, true, null);
        }

        //[Export("NextViewClosedEvent:")]
        //public void NextViewClosedEvent()
        //{
        //    secondViewController.Dispose();
        //    secondViewController = null;
        //}

    }
}

