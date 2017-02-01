using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Media;

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
            return _contentManager.Load<Song>("Soundeffects/" + assetName);
        }

        public SoundEffect GetSoundEffect(string assetName)
        {
           return _contentManager.Load<SoundEffect>("Soundeffects/" + assetName);
        }
    }
}