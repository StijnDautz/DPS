using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine
{
    class GameInstance : Game
    {
        protected GraphicsDeviceManager _graphics; 
        private GameModeManager _gameModeManager;
        public static AssetManager assetManager;
        SpriteBatch spriteBatch;

        public GameInstance()
        {
            _graphics = new GraphicsDeviceManager(this);
            assetManager = new AssetManager(Content);
            _gameModeManager = new GameModeManager();
        }

        protected override void LoadContent()
        {
            base.LoadContent();
            spriteBatch = new SpriteBatch(GraphicsDevice);
        }

        protected override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
            _gameModeManager.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            base.Draw(gameTime);
            _gameModeManager.Draw(gameTime, spriteBatch);
        }
    }
}
