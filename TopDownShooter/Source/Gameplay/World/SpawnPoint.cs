using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace TopDownShooter {
    public class SpawnPoint : Basic2d {
        public bool dead;
        public float hitDist;

        public TimeCounter spawnTimer = new TimeCounter (2200);

        public float speed;
        public SpawnPoint(string path, Vector2 pos, Vector2 dims) : base (path, pos, dims) {
            speed = 2.0f;
            dead = false;
        }

        public override void Update(Vector2 offset) {
            spawnTimer.AddElapsedGameTime ();
            if (spawnTimer.goalTimeIsMet ()) {
                SpawnMob ();
                spawnTimer.ResetToZero ();
            };

            base.Update (offset);
        }

        public virtual void GetHit() {
            dead = true;
        }

        public virtual void SpawnMob() {
            GameGlobals.PassMob (new Imp (new Vector2 (pos.X, pos.Y)));
        }

        public override void Draw(Vector2 offset) {
            base.Draw (offset);
        }
    }
}