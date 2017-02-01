using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Engine;

namespace Content
{
    class GSGameFinished : GameState
    {
        public GSGameFinished(GameStateManager gameStateManager) : base("GSGameFinished", gameStateManager)
        {

        }

        public override void Init()
        {
            base.Init();
            CanUpdateGameTime = false;
            World.CanUpdate = false;

            //set background
            var backGround = new TexturedObject("background", HUD, new SpriteSheet("Textures/HUD/MainMenu"));

            //calculate new HighScore
            var time = GameModeManager.TimeManager.TotalSeconds;
            var oldHighScore = HighScoreManager.HighScore;
            var newHighScore = HighScoreManager.CalculateNewHighScore(time, !World.Player.Death);

            //if the newHighScore is higher than the previous one, upload it to the website
            if(newHighScore > oldHighScore)
            {
                HighScoreManager.uploadHighscore(newHighScore);
            }

            //add highScorePopUpWindow to HUD
            var highScorePopUpWindow = new HighScorePopUp(HUD, oldHighScore, newHighScore);
            highScorePopUpWindow.Position = new Microsoft.Xna.Framework.Vector2(backGround.Width / 2 - highScorePopUpWindow.Width / 2, backGround.Height / 2 - highScorePopUpWindow.Height / 2);

            //add objects to HUD
            AddToHud(backGround);
            AddToHud(highScorePopUpWindow);
        }
    }
}
