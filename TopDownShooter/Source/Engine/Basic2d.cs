using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace TopDownShooter {
    public class Basic2d {
        public Vector2 pos, dims;
        public Texture2D model;
        public Basic2d(string path, Vector2 pos, Vector2 dims) {
            this.pos = pos;
            this.dims = dims;
            model = Globals.content.Load<Texture2D>(path);
        }

        public virtual void Update() {

        }

        public virtual void Draw() {
            if (model != null) {
                Globals._spriteBatch.Draw(model, new Rectangle((int)pos.X, (int)pos.Y, (int)dims.X, (int)dims.Y), null, Color.White, 0.0f, new Microsoft.Xna.Framework.Vector2(model.Bounds.Width / 2, model.Bounds.Height / 2), new SpriteEffects(), 0);
            }
        }
    }
}