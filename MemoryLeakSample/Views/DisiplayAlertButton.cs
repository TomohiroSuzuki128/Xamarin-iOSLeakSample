using System;
using UIKit;

namespace MemoryLeakSample.Views
{
    public class DisiplayAlertButton : UIButton
    {
        public DisiplayAlertButton()
        {
            System.Diagnostics.Debug.WriteLine("Created DisiplayAlertButton");
        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);

            System.Diagnostics.Debug.WriteLine("Disposed DisiplayAlertButton .");
        }

        public DisiplayAlertButton(UIButtonType type) : base(type) { }

        ~DisiplayAlertButton()
        {
            System.Diagnostics.Debug.WriteLine("Finalized DisiplayAlertButton");
        }
    }
}
