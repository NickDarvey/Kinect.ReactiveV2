using System;

namespace Kinect.ReactiveV2
{
    public class SceneChangedEventArgs : EventArgs
    {
        public SceneChangedEventArgs(ulong trackingId, SceneChangedState state)
        {
            TrackingId = trackingId;
            State = state;
        }

        public ulong TrackingId { get; private set; }
        public SceneChangedState State { get; private set; }
    }

    public enum SceneChangedState
    {
        Entered,
        Left
    }
}