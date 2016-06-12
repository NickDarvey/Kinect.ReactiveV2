using Microsoft.Kinect.VisualGestureBuilder;
using System;
using System.Collections.Generic;
using System.Linq;
using UniRx;
using Windows.Kinect;

namespace Kinect.ReactiveV2
{
    public static class GesturesKinectSensorExtensions
    {

        /// <summary>
        /// Converts the VisualGestureBuilderFrameArrived event to an observable sequence.
        /// </summary>
        /// <param name="kinectSensor">The kinect sensor.</param>
        /// <param name="kinectSensor">The reader to be used to subscribe to the VisualGestureBuilderFrameArrived event.</param>
        /// <returns>The observable sequence.</returns>
        public static IObservable<VisualGestureBuilderFrameArrivedEventArgs> VisualGestureBuilderFrameArrivedObservable(this KinectSensor kinectSensor, VisualGestureBuilderFrameReader reader)
        {
            if (kinectSensor == null) throw new ArgumentNullException("kinectSensor");

            return Observable.FromEventPattern<EventHandler<VisualGestureBuilderFrameArrivedEventArgs>, VisualGestureBuilderFrameArrivedEventArgs>(
                h => h.Invoke, h => reader.FrameArrived += h, h => reader.FrameArrived -= h)
                .Select(e => e.EventArgs);
        }
    }
}