using Engine;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Content
{
    class MainWorld : World
    {
        public MainWorld(string id, int width, int height, GameMode gameMode) : base(id, width, height, gameMode)
        {
            IsTopDown = true;
            CanUpdate = true;

            Overworld grid = new Overworld("mainGrid", this, "OverWorld", 96);
            grid.CanCollide = true;
            Add(grid);
            
            Player player = new Player("player", this, new SpriteSheet("Textures/Tiles/a.Overworld"));
            player.CanCollide = true;
            player.Position = new Vector2(300, 300);

           // player.BoundingBox = new Rectangle((int)player.Position.X, (int)player.Position.Y, 1, 1);
            Add(player);
            Player = player;
        }
    }
}