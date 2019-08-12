using Foundation;
using UIKit;

namespace MemoryLeakSample.Views
{
    public partial class FirstViewController : UIViewController
    {

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            InitializeUI();

            nextViewButton.AddTarget(this, new ObjCRuntime.Selector("nextViewButtonEvent:"), UIControlEvent.TouchUpInside);
        }

        [Export("nextViewButtonEvent:")]
        void NextViewButtonEvent(NSObject sender)
        {
            PresentViewController(new SecondViewController(), true, null);
        }

    }
}

