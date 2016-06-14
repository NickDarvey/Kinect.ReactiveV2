using Microsoft.Kinect.Face;
using System;
using UniRx;

namespace Kinect.ReactiveV2
{
    public static class FaceFrameReaderExtensions
    {
        public static IObservable<FaceFrameArrivedEventArgs> FaceFrameArrivedObservable(this FaceFrameReader reader)
        {
            return Observable.FromEventPattern<EventHandler<FaceFrameArrivedEventArgs>, FaceFrameArrivedEventArgs>(
                h => h.Invoke,
                h => reader.FrameArrived += h,
                h => reader.FrameArrived -= h)
                .Select(_ => _.EventArgs);
        }
    }
}