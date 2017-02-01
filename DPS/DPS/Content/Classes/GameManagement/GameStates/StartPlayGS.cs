using Engine;
using Microsoft.Xna.Framework;

namespace Content
{
    class StartPlayGS : GameState
    {
        private bool _enemiesScaled;

        public StartPlayGS(string id, GameStateManager gameStateManager) : base(id, gameStateManager)
        {
            var timer = new Timer("timer", HUD);
            timer.Position = new Vector2(GameInstance.GraphicsDeviceManager.PreferredBackBufferWidth - 130, 640);
            AddToHud(timer);

            var healthBar = new HealthBar("healthBar", HUD);
            healthBar.Position = new Vector2(50, 600);
            AddToHud(healthBar);

            SongPlay = GameInstance.AssetManager.GetSong("Main Song");
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
            if (!_enemiesScaled)
            {
                //scale the enemies in all worlds according to highscore
                GameStateManager.GameMode.ScaleEnemies();
                _enemiesScaled = true;
            }
        }

        public override void Init()
        {
            base.Init();
            IsMouseVisible = true;
            CanUpdateWorld = true;
            CanUpdateGameTime = true;
            _enemiesScaled = false;
        }
    }
}
