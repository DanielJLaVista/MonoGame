using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using System.Text;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework;
using System.ComponentModel.DataAnnotations;

namespace TopDownShooter {
    public class TimeCounter {
        public bool goodToGo;
        protected TimeSpan goalTime;//milliseconds
        protected TimeSpan timeSpan = new TimeSpan ();


        public TimeCounter(int goalTimeMillis) {
            goodToGo = false;
            MSec = goalTimeMillis;
        }
        public TimeCounter(int goalTimeMillis, bool startloaded) {
            goodToGo = startloaded;
            MSec = goalTimeMillis;
        }

        private double MSec {
            get { return goalTime.TotalMilliseconds; }
            set { goalTime = TimeSpan.FromMilliseconds (value); }
        }
        public int Timer {
            get { return (int)timeSpan.TotalMilliseconds; }
        }

        public void AddElapsedGameTime() {
            AddTime (Globals.gameTime.ElapsedGameTime);
        }

        public void AddTime(TimeSpan time) {
            timeSpan += time;
        }

        public void AddElapsedGameTimeWithSpeed(float speed) {
            AddTime (TimeSpan.FromTicks ((long)(Globals.gameTime.ElapsedGameTime.Ticks * speed)));
        }

        public virtual void AddTime(int mSec) {
            timeSpan += TimeSpan.FromMilliseconds ((long)(mSec));
        }

        public bool goalTimeIsMet() {
            if (timeSpan >= goalTime || goodToGo) {
                return true;
            }
            return false;
        }

        public void Reset() {
            timeSpan = timeSpan.Subtract (goalTime);
            if (timeSpan.TotalMilliseconds < 0) {
                timeSpan = TimeSpan.Zero;
            }
            goodToGo = false;
        }

        public void ResetAndSetNewGoalTime(int goalTime) {
            ResetToZero ();
            MSec = goalTime;
        }

        public void ResetToZero() {
            timeSpan = TimeSpan.Zero;
            goodToGo = false;
        }

        public virtual XElement ReturnXML() {
            XElement xml = new XElement ("Timer",
                                    new XElement ("mSec", goalTime),
                                    new XElement ("timer", Timer));

            return xml;
        }

        public void SetTimeCounterTo(TimeSpan time) {
            timeSpan = time;
        }

        public virtual void SetTimeCounterTo(long milliseconds) {
            timeSpan = TimeSpan.FromMilliseconds (milliseconds);
        }
    }
}
