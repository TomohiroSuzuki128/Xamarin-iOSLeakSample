using UIKit;

namespace MemoryLeakSample.Views
{
    public partial class MainViewController : UIViewController
    {

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            InitializeUI();

            button.TouchUpInside += (s, e) => PresentAlert("Alert");

            //button.AddTarget(this, new ObjCRuntime.Selector("buttonEvent:"), UIControlEvent.TouchUpInside);
        }

        //[Export("buttonEvent:")]
        //void ButtonEvent(NSObject sender)
        //{
        //    PresentAlert("Alert");
        //}

        void PresentAlert(string message)
        {
            var alertController = UIAlertController.Create(string.Empty, message, UIAlertControllerStyle.Alert);
            alertController.AddAction(UIAlertAction.Create("Close", UIAlertActionStyle.Cancel, null));
            PresentViewController(alertController, true, null);
        }

    }
}

