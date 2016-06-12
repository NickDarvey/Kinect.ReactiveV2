using UniRx;
using Windows.Kinect;

using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Kinect.VisualGestureBuilder;

namespace Kinect.ReactiveV2
{
    public static class VisualGestureBuilderObservableExtensions
    {
        /// <summary>
        /// Selects the gestures from the gesture stream.
        /// </summary>
        /// <param name="source">The source observable.</param>
        /// <param name="gestures">The gestures object. If it's null it'll be initialized.</param>
        /// <returns>An observable sequence of bodies.</returns>
        public static IObservable<GestureResults> SelectGestures(this IObservable<VisualGestureBuilderFrameArrivedEventArgs> source, GestureResults results)
        {
            if (source == null) throw new ArgumentNullException("source");

            return source.Select(_ =>
            {
                using (var frame = _.FrameReference.AcquireFrame())
                {
                    if (frame == null) return new GestureResults();
                    if (results == null) results = new GestureResults();

                    results.Discrete = frame.DiscreteGestureResults;
                    results.Continuous = frame.ContinuousGestureResults;

                    return results;
                }
            });
        }
    }
}