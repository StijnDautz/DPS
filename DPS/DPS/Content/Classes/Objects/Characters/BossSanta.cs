using Engine;
using Microsoft.Xna.Framework;

namespace Content
{
    class BossSanta : Enemy
    {
        private Weapon _weaponRunOver;
        private int _runOverET, _bulletET, _bombET, _runOverTime;
        bool runningOver;
        
        public BossSanta(Engine.Object parent) : base("bossSanta", parent, new SpriteSheet(""))
        {

        }

        protected override void UpdateBehaviour(GameTime gameTime)
        {
            base.UpdateBehaviour(gameTime);
            int elapsedTime = gameTime.ElapsedGameTime.Milliseconds;

            //get distance to player
            var distanceToPlayer = World.Player.GlobalPosition - GlobalPosition;

            if (!runningOver && !IsStaggered)
            {
                //if santa is not trying to run player over, update weapon elapsedtimes
                _runOverET += elapsedTime;
                _bulletET += elapsedTime;
                _bombET += elapsedTime;
               
                //if enough time has passed to try to run the player over
                if(_runOverET > _runOverTime)
                {
                    //determine direction to go based on player position
                    VelocityX = distanceToPlayer.X < 0 ? -300 : 300;

                    //set runningOver true, this is set to false when on x axis is detected
                    runningOver = true;
                }
            }



        }

        public override void OnDeath()
        {
            base.OnDeath();
            World.GameMode.GameStateManager.SwitchTo("GSGameFinished");
        }
    }
}
