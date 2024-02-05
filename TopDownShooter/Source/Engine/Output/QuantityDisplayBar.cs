using System;
using System.Collections.Generic;

using System.Linq;
using Microsoft.Xna.Framework;
using System.Reflection.Metadata.Ecma335;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;

namespace TopDownShooter {
    public class QuantityDisplayBar {

        public int border;
        public Basic2d bar, barBg;
        public Color colour;
        public QuantityDisplayBar(Vector2 dims, int border, Color colour) {
            this.border = border;
            this.colour = colour;

            bar = new Basic2d ("2d/Misc/solid", new Vector2 (0, 0), new Vector2 (dims.X - border * 2, dims.Y - border * 2));
            barBg = new Basic2d ("2d/Misc/shade", new Vector2 (0, 0), new Vector2 (dims.X, dims.Y));
        }

        public virtual void Update(float current, float max) {
            bar.dims = new Vector2 (current / max * (barBg.dims.X - border * 2), bar.dims.Y);
        }

        public virtual void Draw(Vector2 offset) {
            barBg.Draw (offset, new Vector2 (0, 0), Color.Black);
            bar.Draw (offset + new Vector2 (border, border), new Vector2 (0, 0), colour);
        }
    }
}