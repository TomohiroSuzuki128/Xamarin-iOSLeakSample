using System;
using UIKit;

namespace MemoryLeakSample.Views
{
    public class DismissViewButton : UIButton
    {
        public DismissViewButton()
        {
            System.Diagnostics.Debug.WriteLine("Created DismissViewButton");
        }

        public DismissViewButton(UIButtonType type) : base(type) { }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);

            System.Diagnostics.Debug.WriteLine("Disposed DismissViewButton");
        }

        ~DismissViewButton()
        {
            System.Diagnostics.Debug.WriteLine("Finalized DismissViewButton");
        }
    }
}
