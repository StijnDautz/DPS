using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine
{
    partial class ObjectGrid
    {
        public void Load(string assetName)
        {
            ReadTiles(ReadFile(assetName), assetName);
        }

        private List<string> ReadFile(string assetName)
        {
            StreamReader stream = new StreamReader("Content/Maps/" + assetName + ".txt");
            List<string> lines = new List<string>();

            //read lines from file
            string line = stream.ReadLine();
            while (line != null)
            {
                lines.Add(line);
                line = stream.ReadLine();
            }
            return lines;
        }

        private void ReadTiles(List<string> lines, string assetName)
        {
            if (lines.Count != 0)
            {
                _collums = lines[0].Length;
                _rows = lines.Count;
                _grid = new Object[_collums, _rows];
            }
            else
            {
                RandomDungeonGenerator generator = new RandomDungeonGenerator();

                switch (assetName)
                {
                    case "10":
                        generator.Height = 20;
                        generator.Width = 60;
                        Door door1 = new Door(), door2 = new Door(), door3 = new Door(), door4 = new Door();
                        door1.location = new Vector2(0, 14);
                        door1.direc = Door.direction.right;
                        door2.location = new Vector2(58, 13);
                        door2.direc = Door.direction.left;
                        door3.location = new Vector2(28, 0);
                        door3.direc = Door.direction.up;
                        door4.location = new Vector2(48, 19);
                        door4.direc = Door.direction.down;
                        generator.Doors.Add(door1);
                        generator.Doors.Add(door2);
                        generator.Doors.Add(door3);
                        generator.Doors.Add(door4);
                        break;
                    case "16":
                        generator.Height = 20;
                        generator.Width = 40;
                        Door door5 = new Door();
                        door5.location = new Vector2(0, 14);
                        door5.direc = Door.direction.right;
                        generator.Doors.Add(door5);
                        break;
                    case "60":
                        generator.Height = 30;
                        generator.Width = 60;
                        Door door6 = new Door(), door7 = new Door(), door8 = new Door();
                        door6.location = new Vector2(58, 23);
                        door6.direc = Door.direction.left;
                        door7.location = new Vector2(0, 23);
                        door7.direc = Door.direction.right;
                        door8.location = new Vector2(0, 3);
                        door8.direc = Door.direction.right;

                        generator.Doors.Add(door6);
                        generator.Doors.Add(door7);
                        generator.Doors.Add(door8);

                        break;
                    case "67":
                        generator.Height = 30;
                        generator.Width = 60;

                        Door door9 = new Door(), door10 = new Door();
                        door9.location = new Vector2(58, 24);
                        door9.direc = Door.direction.left;
                        door10.location = new Vector2(0, 24);
                        door10.direc = Door.direction.right;



                        generator.Doors.Add(door9);
                        generator.Doors.Add(door10);

                        break;
                    case "85":
                        generator.Height = 20;
                        generator.Width = 60;
                        Door door11 = new Door(), door12 = new Door();

                        door11.location = new Vector2(58, 13);
                        door11.direc = Door.direction.left;
                        door12.location = new Vector2(0, 13);
                        door12.direc = Door.direction.right;

                        generator.Doors.Add(door11);
                        generator.Doors.Add(door12);
                        break;

                    case "92":
                        generator.Height = 10;
                        generator.Width = 20;
                        Door door13 = new Door();
                        door13.location = new Vector2(8, 9);
                        door13.direc = Door.direction.down;
                        generator.Doors.Add(door13);
                        break;

                    default:
                        break;

                }
                char[,] grid = generator.Generate();
                _collums = grid.GetLength(0);
                _rows = grid.GetLength(1);

                List<char[,]> gridList = new List<char[,]>();
                char[,] grid1 = new char[20,10]
                    , grid2 = new char[20, 10]
                    , grid3 = new char[20, 10]
                    , grid4 = new char[20, 10]
                    , grid5 = new char[20, 10]
                    , grid6 = new char[20, 10]
                    , grid7 = new char[20, 10]
                    , grid8 = new char[20, 10]
                    , grid9 = new char[20, 10];
                gridList.Add(grid1);
                gridList.Add(grid2);
                gridList.Add(grid3);
                gridList.Add(grid4);
                gridList.Add(grid5);
                gridList.Add(grid6);
                gridList.Add(grid7);
                gridList.Add(grid8);
                gridList.Add(grid9);

                //vult alle grids met een herkenbare character
                //foreach (char[,] g in gridList)
                //{
                //    for (int X = 0; X < 20; X++)
                //    {
                //        for (int Y = 0; Y < 10; Y++)
                //        {
                //            g[X, Y] = '$';
                //        }
                //    }
                //}

                //splits de grote grid in allemaal kleine grids
                for (int y = 0; y < _rows; y++)
                    {
                    for (int x = 0; x < _collums; x++)
                    {
                        if (y < 10)
                        {
                            if (x < 20)
                            {
                                grid1[x, y] = grid[x, y];
                            }
                            if (x > 19 && x < 40)
                            {
                                grid2[x - 20, y] = grid[x, y];
                            }
                            if (x > 39 && x < 60)
                            {
                                grid3[x - 40, y] = grid[x, y];
                            }
                        }
                        if (y > 9 && y < 20)
                        {
                            if (x < 20)
                            {
                                grid4[x, y - 10] = grid[x, y];
                            }
                            if (x > 19 && x < 40)
                            {
                                grid5[x - 20, y - 10] = grid[x, y];
                            }
                            if (x > 39 && x < 60)
                            {
                                grid6[x - 40, y - 10] = grid[x, y];
                            }
                        }
                        if (y > 19 && y < 30)
                        {
                            if (x < 20)
                            {
                                grid7[x, y - 20] = grid[x, y];
                            }
                            if (x > 19 && x < 40)
                            {
                                grid8[x - 20, y - 20] = grid[x, y];
                            }
                            if (x > 39 && x < 60)
                            {
                                grid9[x - 40, y - 20] = grid[x, y];
                            }
                        }
                    }
                }
                //vindt met behulp van het herkenningsteken de lege grids en gooit die weg
                //foreach (char[,] g in gridList)
                //{
                //    for (int X = 0; X < 20; X++)
                //    {
                //        for (int Y = 0; Y < 10; Y++)
                //        {
                //            if (g[X, Y] == 0)
                //            {
                //                gridList.Remove(g);
                //            }
                                
                //        }
                //    }
                //    int p = 0;
                //}

                _grid = new Object[_collums, _rows];
                ReadTiles(grid);
                return;

            }

            for (int y = 0; y < lines.Count; y++)
            {
                for (int x = 0; x < lines[y].Length; x++)
                {
                    AddTile(FindType(lines[y][x]), lines[y][x], x, y);
                }
            }
        }

        private void ReadTiles(char[,] grid)
        {
            for (int y = 0; y < grid.GetLength(1); y++)
            {
                for (int x = 0; x < grid.GetLength(0); x++)
                {
                    AddTile(FindType(grid[x, y]), grid[x, y], x, y);
                }
            }
        }

        protected virtual Object FindType(char type)
        {
            return null;
        }

        private void AddTile(Object tile, char type, int x, int y)
        {
            if (tile != null)
            {
                setTile(x, y, tile);
            }
            else
            {
                throw new Exception("tile type: " + type + "was not found");
            }
        }
    }
}