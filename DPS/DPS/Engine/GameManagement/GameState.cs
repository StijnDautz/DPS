using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine
{
    /*
     * GameState contains a HUD
     * Therefore a GameMode can have multiple HUD overlays
     */
    class GameState : IControlledLoopObject
    {
        private string _id;
        private ObjectList _HUD;
        private GameStateManager _gameStateManager;

        public string Id
        {
            get { return _id; }
        }

        public ObjectList HUD
        {
            get { return _HUD; }
            set { _HUD = value; }
        }

        public GameStateManager GameStateManager
        {
            get { return _gameStateManager; }
            set { _gameStateManager = value; }
        }

        protected GameMode GameMode
        {
            get { return _gameStateManager.Parent; }
        }

        protected World World
        {
            get { return GameMode.World; }
        }

        protected GameModeManager GameModeManager
        {
            get { return _gameStateManager.Parent.Parent; }
        }

        protected bool IsMouseVisible
        {
            set { GameModeManager.GameInstance.IsMouseVisible = value; }
        }

            
        public GameState(string id)
        {
            _id = id;
            _HUD = new ObjectList("HUD");      
        }

        public virtual void Update(GameTime gameTime)
        {
            _HUD.Update(gameTime);
        }

        public virtual void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            _HUD.Draw(gameTime, spriteBatch);
        }

        public virtual void Reset()
        {
            _HUD.Reset();
        }

        public virtual void HandleInput(GameTime gameTime)
        {

        }

        public virtual void Setup()
        {

        }

        public virtual void Init()
        {

        }

        protected void Add(Object o)
        {
            o.Depth = 0;
            _HUD.Add(o);
        }
    }
}