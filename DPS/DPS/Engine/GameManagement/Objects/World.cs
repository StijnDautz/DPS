using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Media;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine
{
    abstract partial class World : ObjectList
    {
        private bool _isTopDown;
        private List<string> _songs;
        private int _currentSong;

        public bool IsTopDown
        {
            get { return _isTopDown; }
            set { _isTopDown = value; }
        }

        public World(string id, string assetName) : base(id)
        {
            _isTopDown = true;
        }

        public override void Update(GameTime gameTime)
        {
            UpdateMusicPlayer();
        }

        private void UpdateMusicPlayer()
        {
            if(MediaPlayer.State == MediaState.Stopped)
            {
                _currentSong++;
                MediaPlayer.Play(GameInstance.assetManager.GetSong(_songs[_currentSong]));
            }
        }

    }
}
