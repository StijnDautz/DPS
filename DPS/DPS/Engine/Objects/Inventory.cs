using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine
{
    class Inventory : ObjectList 
    {
        private ObjectGrid _grid;
        private Weapon _strongestWeapon;
        private Weapon _equipedWeapon;

        public Weapon EquipedWeapon
        {
            get { return _equipedWeapon; }
        }

        public Inventory(string id) : base (id)
        {
            _grid = new ObjectGrid("inventorygrid", 5, 5, 60);
            Add(_grid);
            _strongestWeapon = FindStrongestWeapon();
            _equipedWeapon = _strongestWeapon;
        }

        public bool AddPickup(Pickup o)
        {
            if(o is Weapon)
            {
                Weapon w = o as Weapon;
                if(_strongestWeapon == null || w.Damage > _strongestWeapon.Damage)
                {
                    _strongestWeapon = w;
                }
            }
            return _grid.AddToFirstFreeSpot(o);
        }

        public void RemovePickup(Pickup o)
        {
            if (o is Weapon)
            {
                Weapon w = o as Weapon;
                if (w.Damage == _strongestWeapon.Damage)
                {
                    _strongestWeapon = FindStrongestWeapon();
                }
            }
            _grid.RemoveObject(o);
        }

        public void MovePickup(Pickup movingPickup, Vector2 MousePosition)
        {
            Point p = _grid.GetPositionInGrid(MousePosition);
            Pickup switchPickup = _grid.getTile(p) as Pickup;

            if(switchPickup == null)
            {
                _grid.setTile(p.X, p.Y, movingPickup);
            }
            else
            {
                SwapPickup(p, _grid.GetPositionInGrid(movingPickup));
            }
        }

        public void SwapPickup(Point o, Point swappickup)
        {
            _grid.SwapObjects(o, swappickup);
        }

        public Weapon FindStrongestWeapon()
        {
            Weapon strongest = null;
            foreach(Object o in Objects)
            {
                if(o is Weapon)
                {
                    Weapon w = o as Weapon;
                    if(strongest == null || w.Damage > strongest.Damage)
                    {
                        strongest = w;
                    }
                }
            }
            return strongest;
        }
    }
}