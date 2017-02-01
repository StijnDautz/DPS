using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using System.Collections.Generic;

namespace Engine
{
    class SFXManager
    {
        Dictionary<string, SFX> _soundEffects;
        SFX _playingSFX;
        SoundEffectInstance _playingSFXInstance;
        Object _source;
        private bool _canUpdate;
        private static float _volumeModifier;

        public struct SFX
        {
            public string name;
            public SoundEffect sfx;
            public bool loop;

            public SFX(string Name, SoundEffect Sfx, bool Loop)
            {
                name = Name;
                sfx = Sfx;
                loop = Loop;
            }
        }

        protected Object Source
        {
            get { return _source; }
        }

        protected SFX PlayingSFX
        {
            get { return _playingSFX; }
        }

        public static float VolumeModifier
        {
            set { _volumeModifier = value; }
        }

        public SFXManager(Object source)
        {
            _soundEffects = new Dictionary<string, SFX>();
            _source = source;
            _canUpdate = true;
            _volumeModifier = 1;
        }

        public void Update(GameTime gameTime, Character character)
        {
            if (_playingSFXInstance != null)
            {
                //when SFX doesnt loop and it has stopped playing, canupdate is true and call AtEndSFX()
                if (!_playingSFX.loop && _playingSFXInstance.State == SoundState.Stopped)
                {
                    AtEndSFX();
                    _canUpdate = true;
                }
                UpdateVolume(character);
            }
            if (_canUpdate)
            {
                string newSFX = UpdateSFX();
                if(newSFX != "")
                {
                    if (_playingSFXInstance == null || (newSFX != _playingSFX.name && _playingSFX.loop) || (!_playingSFX.loop  && _playingSFXInstance.State == SoundState.Stopped))
                    {
                        SwitchTo(newSFX);
                    }
                }
            }
        }

        protected void Add(string name, SoundEffect sfx, bool loop)
        {
            _soundEffects.Add(name, new SFX(name, sfx, loop));
        }

        protected virtual string UpdateSFX()
        {
            return null;
        }

        protected void SwitchTo(string id)
        {
            if(_playingSFXInstance != null)
            {
                _playingSFXInstance.Stop();
            }
            _playingSFX = _soundEffects[id];
            _playingSFXInstance = _playingSFX.sfx.CreateInstance();
            _playingSFXInstance.Play();
            _playingSFXInstance.IsLooped = _playingSFX.loop;
        }

        protected SoundEffect getSFX(string assetName)
        {
            return GameInstance.AssetManager.GetSoundEffect(assetName);
        }

        private void UpdateVolume(Character character)
        {
            //calculate distance, + 1 to avoid division by 0
            float distance = (character.GlobalPosition - _source.GlobalPosition).Length() + 1;

            //calculate volume based on settings and on distance from source
            float volume = 230 * _volumeModifier / distance;

            //if volume is too low, stop _playingSFXInstance, as it wont be heard anyway and there's a maximum on sfxs played simultaneously
            if (volume < 0.1)
            {
                _playingSFXInstance.Stop();
            }
            //make sure volume max = 1, as volume has to be an value from 0 to 1
            else if (volume > 1)
            {
                volume = 1;
            }
            else
            {
                _playingSFXInstance.Volume = volume;
            }
        }

        protected virtual void AtEndSFX()
        {

        }

    }
}