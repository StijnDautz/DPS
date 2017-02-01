using System;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using MySql.Data.MySqlClient;
using System.Security.Cryptography;
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
        private static MySqlConnection dbConn;
        //Einde database gegevens

        private Weapon _weapon1, _weapon2;
        private SpriteSheet _spriteSheetSmall, _spriteSheetBig;
        private float _topDownSpeed, _sideSpeed;

        private bool _canSuperJump, _canJump;

        public Weapon Weapon1
        {
            get { return _weapon1; }
        }

        public Weapon Weapon2
        {
            get { return _weapon2; }
        }

        public bool CanSuperJump
        {
            set { _canSuperJump = value; }
        }

        public float TopDownSpeed
        {
            set { _topDownSpeed = value; }
            get { return _topDownSpeed; }
        }

        public float SideSpeed
        {
            set { _sideSpeed = value; }
            get { return _sideSpeed; }
        }

        public Player(string id, Object parent, SpriteSheet spriteSheetSmall, SpriteSheet spriteSheetBig) : base(id, parent, spriteSheetBig)
        {
            _topDownSpeed = 400;
            _sideSpeed = 450;
            Health = 2000;
            Damage = 100;
            _weapon1 = new Content.WeaponPlayer("sword", World, new SpriteSheet("Textures/Hud/Invisible"), this, Damage);
            _weapon1.Visible = false;
            _weapon2 = new Content.WeaponSuperJump("superJump", World, new Engine.SpriteSheet("Textures/Hud/TimerFrame - kopie"), this, 1);
            _weapon2.Visible = false;
            World.Add(_weapon1);
            World.Add(_weapon2);
            Mass = 1.9f;
            SFXManager = new Content.SFXPlayer(this);
            _spriteSheetSmall = spriteSheetSmall;
            _spriteSheetBig = spriteSheetBig;
            StaggerDuration = 400;
            AttackSpeed = 700;
            Death = false;
        }

        public override void Update(GameTime gameTime)
        {
            //set weapon.Visible false, if player attacks, this will be set to true, until loop reaches this point again
            _weapon1.Visible = false;
            base.Update(gameTime);

            //if falling SuperJumpWeapon becomes invisible
            if(Velocity.Y > 0)
            {
                _weapon2.Visible = false;
            }
            UpdateSpriteSheet();
            if(!InAir)
            {
                _canJump = true;
            }
        }

        /*
         * Updates the spriteSheet so it matches the world type
         */
        private void UpdateSpriteSheet()
        {
            if(World.IsTopDown)
            {
                if(SpriteSheet != _spriteSheetSmall)
                {
                    SpriteSheet = _spriteSheetSmall;
                    BoundingBox = new Rectangle(0, 0, 64, 80);
                }
            }
            else
            {
                if(SpriteSheet != _spriteSheetBig)
                {
                    SpriteSheet = _spriteSheetBig;
                    BoundingBox = new Rectangle(0, 0, 128, 160);
                }
            }
        }

        #region InputHandling
        public virtual void HandleInput(GameTime gameTime)
        {
            //if player is not death or staggered, handleinput
            if (!Death && !IsStaggered)
            {
                var input = GameInstance.InputManager;
                if(input.isKeyPressed(Keys.B))
                {
                    //remove player from current world
                    World.Remove(this);
                    World.Remove(_weapon1);
                    World.Remove(_weapon2);

                    if (World.Id != "Dungeon1")
                    {
                        World.GameMode.SwitchTo("Dungeon1");
                    }

                    //add player to new world at correct position
                    World.GameMode.World.Add(this);
                    World.GameMode.World.Add(_weapon1);
                    World.GameMode.World.Add(_weapon2);
                    Position = new Vector2(30000, 400);                  
                }
                if (World.IsTopDown)
                {
                    HandleTopDownInput(input);
                }
                else
                {
                    HandleSideInput(input);
                }              
            }
        }

        //Password hash functie voor database check
        public static string HashSHA1(string value)
        {
            var sha1 = SHA1.Create();
            var inputBytes = Encoding.ASCII.GetBytes(value);
            var hash = sha1.ComputeHash(inputBytes);
            var sb = new StringBuilder();
            for (var i = 0; i < hash.Length; i++)
            {
                sb.Append(hash[i].ToString("X2"));
            }
            return sb.ToString();
        }

        private void HandleTopDownInput(InputManager input)
        {
            //Highscore test. Als je op H drukt wordt er een random waarde in de highscore lijst gezet met als username Random.
            //Als dit verplaatst wordt, verplaats dan ook de "using MySql.Data.MySqlClient;"
            if (input.isKeyPressed(Keys.H))
            {
                //Database initializeren (dit kan ook ergens anders, dan hoef je het niet steeds opnieuw te doen.
                MySqlConnectionStringBuilder builder = new MySqlConnectionStringBuilder();
                /*builder.Server = SERVER;
                builder.UserID = UID;
                builder.Password = PASSWORD;
                builder.Database = DATABASE;*/
                //builder.ConnectionString = "Server="+SERVER+";Database="+DATABASE+";User Id="+UID+";Password="+PASSWORD+";";
                builder.ConnectionString = "Server=dpstudios.nl;Database=u13357p9566_highscore;Uid=u13357p9566_dps;                                                                         Password=toeganggeweigerd6;";

                String connString = builder.ToString();

                builder = null;

                Console.WriteLine(connString);

                dbConn = new MySqlConnection(connString);
                //Einde initializatie

                //Variabeles die nodig zijn voor de query
                Random rnd = new Random();
                int score = rnd.Next(0, 50);
                string username = "Augustvc";
                string userpassword = "";
                string hashedpassword = HashSHA1(userpassword);

                //Score in database zetten QUERY:
                string query = string.Format("INSERT INTO highscore(username,score) VALUES ('{0}','{1}')", username, score);

                //Checken of username & wachtwoord in database bestaan:
                //string query = string.Format("SELECT username FROM users");
                //LIMIT 1      WHERE username = 'username'

                //Leestest.
                //string query = string.Format("SELECT username FROM `users`");

                //Checken of username in database bestaat:
                //string query = string.Format("SELECT * FROM `users` WHERE username = '{0}' AND hashedpassword = '{1}'", username, hashedpassword);


                //public bool isAccountValid


                //while (reader.Read())

                //if (reader["username"].ToString() == username)

                MySqlCommand cmd = new MySqlCommand(query, dbConn);


                dbConn.Open();

                MySqlDataReader reader = cmd.ExecuteReader();

                dbConn.Close();
                //Connectie sluiten is belangrijk.
            }

            if (input.isKeyHolding(Keys.D))
            {
                VelocityX = _topDownSpeed;
                Mirrored = false;
            }
            else if (input.isKeyHolding(Keys.A))
            {
                VelocityX = -_topDownSpeed;
                Mirrored = true;
            }
            else
            {
                VelocityX = 0;
            }
            if(input.isKeyHolding(Keys.S))
            {
                VelocityY = _topDownSpeed;
            }
            else if(input.isKeyHolding(Keys.W))
            {
                VelocityY = -_topDownSpeed;
            }
            else
            {
                VelocityY = 0;
            }                                       
        }

        private void HandleSideInput(InputManager input)
        {
            if(input.LeftMouseButtonPressed)
            {
                TryAttack = true;
            }
            else
            {
                TryAttack = false;
            }
            if (input.isKeyHolding(Keys.D))
            {
                VelocityX = _sideSpeed;
                Mirrored = false;
            }
            else if (input.isKeyHolding(Keys.A))
            {
                VelocityX = -_sideSpeed;
                Mirrored = true;
            }
            else
            {
                VelocityX = 0;
            }
            //_canJump is a variable that allows for doubleJumps
            if (input.isKeyPressed(Keys.Space) && (!InAir || _canJump))
            {
                //if inAir, player double Jumped, so canJump is now false
                if(InAir)
                {
                    _canJump = false;
                    //the double jump is smaller
                    Velocity = new Vector2(VelocityX, -450);
                }
                else
                {
                    Velocity = new Vector2(VelocityX, -630);
                }
            }
            //if R is pressed and the player has picked up the required pickup, perform a superjump
            else if (input.isKeyPressed(Keys.R) && _canSuperJump)
            {
                SuperJump();               
            }
        }
        #endregion

        private void SuperJump()
        {
            Velocity = new Vector2(VelocityX, -5500);
            _weapon2.Visible = true; 
        }

        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            base.Draw(gameTime, spriteBatch);
        }

        #region Combat
        protected override void UpdateCombat(int elapsedTime)
        {
            base.UpdateCombat(elapsedTime);
            //set weapon position according to player movement
            _weapon1.Position = Mirrored ? new Vector2(Position.X - _weapon1.Width, Position.Y + 50) : new Vector2(Position.X + Width, Position.Y + 50);
        }

        protected override void OnAttack()
        {
            base.OnAttack();
            _weapon1.Visible = true;
        }
        #endregion
    }
}