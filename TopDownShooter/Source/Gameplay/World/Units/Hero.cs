using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace TopDownShooter {
    public class Hero : Unit {
        public Hero(string path, Vector2 pos, Vector2 dims) : base (path, pos, dims) {
            speed = 2.0f;
        }

        public override void Update(Vector2 offset) {
            bool checkScroll = false;

            if (Globals.keyboard.GetPress ("A")) {
                pos = new Vector2 (pos.X - speed, pos.Y);
                checkScroll = true;
            }
            if (Globals.keyboard.GetPress ("D")) {
                pos = new Vector2 (pos.X + speed, pos.Y);
                checkScroll = true;
            }
            if (Globals.keyboard.GetPress ("W")) {
                pos = new Vector2 (pos.X, pos.Y - speed);
                checkScroll = true;
            }
            if (Globals.keyboard.GetPress ("S")) {
                pos = new Vector2 (pos.X, pos.Y + speed);
                checkScroll = true;
            }

            rot = Globals.RotateTowards (pos, new Vector2 (Globals.mouse.newMouse.X, Globals.mouse.newMouse.Y) - offset);
            if (Globals.mouse.LeftClick ()) {
                GameGlobals.PassProjectile (new Fireball (new Vector2 (pos.X, pos.Y), this, new Vector2 (Globals.mouse.newMousePos.X, Globals.mouse.newMousePos.Y) - offset));
            }
            if (checkScroll) {
                GameGlobals.CheckScroll (pos);
            }
            base.Update (offset);
        }

        public override void Draw(Vector2 offset) {
            base.Draw (offset);
        }
    }
}