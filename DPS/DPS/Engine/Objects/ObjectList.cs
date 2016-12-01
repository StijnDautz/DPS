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
    class ObjectList : Object, IControlledLoopObject
    {
        private List<Object> _objects;

        public List<Object> Objects
        {
            get { return _objects; }
        }

        public ObjectList(string id) : base(id)
        {
            _objects = new List<Object>();
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
            foreach (Object o in Objects)
            {
                o.Update(gameTime);
            }
        }

        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            foreach (Object o in Objects)
            {
                if (o.Visible)
                { o.Draw(gameTime, spriteBatch); }
            }
        }

        public virtual void HandleInput(GameTime gameTime)
        {

        }

        public virtual void Add(Object o)
        {
            o.Parent = this;
            _objects.Add(o);
        }

        public void Remove(Object o)
        {
            _objects.Remove(o);
        }

        public Object Find(string id)
        {
            foreach (Object o in _objects)
            {
                //check wether o is of type ObjectList - if so Search into this 
                if(o is ObjectList)
                {
                    ObjectList subList = o as ObjectList;
                    subList.Find(o.Id);
                }

                if(o.Id == id)
                {
                    return o;
                }
            }
            return null;
        }
    }
}