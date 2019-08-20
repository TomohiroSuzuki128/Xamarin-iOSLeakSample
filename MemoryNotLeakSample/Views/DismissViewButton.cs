using System;
using UIKit;

namespace MemoryNotLeakSample.Views
{
    public class DismissViewButton : UIButton
    {
        public DismissViewButton()
        {
            System.Diagnostics.Debug.WriteLine("Created DismissViewButton ctor.");
        }

        public DismissViewButton(UIButtonType type) : base(type) { }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);

            System.Diagnostics.Debug.WriteLine("Disposed DismissViewButton dispose.");
        }

        ~DismissViewButton()
        {
            System.Diagnostics.Debug.WriteLine("Finalized DismissViewButton finalizer.");
        }
    }
}
