﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;

namespace Content
{
    class Terror : Engine.NPC
    {
        private int _walkSpeed, _sprintSpeed, _reactionRange, _walkLeftBoundary, _walkRightBoudary;
        private float _walkPath;
        SoundEffect _chillScream;
        SoundEffect _crazyScream;

        public int WalkSpeed
        {
            get { return _walkSpeed; }
        }

        public int SprintSpeed
        {
            get { return _sprintSpeed; }
        }

        public Terror(string id, Engine.Object parent, Engine.SpriteSheet spriteSheet, string chillScreamSFX, string crazyScreamSFX) : base(id, parent, spriteSheet)
        {
            _reactionRange = 250;
            _sprintSpeed = 250;
            _walkSpeed = 25;
            _walkLeftBoundary = -96;
            _walkRightBoudary = 96;
            _chillScream = Engine.GameInstance.AssetManager.GetSoundEffect(chillScreamSFX);
            _crazyScream = Engine.GameInstance.AssetManager.GetSoundEffect(crazyScreamSFX);
        }

        public override void Update(GameTime gameTime)
        {
            int tempSpeed = Speed;
            base.Update(gameTime);
            if (tempSpeed != Speed)
            {
                SoundEffect soundToPlay = Math.Abs(Speed) == _walkSpeed ? _chillScream : _crazyScream;
                soundToPlay.Play();
            }
        }

        protected override void UpdateBehaviour(GameTime gameTime)
        {
            base.UpdateBehaviour(gameTime);
            float elapedTime = (float)gameTime.ElapsedGameTime.Milliseconds / 1000;
            Vector2 distanceToPlayer = World.Player.GlobalPosition - GlobalPosition;
            if (_reactionRange > distanceToPlayer.Length())
            {
                Speed = _sprintSpeed;
                VelocityX = distanceToPlayer.X < 0 ? -_sprintSpeed : _sprintSpeed;
            }
            else
            {
                Speed = _walkSpeed;
                VelocityX = VelocityX < 0 && _walkPath > _walkLeftBoundary ? -_walkSpeed : _walkSpeed;
                VelocityX = VelocityX > 0 && _walkPath < _walkRightBoudary ? _walkSpeed : -_walkSpeed;
                _walkPath += Velocity.X * elapedTime;
            }
        }

        /*
         * moelijkheidsverloop
         * - random jump
         * - increased

        /*
            * ijsberen 1 blokje links, originele positie, een blokje rechts etc.
            * check if can walk
            * check if player is close
            * if so run towards player
            * var walkspeed, var runspeed*/
    }
}
