using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Engine
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    /// 
    public class Door
    {
        public Vector2 location;
        public enum direction { left, right, up, down };
        public direction direc;
    }

    public class Room
    {
        public Rectangle rectangle;
        public int connections;
        public List<Room> connected = new List<Room>();
    }

    public class RandomDungeonGenerator
    {
        Random r = new Random();
        Vector2 position = new Vector2(30, 25);
        int width = 3 * 20;
        int height = 5 * 10;
        char[,] grid;
        int jumpHeight = 3;
        private Vector2 _position;

        //Vector2 door1, door2, door3, door4;
        Door door1 = new Door(), door2 = new Door(), door3 = new Door(), door4 = new Door();

        //List<Vector2> doors = new List<Vector2>();
        List<Door> doors = new List<Door>();

        public List<Door> Doors
        {
            get { return doors; }
            set { doors = value; }
        }

        public int Width
        {
            get { return width; }
            set { width = value; }
        }
        public int Height
        {
            get { return height; }
            set { height = value; }
        }

        public Vector2 Position
        {
            get { return _position; }
        }

        //List<Rectangle> rooms = new List<Rectangle>();
        List<Room> rooms = new List<Room>();

        public RandomDungeonGenerator(Vector2 position)
        {
            _position = position;
        }

        //Generates dungeons
        public char[,] Generate()
        {
            grid = new char[width, height];
            //door1.location = new Vector2(0, 10);
            //door1.direc = Door.direction.right;

            //door2.location = new Vector2(0, 40);
            //door2.direc = Door.direction.right;

            //door3.location = new Vector2(59, 10);
            //door3.direc = Door.direction.left;

            //door4.location = new Vector2(59, 40);
            //door4.direc = Door.direction.left;

            //doors.Add(door1);
            //doors.Add(door2);
            //doors.Add(door3);
            //doors.Add(door4);

            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    if(grid[x,y] == 0)
                    grid[x, y] = 'k';
                }
            }
            //creert de deuren
            foreach (Door d in doors)
            {
                position = d.location;
                Room room = new Room();

                if (d.direc == Door.direction.right)
                {
                    grid[(int)d.location.X, (int)d.location.Y] = 'd';
                    grid[(int)d.location.X, (int)d.location.Y + 1] = '0';
                    grid[(int)d.location.X, (int)d.location.Y + 2] = '0';

                    grid[(int)d.location.X + 1, (int)d.location.Y] = '0';
                    grid[(int)d.location.X + 1, (int)d.location.Y + 1] = '0';
                    grid[(int)d.location.X + 1, (int)d.location.Y + 2] = '0';

                    room.rectangle.Location = new Point((int)d.location.X + 2, (int)d.location.Y - 1);
                    room.rectangle.Size = new Point(r.Next(2, 7), 5);
                }
                if (d.direc == Door.direction.left)
                {
                    grid[(int)d.location.X, (int)d.location.Y] = 'e';
                    grid[(int)d.location.X, (int)d.location.Y + 1] = '0';
                    grid[(int)d.location.X, (int)d.location.Y + 2] = '0';

                    grid[(int)d.location.X - 1, (int)d.location.Y] = '0';
                    grid[(int)d.location.X - 1, (int)d.location.Y + 1] = '0';
                    grid[(int)d.location.X - 1, (int)d.location.Y + 2] = '0';

                    room.rectangle.Location = new Point((int)d.location.X - 2 - r.Next(2, 7), (int)d.location.Y - 1);
                    room.rectangle.Size = new Point(width - room.rectangle.Location.X - 2, 5);
                }
                if (d.direc == Door.direction.up)
                {
                    grid[(int)d.location.X, (int)d.location.Y] = 'p';
                    grid[(int)d.location.X + 1, (int)d.location.Y] = 'p';
                    grid[(int)d.location.X + 2, (int)d.location.Y] = 'p';

                    room.rectangle.Location = new Point((int)d.location.X - 1, (int)d.location.Y + 1);
                    room.rectangle.Size = new Point(5, 5);
                }
                if (d.direc == Door.direction.down)
                {
                    grid[(int)d.location.X, (int)d.location.Y] = 'p';
                    grid[(int)d.location.X + 1, (int)d.location.Y] = 'p';
                    grid[(int)d.location.X + 2, (int)d.location.Y] = 'p';

                    room.rectangle.Location = new Point((int)d.location.X - 1, (int)d.location.Y - 5);
                    room.rectangle.Size = new Point(5, 5);
                }
                rooms.Add(room);
            }

            //creert de kamers
            RectangleSpawner();

            CorridorSpawner();

            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    if (grid[x, y] == 'a')
                    {
                        grid[x, y] = '0';
                    }
                }
            }

            //zet de randjes om de kamers
            //for (int y = 1; y < height - 1; y++)
            //{
            //    for (int x = 1; x < width - 1; x++)
            //    {
            //        if (grid[x, y] != '0' && grid[x, y] != '2' && grid[x, y] != 'a')
            //        {
            //            if (grid[x + 1, y] == '0' ||
            //            grid[x - 1, y] == '0' ||
            //            grid[x, y + 1] == '0' ||
            //            grid[x, y - 1] == '0')
            //                grid[x, y] = '4';
            //        }
            //    }
            //}

            //klaar
            return grid;
        }

        //verbindt alle kamers met gangen
        void CorridorSpawner()
        {
            foreach (Room room in rooms)
            {
                bool foundRoom = false;
                int counter = 0;
                int extended = 1;

                while (!foundRoom)
                {
                    //
                    if (room.connections > 1)
                        foundRoom = true;
                    #region Up
                    if (counter == 0)
                    {
                        for (int add = 0; add < room.rectangle.Width; add++)
                        {
                            if (room.rectangle.Location.Y - extended > 0)
                            {
                                if (grid[room.rectangle.Location.X + add, room.rectangle.Location.Y - extended] == '0')
                                {
                                    //foundRoom = true;
                                    Room room1 = CollisionChecker(new Vector2(room.rectangle.Location.X + add, room.rectangle.Location.Y - extended));
                                    if (room1 != null && room1.connections < 3 && !room1.connected.Contains(room))
                                    {
                                        room1.connections++;
                                        room.connections++;
                                        room1.connected.Add(room);

                                        bool leftRight = false;
                                        bool nowLeftRight = false;

                                        for (int i = 0; i < extended; i++)
                                        {
                                            grid[room.rectangle.Location.X + add, room.rectangle.Location.Y - i] = 'a';

                                            if (room.rectangle.Location.X + add + 1 < width)
                                            {
                                                grid[room.rectangle.Location.X + add + 1, room.rectangle.Location.Y - i] = 'a';
                                                leftRight = true;
                                            }


                                            else
                                            {
                                                grid[room.rectangle.Location.X + add - 1, room.rectangle.Location.Y - i] = 'a';
                                                leftRight = false;
                                            }


                                            if (extended > 3)
                                            {
                                                if (i % jumpHeight == 0 && i != 0)
                                                {
                                                    if (!nowLeftRight)
                                                    {
                                                        grid[room.rectangle.Location.X + add, room.rectangle.Location.Y - i] = '2';
                                                        nowLeftRight = true;
                                                    }


                                                    else
                                                    {
                                                        if (leftRight)
                                                            grid[room.rectangle.Location.X + add + 1, room.rectangle.Location.Y - i] = '2';
                                                        else
                                                            grid[room.rectangle.Location.X + add - 1, room.rectangle.Location.Y - i] = '2';

                                                        nowLeftRight = false;
                                                    }

                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                    #endregion

                    #region Right
                    if (counter == 1)
                    {
                        for (int add = 0; add < room.rectangle.Height; add++)
                        {
                            if (room.rectangle.Location.X + room.rectangle.Width + extended < width)
                            {
                                if (grid[room.rectangle.Location.X + room.rectangle.Width + extended, room.rectangle.Location.Y + add] == '0')
                                {
                                    //foundRoom = true;
                                    Room room1 = CollisionChecker(new Vector2(room.rectangle.Location.X + room.rectangle.Width + extended, room.rectangle.Location.Y + add));
                                    if (room1 != null && room1.connections < 3 && !room1.connected.Contains(room))
                                    {
                                        room1.connections++;
                                        room.connections++;
                                        room1.connected.Add(room);
                                        for (int i = 0; i < extended; i++)
                                        {
                                            grid[room.rectangle.Location.X + room.rectangle.Width + i, room.rectangle.Location.Y + add] = 'a';

                                            if (room.rectangle.Location.Y + add + 1 < height)
                                                grid[room.rectangle.Location.X + room.rectangle.Width + i, room.rectangle.Location.Y + add + 1] = 'a';
                                            else
                                                grid[room.rectangle.Location.X + room.rectangle.Width + i, room.rectangle.Location.Y + add - 1] = 'a';

                                        }
                                    }
                                }
                            }

                        }
                    }
                    #endregion

                    #region Down
                    if (counter == 2)
                    {
                        for (int add = 0; add < room.rectangle.Width; add++)
                        {
                            if (room.rectangle.Location.Y + room.rectangle.Height + extended < height)
                            {
                                if (grid[room.rectangle.Location.X + add, room.rectangle.Location.Y + room.rectangle.Height + extended] == '0')
                                {
                                    //foundRoom = true;
                                    Room room1 = CollisionChecker(new Vector2(room.rectangle.Location.X + add, room.rectangle.Location.Y + room.rectangle.Height + extended));
                                    if (room1 != null && room1.connections < 3 && !room1.connected.Contains(room))
                                    {
                                        room1.connections++;
                                        room.connections++;
                                        room1.connected.Add(room);

                                        bool leftRight = false;
                                        bool nowLeftRight = false;

                                        for (int i = 0; i < extended; i++)
                                        {
                                            grid[room.rectangle.Location.X + add, room.rectangle.Location.Y + room.rectangle.Height + i] = 'a';

                                            if (room.rectangle.Location.X + add + 1 < width)
                                            {
                                                grid[room.rectangle.Location.X + add + 1, room.rectangle.Location.Y + room.rectangle.Height + i] = 'a';
                                                leftRight = true;
                                            }

                                            else
                                            {
                                                grid[room.rectangle.Location.X + add - 1, room.rectangle.Location.Y + room.rectangle.Height + i] = 'a';
                                                leftRight = false;
                                            }

                                            if (extended > 3)
                                            {
                                                if (i % jumpHeight == 0 && i != 0)
                                                {
                                                    if (!nowLeftRight)
                                                    {
                                                        grid[room.rectangle.Location.X + add, room.rectangle.Location.Y + room.rectangle.Height + i] = '2';
                                                        nowLeftRight = true;
                                                    }


                                                    else
                                                    {
                                                        if (leftRight)
                                                            grid[room.rectangle.Location.X + add + 1, room.rectangle.Location.Y + room.rectangle.Height + i] = '2';
                                                        else
                                                            grid[room.rectangle.Location.X + add - 1, room.rectangle.Location.Y + room.rectangle.Height + i] = '2';

                                                        nowLeftRight = false;
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                            }

                        }
                    }
                    #endregion

                    #region Left
                    if (counter == 3)
                    {
                        for (int add = 0; add < room.rectangle.Height; add++)
                        {
                            if (room.rectangle.Location.X - extended > 0)
                            {
                                if (grid[room.rectangle.Location.X - extended, room.rectangle.Location.Y + add] == '0')
                                {
                                    //foundRoom = true;
                                    Room room1 = CollisionChecker(new Vector2(room.rectangle.Location.X - extended, room.rectangle.Location.Y + add));
                                    if (room1 != null && room1.connections < 3 && !room1.connected.Contains(room))
                                    {
                                        room1.connections++;
                                        room.connections++;
                                        room1.connected.Add(room);
                                        for (int i = 0; i < extended; i++)
                                        {
                                            grid[room.rectangle.Location.X - i, room.rectangle.Location.Y + add] = 'a';

                                            if (room.rectangle.Location.Y + add + 1 < height)
                                                grid[room.rectangle.Location.X - i, room.rectangle.Location.Y + add + 1] = 'a';
                                            else
                                                grid[room.rectangle.Location.X - i, room.rectangle.Location.Y + add - 1] = 'a';

                                        }
                                    }

                                }
                            }

                        }
                    }
                    #endregion

                    extended++;
                    counter++;
                    if (counter > 3)
                        counter = 0;

                    if (extended > width && extended > height)
                        foundRoom = true;
                }
            }
        }

        //creert de kamers
        void RectangleSpawner()
        {
            for (int i = 0; i < 100; i++)
            {
                Room room = new Room();
                int counter = 0;
                bool exit = false;

                Point size = new Point(r.Next(3, 7), r.Next(3, 4));
                Point location = new Point(width / 2, height / 2);
                Rectangle rect = new Rectangle(location, size);

                while (CollisionChecker(rect) && !exit)
                {
                    //hoe groter kamer, hoe gevulder de dungeon
                    if (counter > 1000)
                        exit = true;
                    location = new Point(r.Next(1, width - size.X - 1), r.Next(1, height - size.Y - 1));
                    rect = new Rectangle(location, size);
                    counter++;
                }
                room.rectangle = rect;

                if (exit)
                    break;

                rooms.Add(room);
            }

            foreach (Room rect in rooms)
            {
                for (int x = rect.rectangle.Location.X; x < rect.rectangle.Location.X + rect.rectangle.Size.X; x++)
                {
                    for (int y = rect.rectangle.Location.Y; y < rect.rectangle.Location.Y + rect.rectangle.Size.Y; y++)
                    {
                        grid[x, y] = '0';
                    }
                }

            }
        }

        //Zoekt naar een bepaalde kamer
        Room CollisionChecker(Vector2 current)
        {
            foreach (Room rect in rooms)
            {
                if (RoomCorridorChecker(current, rect.rectangle))
                {
                    return rect;
                }
            }
            return null;
        }

        //checkt of een vector2 in een rectangle/kamer zit
        bool RoomCorridorChecker(Vector2 current, Rectangle collider)
        {
            int xCur = (int)current.X;
            int yCur = (int)current.Y;

            int xColMin = collider.Location.X;
            int xColMax = collider.Location.X + collider.Size.X;
            int yColMin = collider.Location.Y;
            int yColMax = collider.Location.Y + collider.Size.Y;

            if (xCur + 2 > xColMin &&
                xCur - 2 < xColMax &&
                yCur + 2 > yColMin &&
                yCur - 2 < yColMax
                )
                return true;
            return false;
        }

        //checkt of een rectangle overlapt met een van de andere rectangles
        bool CollisionChecker(Rectangle current)
        {
            foreach (Room rect in rooms)
            {
                if (CollidesWith(current, rect.rectangle))
                {
                    return true;
                }
            }
            return false;
        }

        //Checkt of twee rectangles overlappen
        bool CollidesWith(Rectangle current, Rectangle collider)
        {
            int xCurMin = current.Location.X;
            int xCurMax = current.Location.X + current.Size.X;
            int yCurMin = current.Location.Y;
            int yCurMax = current.Location.Y + current.Size.Y;

            int xColMin = collider.Location.X;
            int xColMax = collider.Location.X + collider.Size.X;
            int yColMin = collider.Location.Y;
            int yColMax = collider.Location.Y + collider.Size.Y;

            if (xCurMax + 2 > xColMin &&
                xCurMin - 2 < xColMax &&
                yCurMax + 2 > yColMin &&
                yCurMin - 2 < yColMax
                )
                return true;
            return false;
        }
    }
}