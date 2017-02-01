using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using System.Linq;

namespace Engine
{
    partial class World : ObjectList
    {
        private bool _isTopDown;
        private List<Object> _collisionObjects, _objectsToAdd, _objectsToRemove;
        private List<Player> _characters;
        private Vector2 _cameraPosition;
        private int _tileSize;
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
            get { return _gameMode.Player; }
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

        public World(string id, int width, int height) : base(id, null)
        {
            setBoundingBoxDimensions(width, height);
            _isTopDown = true;
            _collisionObjects = new List<Object>();
            _characters = new List<Player>();
            _objectsToAdd = new List<Object>();
            _objectsToRemove = new List<Object>();
            _cameraPosition = Vector2.Zero;
            _tileSize = 60;
            _gravity = 350f;
            _canUpdate = true;
        }

        public virtual void Setup(GameMode gameMode)
        {
            _gameMode = gameMode;
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
            o.Parent = this;
            _objectsToAdd.Add(o);
        }

        public override void Remove(Object o)
        {
            _objectsToRemove.Add(o);
            o = null;
        }

        public override void Reset()
        {
            foreach(Object o in Objects)
            {
                World.Remove(o);
            }
            World.Setup(_gameMode);
        }

        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            foreach (Object o in Objects)
            {
                if (o.Visible)
                {
                    //if o is objectList, the boundingBox is irrelevant, else check if o is within screen boundaries
                    if (o is ObjectList || !(o.GlobalPosition.X + o.Width < CameraPosition.X || o.GlobalPosition.X > CameraPosition.X + GameInstance.GraphicsDeviceManager.PreferredBackBufferWidth || o.GlobalPosition.Y + o.Height < CameraPosition.Y || o.GlobalPosition.Y > CameraPosition.Y + GameInstance.GraphicsDeviceManager.PreferredBackBufferHeight))
                    {
                        o.Draw(gameTime, spriteBatch);
                    }
                }
            }
        }
    }
}