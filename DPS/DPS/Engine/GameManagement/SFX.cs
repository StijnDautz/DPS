using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine
{
    class SFX
    {
        Dictionary<string, SoundEffect> _soundEffects;
        SoundEffectInstance _playingSFX;
        Object _source;

        public SFX(Object source)
        {
            _soundEffects = new Dictionary<string, SoundEffect>();
            _source = source;
        }

        public void Update(GameTime gameTime, Character character)
        {
            if (_playingSFX != null)
            {
                float distance = (character.GlobalPosition - _source.GlobalPosition).Length();
                if (distance == 0)
                {
                    distance += .1f;
                }
                float volume = 100 / distance;
                if (volume < 0.1)
                {
                    _playingSFX.Stop();
                }
                else if(volume > 1)
                {
                    volume = 1;
                }
                else
                {
                    _playingSFX.Volume = volume;
                }
            }
        }

        public void Add(string id, SoundEffect sfx)
        {
            _soundEffects.Add(id, sfx);
        }

        public void SwitchTo(string id)
        {
            if(_playingSFX != null)
            {
                _playingSFX.Stop();
            }
            _playingSFX = _soundEffects[id].CreateInstance();
            _playingSFX.Play();
            _playingSFX.IsLooped = true;
        }
    }
}
