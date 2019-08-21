using System;
using UIKit;

namespace MemoryNotLeakSample.Views
{
    public class DismissViewButton : UIButton
    {
        int count = Counter.Default.Count;

        public DismissViewButton()
        {
            System.Diagnostics.Debug.WriteLine($"Created DismissViewButton {count}");
        }

        public DismissViewButton(UIButtonType type) : base(type) { }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);

            System.Diagnostics.Debug.WriteLine($"Disposed DismissViewButton {count}");
        }

        ~DismissViewButton()
        {
            System.Diagnostics.Debug.WriteLine($"Finalized DismissViewButton {count}");
        }
    }
}
