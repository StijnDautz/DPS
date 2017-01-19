using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Media;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine
{
    class AssetManager
    {
        private ContentManager _contentManager;

        public AssetManager(ContentManager contentManager)
        {
            _contentManager = contentManager;
        }

        public Texture2D GetTexture(string assetName)
        {
            return _contentManager.Load<Texture2D>(assetName);
        }

        public SpriteFont GetFont(string assetName)
        {
            return _contentManager.Load<SpriteFont>(assetName);
        }

        public Song GetSong(string assetName)
        {
            return _contentManager.Load<Song>(assetName);
        }

        public SoundEffect getSoundEffect(string assetName)
        {
           return _contentManager.Load<SoundEffect>(assetName);
        }
    }
}
