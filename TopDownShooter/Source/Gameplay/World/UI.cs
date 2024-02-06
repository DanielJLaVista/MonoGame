using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Graphics;

namespace TopDownShooter {
    public class UI {
        public SpriteFont font;

        public QuantityDisplayBar healthBar;
        public UI() {
            font = Globals.content.Load<SpriteFont> ("Fonts/Arial16");
            healthBar = new QuantityDisplayBar (new Vector2 (104, 16), 2, Color.Red);
        }

        public void Update(World world) {
            healthBar.Update (world.hero.health, world.hero.healthMax);
        }

        public void Draw(World world) {
            string tempStr = "Num killed = " + world.numKilled;
            Vector2 tempStrDims = font.MeasureString (tempStr);
            Globals._spriteBatch.DrawString (font, tempStr, new Vector2 (Globals.screenWidth / 2 - tempStrDims.X / 2, Globals.screenHeight - 40), Color.Black);
            healthBar.Draw (new Vector2 (20, Globals.screenHeight - 40));

            if (world.hero.dead) {
                tempStr = "Press Enter to Restart";
                tempStrDims = font.MeasureString (tempStr);
                Globals._spriteBatch.DrawString (font, tempStr, new Vector2 (Globals.screenWidth / 2 - tempStrDims.X / 2, Globals.screenHeight / 2), Color.Black);
            }
        }
    }
}
