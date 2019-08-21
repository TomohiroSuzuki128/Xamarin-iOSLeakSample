using System;

namespace MemoryNotLeakSample
{
    public class Counter
    {
        public static Counter Default { get; } = new Counter();

        int count = 0;
        public int Count { get => count; }

        private Counter()
        {
        }

        public void CountUp() => count++;
    }
}
