using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System.Data.SqlClient;
using Microsoft.Xna.Framework.Graphics;

namespace Engine
{
    class Player : Character
    {
        //Database gegevens
        private const String SERVER = "dpstudios.nl";//<-- moet nog vervangen worden?
                                                        //port = 3306?
        private const String DATABASE = "u13357p9566_highscore";
        private const String UID = "u13357p9566_dps";
        private const String PASSWORD = "toeganggeweigerd6";
        private static SqlConnection dbConn;
        //Einde database gegevens

        private Inventory _inventory;
        private float _walkSpeed;
        private float _runSpeed;
        
        public Inventory Inventory
        {
            get { return _inventory; }
        }

        public Player(string id, Object parent, string assetName) : base(id, parent, assetName)
        {
            _inventory = new Inventory(id + "inventory", World);
            HasPhysics = true;
            CanCollide = true;
            CanBlock = true;
            _walkSpeed = 400;
            _runSpeed = 600;
            SetupSpriteSheet(4);
            IsAnimated = true;
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
        }          

        /*TODO Improve this method look at UpdateMovementState <3*/
        public virtual void HandleInput(GameTime gameTime)
        {
            float speed = GameInstance.InputManager.isKeyHolding(Keys.LeftShift) ? _runSpeed : _walkSpeed;
            if (World.IsTopDown)
            {
                HandleTopDownInput(speed);
            }
            else
            {
                HandleSideInput(speed);
            }

            //Highscore test. Als je op H drukt wordt er een random waarde in de highscore lijst gezet met als username Random.
            //Als dit verplaatst wordt, verplaats dan ook de "using MySql.Data.MySqlClient;"
            if (GameInstance.InputManager.isKeyPressed(Keys.H))
            {
                //Database initializeren (dit kan ook ergens anders, dan hoef je het niet steeds opnieuw te doen.
                SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();
                /*builder.Server = SERVER;
                builder.UserID = UID;
                builder.Password = PASSWORD;
                builder.Database = DATABASE;*/
                //builder.ConnectionString = "Server="+SERVER+";Database="+DATABASE+";User Id="+UID+";Password="+PASSWORD+";";
                builder.ConnectionString = "Server=dpstudios.nl;Database=u13357p9566_highscore;Uid=u13357p9566_dps;Password=toeganggeweigerd6;";

                String connString = builder.ToString();

                builder = null;

                Console.WriteLine(connString);

                dbConn = new SqlConnection(connString);
                //Einde initializatie

                //Variabeles die nodig zijn voor de query
                Random rnd = new Random();
                int score = rnd.Next(0, 50);
                string username = "Random";

                //Score in database zetten:
                string query = string.Format("INSERT INTO highscore(username,score) VALUES ('{0}','{1}')", username, score);
                SqlCommand cmd = new SqlCommand(query, dbConn);

                /*werkt nog niet:
                dbConn.Open();

                SqlDataReader reader = cmd.ExecuteReader();

                dbConn.Close();
                //Einde score in database zetten
                */
            }
        }

        private void HandleTopDownInput(float speed)
        {
            if (GameInstance.InputManager.isKeyHolding(Keys.D))
            {
                VelocityX = speed;
                Mirrored = false;
            }
            else if (GameInstance.InputManager.isKeyHolding(Keys.A))
            {
                VelocityX = -speed;
                Mirrored = true;
            }
            else
            {
                VelocityX = 0;
            }
            if(GameInstance.InputManager.isKeyHolding(Keys.S))
            {
                VelocityY = speed;
            }
            else if(GameInstance.InputManager.isKeyHolding(Keys.W))
            {
                VelocityY = -speed;
            }
            else
            {
                VelocityY = 0;
            }                                       
        }

        private void HandleSideInput(float speed)
        {
            if (GameInstance.InputManager.isKeyHolding(Keys.D))
            {
                VelocityX = speed;
                Mirrored = false;
            }
            else if (GameInstance.InputManager.isKeyHolding(Keys.A))
            {
                VelocityX = -speed;
                Mirrored = true;
            }
            else
            {
                VelocityX = 0;
            }
            if (GameInstance.InputManager.isKeyPressed(Keys.Space))
            {
                Velocity = new Vector2(VelocityX, -300);
            }
        }

        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            base.Draw(gameTime, spriteBatch);
        }
    }
}