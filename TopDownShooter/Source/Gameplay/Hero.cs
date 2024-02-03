using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace TopDownShooter {
    public class Hero : Basic2d {
        public Hero(string path, Vector2 pos, Vector2 dims) : base(path, pos, dims) {

        }

        public override void Update() {
            if (Globals.keyboard.GetPress("A")) {
                pos = new Vector2(pos.X - 1, pos.Y);
            }
            if (Globals.keyboard.GetPress("D")) {
                pos = new Vector2(pos.X + 1, pos.Y);
            }
            if (Globals.keyboard.GetPress("W")) {
                pos = new Vector2(pos.X, pos.Y - 1);
            }
            if (Globals.keyboard.GetPress("S")) {
                pos = new Vector2(pos.X, pos.Y + 1);
            }
            base.Update();
        }

        public override void Draw() {
            base.Draw();
        }
    }
}