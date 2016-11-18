using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace DPS
{
    class ObjectList : Object
    {
        private List<Object> _objects;

        public List<Object> Objects
        {
            get { return _objects; }
        }

        public ObjectList(string id) : base(id)
        {

        }

        public override void Update(GameTime gameTime)
        {
            foreach(Object o in _objects)
            {
                o.Update(gameTime);
            }
        }

        public override void Draw(GameTime gameTime)
        {
            foreach(Object o in _objects)
            {
                o.Draw(gameTime);
            }
        }

        public override void Reset()
        {
            foreach(Object o in _objects)
            {
                o.Reset();
            }
        }

        public void Add(Object o)
        {
            _objects.Add(o);
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