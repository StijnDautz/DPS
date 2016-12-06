using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Engine
{
    class Pickup : TexturedObject
    {
        Pickup(string id, string assetName) : base(id, assetName)
        {
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);

            Vector2 playerpos = new Vector2(12, 12);//moet met speler locatie gelinkt worden
            bool inventoryfull = false; //linken met inventory, als aantal items

            if (playerpos.X > _itempos.X && playerpos.X < _itempos.X + itemsize && playerpos.Y > _itempos.Y && playerpos.Y < _itempos.Y + itemsize && inventoryfull == false)
            {
                _visible = false;
                //(add item to objectgrid inventory)
            }

        }

        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            base.Draw(gameTime, spriteBatch);
            Texture2D idtexture = nonexistent;

            bool visible = true;
            Vector2 _itempos = new Vector2(12, 12);//staat bij pickup als parameter
            int animationoffset = 10;
            double anisin = 0 + 0.25 * Math.PI;

            if (onground == true)
            spriteBatch.Draw(idtexture, new Vector2(_itempos.X, _itempos.Y + (float)Math.Sin(anisin) * animationoffset), Color.White);
        }
    }
}
