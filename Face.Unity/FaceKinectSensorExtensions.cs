using Microsoft.Kinect.Face;
using System;
using UniRx;
using Windows.Kinect;

namespace Kinect.ReactiveV2
{
    public static class FaceKinectSensorExtensions
    {
        /// <summary>
        /// Converts the FaceFrameArrivedEvent event to an observable sequence.
        /// You need one of these per body.
        /// </summary>
        /// <param name="kinectSensor">The kinect sensor.</param>
        /// <param name="trackingId">The body to observe.</param>
        /// <param name="features">The features to observe.</param>
        /// <returns>The observable sequence.</returns>
        public static IObservable<FaceFrameArrivedEventArgs> FaceFrameArrivedObservable(this KinectSensor kinectSensor, ulong trackingId, FaceFrameFeatures features)
        {
            if (kinectSensor == null) throw new ArgumentNullException("kinectSensor");

            var source = FaceFrameSource.Create(kinectSensor, trackingId, features);

            return Observable.Create<FaceFrameArrivedEventArgs>(observer =>
            {
                var reader = source.OpenReader();

                var disposable = reader.FaceFrameArrivedObservable()
                                             .Subscribe(x => observer.OnNext(x),
                                                        e => observer.OnError(e),
                                                        () => observer.OnCompleted());

                return new CompositeDisposable { disposable, reader };
            });
        }

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