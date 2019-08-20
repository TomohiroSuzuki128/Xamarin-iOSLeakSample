using System;
using UIKit;

namespace MemoryNotLeakSample.Views
{
    public class DisiplayAlertButton : UIButton
    {
        public DisiplayAlertButton()
        {
            System.Diagnostics.Debug.WriteLine("Created DisiplayAlertButton ctor.");
        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);

            System.Diagnostics.Debug.WriteLine("Disposed DisiplayAlertButton dispose.");
        }

        public DisiplayAlertButton(UIButtonType type) : base(type) { }

        ~DisiplayAlertButton()
        {
            System.Diagnostics.Debug.WriteLine("Finalized DisiplayAlertButton finalizer.");
        }
    }
}
