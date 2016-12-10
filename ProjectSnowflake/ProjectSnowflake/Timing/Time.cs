using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace ProjectSnowflake.Timing
{
    /// <summary>
    /// Provides information on the speed of the game.
    /// </summary>
    public static class Time
    {
        /// <summary>
        /// The time elapsed during the last frame, measured in seconds, multiplied by the "game speed" factor
        /// </summary>
        public static float gameElapsedSeconds
        {
            get
            {
                return actualElapsedSeconds * gameSpeed;
            }
        }

        /// <summary>
        /// The actual time elapsed during the last frame, measured in seconds, NOT multiplied by the "game speed" factor
        /// </summary>
        public static float actualElapsedSeconds;

        /// <summary>
        /// The factor by which gameElapsedSeconds is multiplied. 1 for normal bahavior, 0 for pause etc.
        /// </summary>
        public static float gameSpeed = 1;

        /// <summary>
        /// The time elapsed since startup
        /// </summary>
        public static float totalSeconds;

        /// <summary>
        /// The time elapsed since startup
        /// </summary>
        public static float totalGameSeconds;

        public static int frameCount { get; set; }

        public static FpsTracker updateFps;
        public static FpsTracker drawFps;

        /// <summary>
        /// Makes sure all variables are not null.
        /// </summary>
        public static void tryInit()
        {
            if (updateFps == null)
                updateFps = new FpsTracker("Update");
            if (drawFps == null)
                drawFps = new FpsTracker("Draw");
        }

        /// <summary>
        /// Updates the time and fps information
        /// </summary>
        /// <param name="elapsedSeconds"></param>
        public static void update(float elapsedSeconds)
        {
            tryInit();
            Time.actualElapsedSeconds = elapsedSeconds;
            Time.totalSeconds += elapsedSeconds;
            Time.totalGameSeconds += gameElapsedSeconds;
            frameCount++;
        }

        public static float elapsedSeconds(TimeSource time)
        {
            switch (time)
            {
                case TimeSource.ActualTime:
                    return actualElapsedSeconds;
                case TimeSource.GameTime:
                    return gameElapsedSeconds;
            }
            return 0;
        }

        public static bool wasPhaseStep(float phaseLength, float offset = 0)
        {
            int oldValue = (int)((totalSeconds - actualElapsedSeconds + offset) / phaseLength);
            int newValue = (int)((totalSeconds + offset) / phaseLength);
            return oldValue != newValue;
        }

        public static bool wasPhaseStepGameTime(float phaseLength, float offset = 0)
        {
            int oldValue = (int)((totalGameSeconds - gameElapsedSeconds + offset) / phaseLength);
            int newValue = (int)((totalGameSeconds + offset) / phaseLength);
            return oldValue != newValue;
        }
    }
}