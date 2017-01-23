using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Engine;

namespace Content
{
    class DungeonWorld1 : Engine.World
    {
        public DungeonWorld1(string id, int width, int height, Engine.GameMode gameMode) : base(id, width, height, gameMode)
        {
            IsTopDown = false;
            //Add player to world
            var player = new Engine.Player("player", this, new SpriteSheetCharacter("Textures/Characters/Character"));
            player.Position = new Microsoft.Xna.Framework.Vector2(960, 21600);//27
            //player.Position = new Microsoft.Xna.Framework.Vector2(41280, 18400);
            Player = player;
            Add(player);

            var zombie = new EnemyZombie("zombie", this, new SpriteSheetZombie("Textures/Characters/IceZombie"), "zombieNormal", "Sound Effects - Zombie scream");
            zombie.Position = new Microsoft.Xna.Framework.Vector2(48700, 9300);
            Add(zombie);

            var snowman = new EnemySnowMan("snowman", this, new SpriteSheetSnowMan("Textures/Characters/SnowmanThrower"));
            snowman.Position = new Microsoft.Xna.Framework.Vector2(48400, 8900);
            Add(snowman);

            //Items to progress in the Dungeon
            Pickup SnowShoes = new Pickup("SnowShoes", World, new SpriteSheet("Textures/Items/SnowShoes"), "Capable of walking on Ice");
            Add(SnowShoes);
            UpgradePickup RocketCape = new UpgradePickup("Rocketcape", World, new SpriteSheet("Textures/Items/Rocketcape"), "Cape making high jumps possible");
            Add(RocketCape);
            Pickup Key1 = new Pickup("Hallowed_Key", World, new SpriteSheet("Textures/Items/Hallowed_Key"), "First ket in the Dungeon");
            Add(Key1);
            Pickup Key2 = new Pickup("Frozen_Key", World, new SpriteSheet("Textures/Items/Frozen_Key"), "Second key in the Dungeon");
            Add(Key2);
            Pickup Key3 = new Pickup("SkeletonKey", World, new SpriteSheet("Textures/Items/SkeletonKey"), "Final key in the Dungeon");
            Add(Key3);
            Pickup Presents = new Pickup("BluePresent", World, new SpriteSheet("Textures/Items/BluePresent"), "Present to break certain blocks");
            Add(Presents);

            //Setup LevelGrid
            ObjectGrid levelGrid = new ObjectGrid("levelGrid", this, 49, 29, 1920, 960);

            #region Grid
            string[,] grid = new string[49, 29];
            #region Backup
            //grid[25, 9] = "1";
            //grid[26, 9] = "2";
            //grid[28, 9] = "3";
            //grid[31, 9] = "4";
            //grid[33, 7] = "5";
            //grid[39, 7] = "6";
            //grid[38, 9] = "7";
            //grid[40, 9] = "8";
            //grid[41, 10] = "9";
            //grid[42, 8] = "10";
            //grid[41, 12] = "11";
            //grid[46, 8] = "12";
            //grid[46, 12] = "13";
            //grid[37, 9] = "14";
            //grid[34, 11] = "15";
            //grid[34, 12] = "16";
            //grid[32, 13] = "17";
            //grid[31, 11] = "18";
            //grid[29, 13] = "19";
            //grid[29, 14] = "20";
            //grid[28, 14] = "21";
            //grid[27, 11] = "22";
            //grid[24, 9] = "23";
            //grid[25, 19] = "24";
            //grid[26, 19] = "25";
            //grid[28, 19] = "26";
            //grid[28, 21] = "27";
            //grid[30, 18] = "28";
            //grid[33, 18] = "29";
            //grid[35, 14] = "30";
            //grid[36, 14] = "31";
            //grid[38, 14] = "32";
            //grid[37, 16] = "33";
            //grid[38, 18] = "34";
            //grid[37, 19] = "35";
            //grid[36, 19] = "36";
            //grid[33, 20] = "37";
            //grid[33, 21] = "38";
            //grid[40, 21] = "39";
            //grid[39, 26] = "40";
            //grid[38, 24] = "41";
            //grid[37, 24] = "42";
            //grid[31, 25] = "43";
            //grid[30, 24] = "44";
            //grid[31, 27] = "45";
            //grid[28, 26] = "46";
            //grid[27, 27] = "47";
            //grid[25, 27] = "48";
            //grid[24, 28] = "49";
            //grid[22, 19] = "50";
            //grid[22, 13] = "90";
            //grid[42, 23] = "91";
            //grid[43, 23] = "92";
            //grid[46, 24] = "93";
            //grid[47, 24] = "94";
            //grid[48, 24] = "95";
            //grid[45, 26] = "96";
            //grid[43, 25] = "97";
            //grid[43, 24] = "98";
            //grid[21, 12] = "51.1";
            //grid[21, 13] = "51.2";
            //grid[21, 14] = "51.3";
            //grid[21, 15] = "51.4";
            //grid[21, 16] = "51.5";
            //grid[21, 17] = "51.6";
            //grid[21, 18] = "51.7";
            //grid[21, 19] = "51.8";
            //grid[17, 6] = "52";
            //grid[14, 5] = "53";
            //grid[12, 6] = "54.1";
            //grid[13, 6] = "54.2";
            //grid[16, 7] = "55.1";
            //grid[16, 8] = "55.2";
            //grid[17, 8] = "56";
            //grid[18, 7] = "57";
            //grid[14, 8] = "58.1";
            //grid[15, 8] = "58.2";
            //grid[13, 8] = "59.1";
            //grid[13, 9] = "59.2";
            //grid[13, 10] = "59.3";
            //grid[14, 10] = "60.1";
            //grid[15, 10] = "60.2";
            //grid[16, 10] = "60.3";
            //grid[17, 10] = "61";
            //grid[16, 11] = "62.1";
            //grid[16, 12] = "62.2";
            //grid[17, 12] = "63.1";
            //grid[18, 12] = "63.2";
            //grid[18, 13] = "63.3";
            //grid[19, 13] = "63.4";
            //grid[20, 13] = "63.5";
            //grid[16, 19] = "64.1";
            //grid[17, 19] = "64.2";
            //grid[18, 19] = "64.3";
            //grid[19, 19] = "64.4";
            //grid[20, 19] = "64.5";
            //grid[15, 17] = "65.1";
            //grid[15, 18] = "65.2";
            //grid[15, 19] = "65.3";
            //grid[15, 20] = "65.4";
            //grid[15, 21] = "65.5";
            //grid[16, 17] = "66.1";
            //grid[17, 17] = "66.2";
            //grid[18, 16] = "67.1";
            //grid[18, 17] = "67.2";
            //grid[17, 16] = "68";
            //grid[19, 16] = "69.1";
            //grid[20, 16] = "69.2";
            //grid[15, 12] = "70.1";
            //grid[15, 13] = "70.2";
            //grid[15, 14] = "70.3";
            //grid[13, 14] = "71.1";
            //grid[14, 14] = "71.2";
            //grid[12, 14] = "72.1";
            //grid[12, 15] = "72.2";
            //grid[12, 16] = "72.3";
            //grid[10, 16] = "73.1";
            //grid[11, 16] = "73.2";
            //grid[7, 14] = "74";
            //grid[6, 14] = "75";
            //grid[6, 16] = "76.1";
            //grid[6, 17] = "76.2";
            //grid[6, 18] = "76.3";
            //grid[6, 20] = "76.4";
            //grid[5, 19] = "77";
            //grid[2, 17] = "78";
            //grid[1, 19] = "79";
            //grid[0, 19] = "80.1";
            //grid[0, 20] = "80.2";
            //grid[0, 21] = "80.3";
            //grid[0, 22] = "80.4";
            //grid[1, 22] = "81";
            //grid[2, 21] = "82.1";
            //grid[2, 22] = "82.2";
            //grid[3, 21] = "83.1";
            //grid[4, 21] = "83.2";
            //grid[5, 21] = "84.1";
            //grid[5, 22] = "84.2";
            //grid[6, 22] = "85";
            //grid[7, 21] = "86.1";
            //grid[7, 22] = "86.2";
            //grid[8, 21] = "87.1";
            //grid[9, 21] = "87.2";
            //grid[10, 20] = "88";
            //grid[13, 21] = "89.1";
            //grid[14, 21] = "89.2";
            //grid[15, 1] = "99.1";
            //grid[15, 2] = "99.2";
            //grid[15, 3] = "99.3";
            //grid[15, 4] = "99.4";
            //grid[15, 0] = "100";
            #endregion

            grid[21, 12] = "1";
            grid[21, 13] = "2";
            grid[21, 14] = "3";
            grid[21, 15] = "4";
            grid[21, 16] = "5";
            grid[21, 17] = "6";
            grid[21, 18] = "7";
            grid[21, 19] = "8";
            grid[17, 6] = "9";
            grid[14, 5] = "10";
            grid[12, 6] = "11";
            grid[13, 6] = "12";
            grid[16, 7] = "13";
            grid[16, 8] = "14";
            grid[17, 8] = "15";
            grid[18, 7] = "16";
            grid[14, 8] = "17";
            grid[15, 8] = "18";
            grid[13, 8] = "19";
            grid[13, 9] = "20";
            grid[13, 10] = "21";
            grid[14, 10] = "22";
            grid[15, 10] = "23";
            grid[16, 10] = "24";
            grid[17, 10] = "25";
            grid[16, 11] = "26";
            grid[16, 12] = "27";
            grid[17, 12] = "28";
            grid[18, 12] = "29";
            grid[18, 13] = "30";
            grid[19, 13] = "31";
            grid[20, 13] = "32";
            grid[16, 19] = "33";
            grid[17, 19] = "34";
            grid[18, 19] = "35";
            grid[19, 19] = "36";
            grid[20, 19] = "37";
            grid[15, 17] = "38";
            grid[15, 18] = "39";
            grid[15, 19] = "40";
            grid[15, 20] = "41";
            grid[15, 21] = "42";
            grid[16, 17] = "43";
            grid[17, 17] = "44";
            grid[18, 16] = "45";
            grid[18, 17] = "46";
            grid[17, 16] = "47";
            grid[19, 16] = "48";
            grid[20, 16] = "49";
            grid[15, 12] = "50";
            grid[15, 13] = "51";
            grid[15, 14] = "52";
            grid[13, 14] = "53";
            grid[14, 14] = "54";
            grid[12, 14] = "55";
            grid[12, 15] = "56";
            grid[12, 16] = "57";
            grid[10, 16] = "58";
            grid[11, 16] = "59";
            grid[7, 14] = "60";
            grid[6, 14] = "61";
            grid[6, 16] = "62";
            grid[6, 17] = "63";
            grid[6, 18] = "64";
            grid[6, 19] = "65";
            grid[5, 19] = "66";
            grid[2, 17] = "67";
            grid[1, 19] = "68";
            grid[0, 19] = "69";
            grid[0, 20] = "70";
            grid[0, 21] = "71";
            grid[0, 22] = "72";
            grid[1, 22] = "73";
            grid[2, 21] = "74";
            grid[2, 22] = "75";
            grid[3, 21] = "76";
            grid[4, 21] = "77";
            grid[5, 21] = "78";
            grid[5, 22] = "79";
            grid[6, 22] = "80";
            grid[7, 21] = "81";
            grid[7, 22] = "82";
            grid[8, 21] = "83";
            grid[9, 21] = "84";
            grid[10, 20] = "85";
            grid[13, 21] = "86";
            grid[14, 21] = "87";
            grid[15, 1] = "88";
            grid[15, 2] = "89";
            grid[15, 3] = "90";
            grid[15, 4] = "91";
            grid[15, 0] = "92";
            #endregion

            //create randomDungeonGenerator
            RandomDungeonGenerator dungeonGenerator = new RandomDungeonGenerator();

            for (int i = 1; i < 93; i++)
            {
                Level1 room = new Level1("level1", levelGrid, i.ToString(), 96);
                for (int x = 0; x < 49; x++)
                {
                    for (int y = 0; y < 29; y++)
                    {
                        if (grid[x, y] != null && int.Parse(grid[x, y]) == i)
                        {
                            room.PositionX = x * 20 * 96;
                            room.PositionY = y * 10 * 96;
                            levelGrid.setTile(x, y, room);
                        }
                    }
                }
                room.CanCollide = true;
            }
            levelGrid.CanCollide = true;
            Add(levelGrid);
        }
    }
}