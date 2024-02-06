using System;
using System.Collections.Generic;
using System.IO.Compression;
using System.Linq;
using System.Numerics;
using System.Threading.Tasks;

namespace TopDownShooter {
    public class GamePlay {
        int playState;
        World world;
        public GamePlay() {

            playState = 0;
            ResetWorld (null);
        }

        public virtual void Update() {
            if (playState == 0) {
                world.Update ();
            }
        }
        public virtual void ResetWorld(object info) {
            world = new World (ResetWorld);
        }
        public virtual void Draw() {
            if (playState == 0) {
                world.Draw (Vector2.Zero);
            }
        }
    }
}