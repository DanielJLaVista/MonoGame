using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Threading.Tasks.Dataflow;
using Microsoft.Xna.Framework;

namespace TopDownShooter {
    public class Fireball : Projectile2d {
        //when the projectile is expired
        public Fireball(Vector2 pos, Unit owner, Vector2 target) : base ("2d/Projectiles/Fireball", pos, new Vector2 (20, 20), owner, target) {

        }
        public override void Update(Vector2 offset, List<Unit> units) {
            base.Update (offset, units);
        }

        public override void Draw(Vector2 offset) {
            base.Draw (offset);
        }
    }
}