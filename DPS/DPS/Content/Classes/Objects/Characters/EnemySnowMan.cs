﻿using Microsoft.Xna.Framework;

namespace Content
{
    class EnemySnowMan : Enemy
    {
        private int _reactionRange;
        private Vector2 _distanceToPlayer;

        public EnemySnowMan(Engine.Object parent) : base("enemySnowMan", parent, new SpriteSheetSnowMan("Textures/Characters/SnowmanThrower"))
        {
            _reactionRange = 1500;
            AttackSpeed = 1800;
            Damage = 100;
            Health = 500;
            Mass = 2;
            SFXManager = new SFXSnowMan(this);
            BoundingBox = new Rectangle(0, 0, 112, 116);
            StaggerDuration = 2000;
        }

        protected override void UpdateBehaviour(GameTime gameTime)
        {
            base.UpdateBehaviour(gameTime);

            //if not staggered set value of try to attack
            if (!IsStaggered)
            {
                //update distance to player
                _distanceToPlayer = World.Player.GlobalPosition - GlobalOrigin;
                //enemy tries to attack when player is in range
                TryAttack = _reactionRange > _distanceToPlayer.Length();
            }
        }

        protected override void OnAttack()
        {
            base.OnAttack();
            //setup weapon
            var snowball = new WeaponSnowBall("snowball", World, new Engine.SpriteSheet("Textures/Weapons/Snowball"), this, Damage);
            snowball.Position = Mirrored ? new Vector2(PositionX, PositionY + 30) : new Vector2(PositionX + Width - 20, PositionY + 30);

            //setup snowball velocity
            _distanceToPlayer.Normalize();
            snowball.Velocity = _distanceToPlayer * 800;
            World.Add(snowball);
        }

        public override void ScaleStatsWithHighScore(float highScoreModifier)
        {
            base.ScaleStatsWithHighScore(highScoreModifier);
            Damage = (int)(Damage * highScoreModifier);
            Health = (int)(Health * highScoreModifier);
        }
    }
}
