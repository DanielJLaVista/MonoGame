using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace TopDownShooter {
    public class Mob : Unit {
        public Mob(string path, Vector2 pos, Vector2 dims) : base (path, pos, dims) {
            speed = 2.0f;
        }

        public virtual void Update(Vector2 offset, Hero hero) {
            AI (hero);
            base.Update (offset);
        }

        public virtual void AI(Hero hero) {
            pos += Globals.RadialMovement (hero.pos, pos, speed);
            rot = Globals.RotateTowards (pos, hero.pos);

            if (Globals.GetDistance (pos, hero.pos) < 25) {
                hero.GetHit (1);
                dead = true;
            }
        }
        public override void Draw(Vector2 offset) {
            base.Draw (offset);
        }
    }
}