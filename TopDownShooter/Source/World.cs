using Microsoft.Xna.Framework;
namespace TopDownShooter.Source.Engine
{
    public class World
    {
        Basic2d hero;

        public World()
        {
            hero = new Basic2d("Hero", new Vector2(300, 300), new Vector2(48, 48));
        }

        public virtual void Update()
        {
            hero.Update();
        }

        public virtual void Draw()
        {
            hero.Draw();
        }
    }
}