using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Media;

namespace Engine
{
    /*
     * GameState contains a HUD
     * Therefore a GameMode can have multiple HUD overlays
     */
    class GameState
    {
        private string _id;
        private ObjectList _HUD;
        private GameStateManager _gameStateManager;

        private Song songPlay;

        public Song SongPlay
        {
            get { return songPlay; }
            set { songPlay = value; }
        }

        public string Id
        {
            get { return _id; }
        }

        public ObjectList HUD
        {
            get { return _HUD; }
            set { _HUD = value; }
        }

        protected World World
        {
            get { return _gameStateManager.GameMode.World; }
        }

        protected GameStateManager GameStateManager
        {
            get { return _gameStateManager; }
        }

        protected GameInstance GameInstance
        {
            get { return _gameStateManager.GameMode.GameModeManager.GameInstance; }
        }

        protected bool IsMouseVisible
        {
            set { GameInstance.IsMouseVisible = value; }
        }

        public bool CanUpdateGameTime
        {
            set { GameStateManager.GameMode.GameModeManager.CanUpdateGameTime = value; }
        }

        public bool CanUpdateWorld
        {
            set { _gameStateManager.GameMode.CanUpdateWorld = value; }
        }

        public GameState(string id, GameStateManager gameStateManager)
        {
            _id = id;
            _gameStateManager = gameStateManager;
            _HUD = new ObjectList("HUD", World);      
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

        protected void AddToHud(Object o)
        {
            o.Depth = 0;
            _HUD.Add(o);
        }
    }
}