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
    partial class World : ObjectList, IControlledLoopObject
    {
        private bool _isTopDown;
        private List<Object> _collisionObjects;
        private List<Character> _characters;
        private Vector2 _cameraPosition;
        private int _tileSize;
        private Character _player;
        private bool _canUpdate;

        //physics
        private float _gravity;

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

        public List<Character> Characters
        {
            get { return _characters; }
        }

        public int TileSize
        {
            get { return _tileSize; }
            set { _tileSize = value; }
        }

        public Character Player
        {
            get { return _player; }
            set { _player = value; }
        }

        public bool CanUpdate
        {
            set { _canUpdate = value; }
        }

        public List<Object> CollisionObjects
        {
            get { return _collisionObjects; }
        }

        //phyics
        public float Gravity
        {
            get { return _gravity; }
            set { _gravity = value; }
        }

        public World(int width, int height) : base("world", null)
        {
            setBoundingBoxDimensions(width, height);
            _isTopDown = true;
            _collisionObjects = new List<Object>();
            _characters = new List<Character>();
            _cameraPosition = Vector2.Zero;
            _tileSize = 60;
            _gravity = 350f;
            _canUpdate = true;
        }

        public void HandleInput(GameTime gameTime)
        {
            foreach(Character c in _characters)
            {
                c.HandleInput(gameTime);
            }
        }

        public override void Add(Object o)
        {
            if(o is Character)
            {
                _characters.Add(o as Character);
            }
            Objects.Add(o);
        }

        public override void Remove(Object o)
        {
            if(o is Character)
            {
                _characters.Remove(o as Character);
            }
            Objects.Remove(o);
        }

        public override void Reset()
        {
            
        }
    }
}