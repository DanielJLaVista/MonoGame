using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace TopDownShooter {
    public class Hero : Basic2d {
        public float speed;
        public Hero(string path, Vector2 pos, Vector2 dims) : base(path, pos, dims) {
            speed = 2.0f;
        }

        public override void Update() {
            if (Globals.keyboard.GetPress("A")) {
                pos = new Vector2(pos.X - speed, pos.Y);
            }
            if (Globals.keyboard.GetPress("D")) {
                pos = new Vector2(pos.X + speed, pos.Y);
            }
            if (Globals.keyboard.GetPress("W")) {
                pos = new Vector2(pos.X, pos.Y - speed);
            }
            if (Globals.keyboard.GetPress("S")) {
                pos = new Vector2(pos.X, pos.Y + speed);
            }

            rot = Globals.RotateTowards(pos, new Vector2(Globals.mouse.newMouse.X, Globals.mouse.newMouse.Y));
            base.Update();
        }

        public override void Draw(Vector2 offset) {
            base.Draw(offset);
        }
    }
}