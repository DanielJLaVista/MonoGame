using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace TopDownShooter {
    public class Unit : Basic2d {
        public bool dead;
        public float speed, hitDist, health, healthMax;

        public Unit(string path, Vector2 pos, Vector2 dims) : base (path, pos, dims) {
            speed = 2.0f;
            dead = false;

            health = 1;
            healthMax = health;
            hitDist = 35.0f;
        }

        public override void Update(Vector2 offset) {
            base.Update (offset);
        }

        public virtual void GetHit(float damage) {
            health -= damage;
            if (health <= 0) {
                dead = true;
            }
        }

        public override void Draw(Vector2 offset) {
            base.Draw (offset);
        }
    }
}