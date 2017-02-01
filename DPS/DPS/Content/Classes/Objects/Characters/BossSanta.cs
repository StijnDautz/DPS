using Engine;
using Microsoft.Xna.Framework;

namespace Content
{
    class BossSanta : Enemy
    {
        private int _runOverET, _bombET, _bulletET, _runOverTime, _bombTime, _bulletTime, _movementSpeed;
        private bool runningOver;
        private float _runOverVelocityX;
        
        public BossSanta(Object parent) : base("bossSanta", parent, new SpriteSheetSanta())
        {
            _runOverTime = 12000;
            _bombTime = 8000;
            _bulletTime = 2400;
            _movementSpeed = 25;
            Health = 1500;
            Mass = 2;
            StaggerDuration = 1900;
        }

        public override void Reset()
        {
            base.Reset();
            Health = 1500;      
        }

        protected override void UpdateBehaviour(GameTime gameTime)
        {
            base.UpdateBehaviour(gameTime);
            int elapsedTime = gameTime.ElapsedGameTime.Milliseconds;

            //if runningOver there is a constant amount of power, so santa does not slow down
            if(runningOver)
            {
                Velocity = new Vector2(_runOverVelocityX, Velocity.Y);
            }
            
            if (!runningOver && !IsStaggered)
            {
                //if santa is not trying to run player over, update weapon elapsedtimes
                _runOverET += elapsedTime;
                _bulletET += elapsedTime;
                _bombET += elapsedTime;

                //get distanceToPlayer
                var distanceToPlayerX = (World.Player.GlobalPosition - GlobalPosition).X;

                //update movement
                UpdateMovement(distanceToPlayerX);

                //if enough time has passed to try to run the player over
                if (_runOverET > _runOverTime)
                {
                    RunOverAttack(distanceToPlayerX);
                    _runOverET = 0;
                }
                else if(_bombET > _bombTime)
                {
                    BombAttack();
                    _bombET = 0;
                }
                else if(_bulletET > _bulletTime)
                {
                    BulletAttack();
                    _bulletET = 0;
                }
            }
        }

        private void RunOverAttack(float distanceToPlayerX)
        {
            //determine direction to go based on player position
            _runOverVelocityX = distanceToPlayerX < 0 ? -700 : 700;

            //set runningOver true, this is set to false when on x axis is detected
            runningOver = true;
        }

        private void BombAttack()
        {
            var bomb = new WeaponBomb(World, this);
            int x = Mirrored ? 1000 : -1000;
            bomb.Velocity = new Vector2(x, -200);
            bomb.Position = Mirrored ? Position : new Vector2(Position.X + Width, Position.Y);
            bomb.Mass = 1.4f;
            World.Add(bomb);
        }

        private void BulletAttack()
        {
            var bullet = new WeaponThrowable("bullet", World, new SpriteSheetBullet(), this, 250);
            bullet.DestroyOnCollision = true;
            int x = Mirrored ? 600 : -600;
            bullet.VelocityX = x;
            bullet.Position = Mirrored ? new Vector2(Position.X + 100, Position.Y + 90) : new Vector2(Position.X - 40, Position.Y + 90);
            bullet.Mirrored = Mirrored ? true : false;
            World.Add(bullet);
        }

        private void UpdateMovement(float distanceToPlayerX)
        {
            VelocityX = distanceToPlayerX < 0 ? -_movementSpeed : _movementSpeed;
        }

        public override void OnDeath()
        {
            base.OnDeath();
            World.GameMode.GameStateManager.SwitchTo("GSGameFinished");
        }

        public override void OnCollision(Object collider)
        {
            base.OnCollision(collider);
            if(!(collider is Weapon) && CollisionHelper.CollidesWith(this, new Vector2(Velocity.X, 0), collider, Vector2.Zero, 0.016f))
            {
                runningOver = false;

                if (collider != this)
                {
                    if (collider is Character)
                    {
                        var character = collider as Character;
                        character.IsStaggered = true;
                        character.Health -= 200;

                        HighScoreManager.IncrementTotalDamageTaken = 600;

                        //add knockback effect on hit
                        character.Velocity = collider.GlobalPosition.X > GlobalPosition.X ? new Vector2(600, -300) : new Vector2(-600, -300);
                    }
                    else
                    {
                        IsStaggered = true;
                    }
                }
            }
        }
    }
}