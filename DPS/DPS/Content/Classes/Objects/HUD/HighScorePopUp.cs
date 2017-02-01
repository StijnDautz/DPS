using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Engine;
using Microsoft.Xna.Framework;

namespace Content
{
    class HighScorePopUp : ObjectList
    {
        public HighScorePopUp(Engine.Object parent, int oldHighScore, int newHighScore) : base("highScorePopUp", parent)
        {
            //TODO set proper positions of objects
            //create background
            var backGround = new TexturedObject("background", this, new SpriteSheet("Textures/HUD/HighScorePopUpWindow"));

            //set boundingbox to boundingbox of background
            BoundingBox = backGround.BoundingBox;

            //create TextObjects
            var oldScore = new TextObject("oldHighScore", "Hud", this);
            oldScore.Text = oldHighScore.ToString();
            oldScore.Color = new Color(124, 93, 72);
            oldScore.Position = new Vector2(160, 120);

            var newScore = new TextObject("newHighScore", "Hud", this);
            newScore.Text = newHighScore.ToString();
            newScore.Color = new Color(124, 93, 72);
            newScore.Position = new Vector2(160, 305);

            var totalDamageDealt = new TextObject("totalDamageDealt", "Hud", this);
            totalDamageDealt.Text = HighScoreManager.IncrementTotalDamageDealt.ToString();
            totalDamageDealt.Color = new Color(124, 93, 72);
            totalDamageDealt.Position = new Vector2(160, 175);
            totalDamageDealt.Scale = 0.6f;

            var totalDamageTaken = new TextObject("totalDamageTaken", "Hud", this);
            totalDamageTaken.Text = HighScoreManager.IncrementTotalDamageTaken.ToString();
            totalDamageTaken.Color = new Color(124, 93, 72);
            totalDamageTaken.Position = new Vector2(160, 202);
            totalDamageTaken.Scale = 0.6f;

            var time = new TextObject("time", "Hud", this);
            time.Text = GameModeManager.TimeManager.TotalSeconds.ToString();
            time.Scale = 0.6f;
            time.Color = new Color(124, 93, 72);
            time.Position = new Vector2(160, 230);

            var finished = new TextObject("finished", "Hud", this);
            finished.Text = World.Player.Death ? "no" : "yes";
            finished.Scale = 0.6f;
            finished.Color = new Color(124, 93, 72);
            finished.Position = new Vector2(160, 255);

            //create buttons
            var buttonContinue = new ButtonContinue(this, "GSMainMenu");
            buttonContinue.Position = new Vector2(backGround.Width / 2 - buttonContinue.Width / 2, 350);

            //add objects
            Add(backGround);
            Add(buttonContinue);
            Add(oldScore);
            Add(newScore);
            Add(time);
            Add(finished);
            Add(totalDamageDealt);
            Add(totalDamageTaken);

            setupPossibleNewHighScore(oldHighScore, newHighScore);
        }

        private void setupPossibleNewHighScore(int oldScore, int newScore)
        {
            //get newest HighScore
            int newHighScore = Math.Max(oldScore, newScore);

            //Upload updated highScore to the website
            HighScoreManager.uploadHighscore(newHighScore);

            //create textObject
            var highScore = new TextObject("newHighScore", "Hud", this);
            highScore.Text = newHighScore.ToString();
            highScore.Color = Color.Red;
            highScore.Position = new Vector2(160, 70);

            Add(highScore);
        }
    }
}
