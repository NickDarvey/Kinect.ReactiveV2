

using Microsoft.Kinect.VisualGestureBuilder;
using System.Collections.Generic;

namespace Kinect.ReactiveV2
{
    public class GestureResults
    {
        public Dictionary<Gesture, ContinuousGestureResult> Continuous { get; set; }
        public Dictionary<Gesture, DiscreteGestureResult> Discrete { get; set; }

        public GestureResults()
        {
            Continuous = new Dictionary<Gesture, ContinuousGestureResult>();
            Discrete = new Dictionary<Gesture, DiscreteGestureResult>();
        }
    }
}
