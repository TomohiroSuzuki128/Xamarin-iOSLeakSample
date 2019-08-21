using System;
using UIKit;

namespace MemoryNotLeakSample.Views
{
    public class DisiplayAlertButton : UIButton
    {
        int count = Counter.Default.Count;

        public DisiplayAlertButton()
        {
            System.Diagnostics.Debug.WriteLine($"Created DisiplayAlertButton {count}");
        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);

            System.Diagnostics.Debug.WriteLine($"Disposed DisiplayAlertButton {count}");
        }

        public DisiplayAlertButton(UIButtonType type) : base(type) { }

        ~DisiplayAlertButton()
        {
            System.Diagnostics.Debug.WriteLine($"Finalized DisiplayAlertButton {count}");
        }
    }
}
