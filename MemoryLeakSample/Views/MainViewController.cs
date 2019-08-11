using System;
using System.Collections.Generic;
using System.Linq;
using CoreGraphics;
using Foundation;
using UIKit;

namespace MemoryLeakSample.Views
{
    public partial class MainViewController : UIViewController
    {

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            InitializeUI();

            //searchFromZipcodeButton.AddTarget(this, new ObjCRuntime.Selector("zipCodeEvent:"), UIControlEvent.TouchUpInside);
        }

    }
}

