using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Media;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine
{
    class World : IControlledLoopObject
    {
        private bool _isTopDown;
        private List<Map> _maps;
        private Vector2 _cameraPosition;
        private Vector2 _dimensions;
        private int _tileSize;
        private Character _player;

        public bool IsTopDown
        {
            get { return _isTopDown; }
            set { _isTopDown = value; }
        }

        public Vector2 CameraPosition
        {
            set { _cameraPosition = value; }
            get { return _cameraPosition; }
        }

        public int Width
        {
            get { return (int)_dimensions.X; }
        }

        public int Heigth
        {
            get { return (int)_dimensions.Y; }
        }

        public int TileSize
        {
            get { return _tileSize; }
            set { _tileSize = value; }
        }

        public Character Player
        {
            get { return _player; }
        }

        public World(Character player) : base()
        {
            _player = player;
            _isTopDown = true;
            _maps = new List<Map>();
            _cameraPosition = Vector2.Zero;
            _tileSize = 60;
        }

        public void Reset()
        {

        }

        public void Update(GameTime gameTime)
        {
            foreach(Map m in _maps)
            {
                //Maps get updated, whether they are visible or not
                m.Update(gameTime);
            }
        }

        public void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            foreach(Map m in _maps)
            {
                if (m.Visible)
                { m.Draw(gameTime, spriteBatch); }
            }
        }

        public void HandleInput(GameTime gameTime)
        {
            foreach(Map m in _maps)
            {
                if (m.Visible)
                { m.HandleInput(gameTime); }
            }
        }

        protected void AddMap(Map map)
        {
            _maps.Add(map);
            map.World = this;

            //check if world dimensions should be set
            //only one map can define the world dimensions
            if(map.Width > _dimensions.X)
            {
                _dimensions.X = map.Width;
                _dimensions.Y = map.Height;
            }
        }
    }
}