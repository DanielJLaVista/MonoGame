using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace TopDownShooter {

    public class Main : Game {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        GamePlay gamePlay;
        Basic2d cursor;

        public Main() {
            _graphics = new GraphicsDeviceManager (this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize() {
            // TODO: Add your initialization logic here
            Globals.screenHeight = 500; //900
            Globals.screenWidth = 800;  //1600

            _graphics.PreferredBackBufferWidth = Globals.screenWidth;
            _graphics.PreferredBackBufferHeight = Globals.screenHeight;

            _graphics.ApplyChanges ();

            base.Initialize ();
        }

        protected override void LoadContent() {
            Globals.content = this.Content;
            Globals._spriteBatch = new SpriteBatch (GraphicsDevice);
            cursor = new Basic2d ("2d/Misc/CursorArrow", new Vector2 (0, 0), new Vector2 (28, 28));
            Globals.keyboard = new McKeyboard ();
            Globals.mouse = new McMouseControl ();

            gamePlay = new GamePlay ();
            // TODO: use this.Content to load your game content here
        }

        protected override void Update(GameTime gameTime) {
            if (GamePad.GetState (PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState ().IsKeyDown (Keys.Escape))
                Exit ();

            // TODO: Add your update logic here
            Globals.gameTime = gameTime;
            Globals.keyboard.Update ();
            Globals.mouse.Update ();

            gamePlay.Update ();

            Globals.keyboard.UpdateOld ();
            Globals.mouse.UpdateOld ();

            //This resets elapsed game time
            base.Update (gameTime);

        }


        protected override void Draw(GameTime gameTime) {
            GraphicsDevice.Clear (Color.CornflowerBlue);
            Globals._spriteBatch.Begin (SpriteSortMode.Deferred, BlendState.AlphaBlend);
            // TODO: Add your drawing code here
            gamePlay.Draw ();

            cursor.Draw (new Vector2 (Globals.mouse.newMousePos.X, Globals.mouse.newMousePos.Y), new Vector2 (0, 0), Color.White);
            Globals._spriteBatch.End ();
            base.Draw (gameTime);
        }
    }
}