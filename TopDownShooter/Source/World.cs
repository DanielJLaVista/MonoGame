using Microsoft.Xna.Framework;

namespace TopDownShooter {
    public class World {
        Hero hero;

        public World() {
            hero = new Hero("Hero", new Vector2(300, 300), new Vector2(48, 48));
        }

        public virtual void Update() {
            hero.Update();
        }

        public virtual void Draw() {
            hero.Draw();
        }
    }
}