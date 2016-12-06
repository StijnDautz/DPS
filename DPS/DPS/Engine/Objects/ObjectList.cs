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
        private List<Pawn> _pawns;

        public List<Object> Objects
        {
            get { return _objects; }
        }

        public List<Pawn> Pawns
        {
            get { return _pawns; }
        }
        
        public ObjectList(string id) : base(id)
        {
            _objects = new List<Object>();
            _pawns = new List<Pawn>();
        }

        public override void Reset()
        {
            foreach(Object o in Objects)
            {
                o.Reset();
            }
            foreach(Pawn p in _pawns)
            {
                if(p.Visible)
                {
                    p.Reset();
                }
            }
        }

        public override void Update(GameTime gameTime)
        {
            foreach(Object o in _objects)
            {
                if(o.Visible)
                {
                    o.Update(gameTime);
                }
            }
            foreach(Pawn p in _pawns)
            {
                if(p.Visible)
                {
                    p.Update(gameTime);
                }
            }
        }

        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            foreach(Object o in Objects)
            {
                if (o.Visible)
                {
                    o.Draw(gameTime, spriteBatch);
                }
            }
            foreach(Pawn p in _pawns)
            {
                if(p.Visible)
                {
                    p.Draw(gameTime, spriteBatch);
                }
            }
        }

        public virtual void HandleInput(GameTime gameTime)
        {
            foreach(Pawn p in _pawns)
            {
                if(p.Visible)
                {
                    p.HandleInput(gameTime);
                }
            }
        }

        public virtual void Add(Object o)
        {
            o.Parent = this;
            //if object is Pawn add it to list of pawns, which is used to prevent unnecessary calls of HandleInput(gameTime)
            if (o is Pawn)
            {
                Pawn p = o as Pawn;
                _pawns.Add(p);
            }
            else
            {
                _objects.Add(o);
            }
        }

        public void Remove(Object o)
        {
            if (o is Pawn)
            {
                Pawn p = o as Pawn;
                _pawns.Remove(p);
            }
            else
            {
                _objects.Remove(o);
            }
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