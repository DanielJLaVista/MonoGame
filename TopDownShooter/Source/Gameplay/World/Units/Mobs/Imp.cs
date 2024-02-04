using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace TopDownShooter {
    public class Imp : Mob {
        public Imp(Vector2 pos) : base ("2d/Units/Mobs/Imp", pos, new Vector2 (40, 40)) {
            speed = 2.0f;
        }

        public override void Update(Vector2 offset, Hero hero) {
            base.Update (offset, hero);
        }

        public override void Draw(Vector2 offset) {
            base.Draw (offset);
        }
    }
}