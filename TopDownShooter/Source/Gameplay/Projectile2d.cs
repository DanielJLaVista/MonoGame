using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Threading.Tasks.Dataflow;
using Microsoft.Xna.Framework;

namespace TopDownShooter {
    public class Projectile2d : Basic2d {
        //when the projectile is expired
        public bool done;
        public float speed;
        public Unit owner;
        public Vector2 direction;
        public TimeCounter timer;
        public Projectile2d(string path, Vector2 pos, Vector2 dims, Unit owner, Vector2 target) : base (path, pos, dims) {
            done = false;
            speed = 5.0f;
            this.owner = owner;
            direction = target - owner.pos;
            direction.Normalize ();
            timer = new TimeCounter (1200);
        }
        public virtual void Update(Vector2 offset, List<Unit> units) {
            pos += direction * speed;
            timer.AddElapsedGameTime ();
            if (timer.goalTimeIsMet ()) {
                done = true;
            }

            if (HitSomething (units)) {
                done = true;
            }
        }

        public virtual bool HitSomething(List<Unit> units) {
            for (int i = 0; i < units.Count; i++) {
                if (Globals.GetDistance (pos, units[i].pos) < units[i].hitDist) {
                    units[i].GetHit (1);
                    return true;
                }
            }
            return false;
        }

        public override void Draw(Vector2 offset) {
            base.Draw (offset);
        }
    }
}