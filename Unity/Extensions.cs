using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Kinect.ReactiveV2
{
    public static class Extensions
    {
        public static void ForEach<T>(
            this IEnumerable<T> source,
            Action<T> action)
        {
            foreach (T element in source)
                action(element);
        }
    }
}
