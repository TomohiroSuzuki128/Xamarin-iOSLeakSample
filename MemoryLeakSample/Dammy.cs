using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Foundation;
using UIKit;

namespace MemoryLeakSample
{
    public class DammyViewController : UIViewController
    {
        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            var dismissViewButton = new UIButton();
            dismissViewButton.TouchUpInside += DismissViewButton_TouchUpInside;
        }

        void DismissViewButton_TouchUpInside(object sender, EventArgs e)
            => DismissViewController(true, null);

    }
}