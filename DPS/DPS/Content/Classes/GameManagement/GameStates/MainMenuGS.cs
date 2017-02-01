using Engine;
using Microsoft.Xna.Framework;

namespace Content
{
    class MainMenuGS : GameState
    {
        private TextObject _highScore;

        public MainMenuGS(GameStateManager gameStateManager) : base("GSMainMenu", gameStateManager)
        {
            //Add background
            AddToHud(new TexturedObject("background", HUD, new SpriteSheet("Textures/HUD/MainMenu")));
            
            PlayButton playButton = new PlayButton("playButton", HUD, new SpriteSheet("Textures/HUD/PlayButton"), "Rocket");
            playButton.Position = new Microsoft.Xna.Framework.Vector2(550, 225);
            AddToHud(playButton);

            ExitButton exitButton = new ExitButton("exitButton", HUD, new SpriteSheet("Textures/HUD/ExitButton"), "Rocket");
            exitButton.Position = new Microsoft.Xna.Framework.Vector2(550, 425);
            AddToHud(exitButton);

            _highScore = new TextObject("highScore", "Hud", HUD);
            _highScore.Visible = false;
            _highScore.Position = new Vector2(730, 600);
            _highScore.Color = new Color(124, 93, 72);
            _highScore.Scale = 2;
            AddToHud(_highScore);

            var buttonSettings = new ButtonSettings(HUD);
            buttonSettings.Position = new Microsoft.Xna.Framework.Vector2(550, 325);
            AddToHud(buttonSettings);

            SongPlay = Engine.GameInstance.AssetManager.GetSong("Main Menu");
        }

        public override void Init()
        {
            base.Init();
            CanUpdateWorld = false;
            IsMouseVisible = true;
            CanUpdateGameTime = false;
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
            if(HighScoreManager.HighScore == 0)
            {
                GameStateManager.SwitchTo("GSLogin");
            }
            else if(!_highScore.Visible)
            {
                _highScore.Text = HighScoreManager.HighScore.ToString();
                _highScore.Visible = true;
            }
        }
    }
}