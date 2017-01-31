using Engine;
using Microsoft.Xna.Framework;

namespace Content
{
    class BossSanta : Enemy
    {
        private int _runOverET, _bombET, _bulletET, _runOverTime, _bombTime, _bulletTime, _movementSpeed;
        bool runningOver;
        
        public BossSanta(Object parent) : base("bossSanta", parent, new SpriteSheet("Textures/Characters/SantaBoss"))
        {
            _runOverTime = 12000;
            _bombTime = 5000;
            _bulletTime = 700;
            _movementSpeed = 25;
        }

        protected override void UpdateBehaviour(GameTime gameTime)
        {
            base.UpdateBehaviour(gameTime);
            int elapsedTime = gameTime.ElapsedGameTime.Milliseconds;

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
            VelocityX = distanceToPlayerX < 0 ? -300 : 300;

            //set runningOver true, this is set to false when on x axis is detected
            runningOver = true;
        }

        private void BombAttack()
        {
            var bomb = new WeaponBomb(World, this);
            int x = Mirrored ? 300 : -300;
            Velocity = new Vector2(x, 400);
            World.Add(bomb);
        }

        private void BulletAttack()
        {
            var bullet = new WeaponThrowable("bullet", World, new SpriteSheet("Textures/Weapons/Bullet"), this, 50);
            bullet.DestroyOnCollision = true;
            int x = Mirrored ? 600 : -600;
            bullet.VelocityX = x;
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
            //TODO check if collision was on x axis
            if(CollisionHelper.CollidesWith(this, new Vector2(Velocity.X, 0), collider, Vector2.Zero, 0.016f))
            {
                runningOver = false;

                if (collider is Character)
                {
                    var character = collider as Character;
                    character.IsStaggered = true;
                    character.Health -= 200;

                    //add knockback effect on hit
                    character.Velocity = collider.GlobalPosition.X > GlobalPosition.X ? new Vector2(300, 200) : new Vector2(-300, 200);
                }
                else
                {
                    IsStaggered = true;
                }
            }
        }
    }
}