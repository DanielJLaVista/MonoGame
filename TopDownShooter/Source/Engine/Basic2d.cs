using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace TopDownShooter {
    public class Basic2d {
        public float rot;
        public Vector2 pos, dims;
        public Texture2D model;
        public Basic2d(string path, Vector2 pos, Vector2 dims) {
            this.pos = pos;
            this.dims = dims;
            model = Globals.content.Load<Texture2D> (path);
        }

        public virtual void Update(Vector2 offset) {

        }

        public virtual void Draw(Vector2 offset) {
            if (model != null) {
                Globals._spriteBatch.Draw (model, new Rectangle ((int)(pos.X + offset.X), (int)(pos.Y + offset.Y), (int)dims.X, (int)dims.Y), null, Color.White, rot, new Microsoft.Xna.Framework.Vector2 (model.Bounds.Width / 2, model.Bounds.Height / 2), new SpriteEffects (), 0);
            }
        }
        public virtual void Draw(Vector2 offset, Vector2 origin, Color colour) {
            if (model != null) {
                Globals._spriteBatch.Draw (model, new Rectangle ((int)(pos.X + offset.X), (int)(pos.Y + offset.Y), (int)dims.X, (int)dims.Y), null, colour, rot, new Microsoft.Xna.Framework.Vector2 (origin.X, origin.Y), new SpriteEffects (), 0);
            }
        }
    }
}