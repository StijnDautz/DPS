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
        private static GraphicsDeviceManager _graphics;
        private GameModeManager _gameModeManager;
        private static AssetManager _assetManager;
        private SpriteBatch _spriteBatch;
        private static InputManager _inputManager;
        private static Random _rng;

        protected GameModeManager GameModeManager
        {
            get { return _gameModeManager; }
        }

        public static GraphicsDeviceManager GraphicsDeviceManager
        {
            get { return _graphics; }
        }

        public static AssetManager AssetManager
        {
            get { return _assetManager; }
        }

        public static InputManager InputManager
        {
            get { return _inputManager; }
        }

        public SpriteBatch SpriteBatch
        {
            get { return _spriteBatch; }
        }

        public static Random RNG
        {
            get { return _rng; }
        }

        public GameInstance()
        {
            Content.RootDirectory = "Content";
            _graphics = new GraphicsDeviceManager(this);
            _assetManager = new AssetManager(Content);
            _gameModeManager = new GameModeManager();
            _gameModeManager.GameInstance = this;
            _inputManager = new InputManager();
            _rng = new Random();
            _graphics.PreferredBackBufferWidth = 1280;
            _graphics.PreferredBackBufferHeight = 720;
        }

        protected override void LoadContent()
        {
            base.LoadContent();
            _spriteBatch = new SpriteBatch(GraphicsDevice);
        }

        protected override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
            _gameModeManager.HandleInput(gameTime);
            _gameModeManager.Update(gameTime);
            _inputManager.Update();
        }

        protected override void Draw(GameTime gameTime)
        {
            base.Draw(gameTime);
            GraphicsDevice.Clear(Color.Brown);
            _spriteBatch.Begin();
            _gameModeManager.Draw(gameTime, _spriteBatch);
            _spriteBatch.End();
        }
    }
}
