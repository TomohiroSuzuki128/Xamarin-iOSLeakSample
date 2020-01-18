using System;
using DeepDive05;
using UIKit;

namespace DeepDive05.Views
{
    public class MyButton : UIButton
    {
        int count = Counter.Default.Count;

        public string Id { get; set; }

        public MyButton()
        {
            System.Diagnostics.Debug.WriteLine($"Created MyButton {count}");
        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);

            System.Diagnostics.Debug.WriteLine($"Disposed MyButton {count}");
        }

        public MyButton(UIButtonType type) : base(type) { }

        ~MyButton()
        {
            System.Diagnostics.Debug.WriteLine($"Finalized MyButton {count}");
        }
    }
}
