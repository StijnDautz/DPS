using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Engine
{
    /*
     * As ObjectList is an Object and override Reset, Update and Draw.
     * Is: if(o is ObjectList) really necessary?
     */
    class ObjectList : Object
    {
        private List<Object> _objects;

        public List<Object> Objects
        {
            get { return _objects; }
        }

        public ObjectList(string id, Object parent) : base(id, parent)
        {
            _objects = new List<Object>();
        }

        public ObjectList(string id, Object parent, int size) : base(id, parent)
        {
            _objects = new List<Object>(size);
            for(int i = 0; i < size; i++)
            {
                _objects.Add(null);
            }
        }

        public override void Reset()
        {
            foreach (Object o in Objects)
            {
                o.Reset();
            }
        }

        public override void Update(GameTime gameTime)
        {
            foreach (Object o in _objects)
            {
                if (o != null)
                {
                    if (o.Visible)
                    {
                        o.Update(gameTime);
                    }
                }
            }
        }

        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            foreach (Object o in _objects)
            {
                if (o != null)
                {
                    if (o.Visible)
                    {
                        o.Draw(gameTime, spriteBatch);
                    }
                }
            }
        }

        public virtual void Add(Object o)
        {
            if(o is Player)
            {
                World.Characters.Add(o as Player);
            }
            _objects.Add(o);
        }

        public virtual void Remove(Object o)
        {
            if(o is Player)
            {
                World.Characters.Remove(o as Player);
            }
            _objects.Remove(o);
        }

        public Object Find(string id)
        {
            foreach (Object o in _objects)
            {
                //check wether o is of type ObjectList - if so Search into this 
                if (o is ObjectList)
                {
                    ObjectList subList = o as ObjectList;
                    subList.Find(o.Id);
                }

                if (o.Id == id)
                {
                    return o;
                }
            }
            return null;
        }

        public override void ApplyPhysics(float elapsedTime)
        {
            if (HasPhysics && !World.IsTopDown)
            {
                foreach (Object o in _objects)
                {
                    o.ApplyPhysics(elapsedTime);
                }
            }    
        }

        public override void SetupCollision(Object collider, float elapsedTime)
        {
            if (collider is ObjectList)
            {
                var col = collider as ObjectList;
                foreach (Object o1 in _objects)
                {
                    foreach (Object o2 in col._objects)
                    {
                        o1.CheckCollision(o2, elapsedTime);
                    }
                }
            }
            else
            {
                foreach (Object o in _objects)
                {
                    o.CheckCollision(collider, elapsedTime);
                }
            }
        }
    }
}