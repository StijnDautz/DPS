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
        private List<Player> _characters;
        private Vector2 _cameraPosition;
        private int _tileSize;
        private Player _player;
        private GameMode _gameMode;
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

        public List<Player> Characters
        {
            get { return _characters; }
        }

        public int TileSize
        {
            get { return _tileSize; }
            set { _tileSize = value; }
        }

        public Player Player
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

        public GameMode GameMode
        {
            get { return _gameMode; }
        }

        //phyics
        public float Gravity
        {
            get { return _gravity; }
            set { _gravity = value; }
        }

        public World(string id, int width, int height, GameMode gameMode) : base(id, null)
        {
            setBoundingBoxDimensions(width, height);
            _isTopDown = true;
            _collisionObjects = new List<Object>();
            _characters = new List<Player>();
            _cameraPosition = Vector2.Zero;
            _gameMode = gameMode;
            _tileSize = 60;
            _gravity = 350f;
            _canUpdate = true;
        }

        public void HandleInput(GameTime gameTime)
        {
            foreach(Player c in _characters)
            {
                c.HandleInput(gameTime);
            }
        }

        public override void Add(Object o)
        {
            if(o is Player)
            {
                _characters.Add(o as Player);
            }
            Objects.Add(o);
        }

        public override void Remove(Object o)
        {
            if(o is Player)
            {
                _characters.Remove(o as Player);
            }
            Objects.Remove(o);
        }

        public override void Reset()
        {
            
        }
    }
}