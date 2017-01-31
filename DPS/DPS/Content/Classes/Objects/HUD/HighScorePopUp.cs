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

            var newScore = new TextObject("newHighScore", "Hud", this);
            newScore.Text = newHighScore.ToString();
            newScore.Color = new Color(124, 93, 72);

            var totalDamageDealt = new TextObject("totalDamageDealt", "Hud", this);
            totalDamageDealt.Text = HighScoreManager.IncrementTotalDamageDealt.ToString();
            totalDamageDealt.Color = new Color(124, 93, 72);

            var totalDamageTaken = new TextObject("totalDamageTaken", "Hud", this);
            totalDamageTaken.Text = HighScoreManager.IncrementTotalDamageTaken.ToString();
            totalDamageTaken.Color = new Color(124, 93, 72);

            //create buttons
            var buttonContinue = new ButtonContinue(this, "GSMainMenu");
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
            highScore.Scale = 2;
        }
    }
}
