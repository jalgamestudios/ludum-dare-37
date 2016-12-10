using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace ProjectSnowflake.Timing
{
    public class FpsTracker
    {
        public float totalTime;

        /// <summary>
        /// The frames that have been completed this frame
        /// (this number should not be used to get the game's fps, as ist will continually increase over the course of a second. Use framesLastSecond instead)
        /// </summary>
        public int framesThisSecond;

        /// <summary>
        /// The number of frames that have been drawn last second.
        /// </summary>
        public int framesLastSecond;

        /// <summary>
        /// A list contianing all fps values sonce the beginning of the execution
        /// </summary>
        public List<float> fpsCollection;

        public string fpsName;

#if DEBUG

        /// <summary>
        /// Wheater to write the fps information to the output each frame (defaults to true when debuggen and false when releasing)
        /// </summary>
        public bool logFPS = true;

#else
        /// <summary>
        /// Wheater to write the fps information to the output each frame (defaults to true when debuggen and false when releasing)
        /// </summary>
        public bool logFPS = false;
#endif
        public FpsTracker()
        {
            fpsName = "unnamed";
            framesThisSecond = 0;
            framesLastSecond = 0;
            fpsCollection = new List<float>();
        }
        public FpsTracker(string name)
        {
            fpsName = name;
            framesThisSecond = 0;
            framesLastSecond = 0;
            fpsCollection = new List<float>();
        }

        public void frame(float elapsedTime)
        {
            float oldTotalTime = totalTime;
            totalTime += elapsedTime;
            framesThisSecond++;
            if ((int)totalTime != (int)oldTotalTime)
            {
                framesLastSecond = framesThisSecond;
                framesThisSecond = 0;
                fpsCollection.Add(framesLastSecond);
                if (logFPS)
                    Debug.WriteLine("FPS (" + fpsName + "):  last second: " + framesLastSecond.ToString() + "; last 10 seconds: " + fpsAverage(10) + "; all time: " + fpsAverage(fpsCollection.Count));
            }
        }

        /// <summary>
        /// The average fps over the given number of seconds.
        /// </summary>
        /// <param name="seconds">The number of seconds the average should be sampled from</param>
        /// <returns>The average framerate</returns>
        public float fpsAverage(int seconds)
        {
            float average = 0;
            int fpsCount = Math.Min(seconds, fpsCollection.Count);
            if (fpsCount == 0 || seconds == 0)
                return 0;
            for (int i = fpsCollection.Count - fpsCount; i < fpsCollection.Count; i++)
                average += fpsCollection[i] / fpsCount;
            return average;
        }
    }
}
