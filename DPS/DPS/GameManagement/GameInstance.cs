using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DPS
{
    class GameInstance : Game
    {
        private GameModeManager _gameModeManager;
        public static AssetManager assetManager;
        SpriteBatch spriteBatch;

        public GameInstance()
        {            
            assetManager = new AssetManager(Content);
            _gameModeManager = new GameModeManager();
            spriteBatch = new SpriteBatch(GraphicsDevice);
        }

        protected override void LoadContent()
        {
            base.LoadContent();

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
