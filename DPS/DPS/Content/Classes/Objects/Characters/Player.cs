using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
        private const String PASSWORD =                                                                                                                                         "toeganggeweigerd6";
        private static MySqlConnection dbConn;
        //Einde database gegevens

        private Inventory _inventory;
        private Weapon _weapon1, _weapon2;
        private SpriteSheet _spriteSheetSmall, _spriteSheetBig;
        private float _topDownSpeed, _sideSpeed;

        private bool _isSuperJumping, _canJump;
     
        public Inventory Inventory
        {
            get { return _inventory; }
        }

        public Weapon Weapon1
        {
            get { return _weapon1; }
        }

        public Weapon Weapon2
        {
            get { return _weapon2; }
        }

        public Player(string id, Engine.Object parent, SpriteSheet spriteSheetSmall, SpriteSheet spriteSheetBig) : base(id, parent, spriteSheetBig)
        {
            _inventory = new Inventory(id + "inventory", World);
            _topDownSpeed = 400;
            _sideSpeed = 450;
            Health = 500;
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
        }

        public override void Update(GameTime gameTime)
        {
            //set weapon.Visible false, if player attacks, this will be set to true, until loop reaches this point again
            _weapon1.Visible = false;
            base.Update(gameTime);
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
                if (World.IsTopDown)
                {
                    HandleTopDownInput();
                }
                else
                {
                    HandleSideInput();
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

        private void HandleTopDownInput()
        {
            //Highscore test. Als je op H drukt wordt er een random waarde in de highscore lijst gezet met als username Random.
            //Als dit verplaatst wordt, verplaats dan ook de "using MySql.Data.MySqlClient;"
            if (GameInstance.InputManager.isKeyPressed(Keys.H))
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

            if (GameInstance.InputManager.isKeyHolding(Keys.D))
            {
                VelocityX = _topDownSpeed;
                Mirrored = false;
            }
            else if (GameInstance.InputManager.isKeyHolding(Keys.A))
            {
                VelocityX = -_topDownSpeed;
                Mirrored = true;
            }
            else
            {
                VelocityX = 0;
            }
            if(GameInstance.InputManager.isKeyHolding(Keys.S))
            {
                VelocityY = _topDownSpeed;
            }
            else if(GameInstance.InputManager.isKeyHolding(Keys.W))
            {
                VelocityY = -_topDownSpeed;
            }
            else
            {
                VelocityY = 0;
            }                                       
        }

        private void HandleSideInput()
        {
            if(GameInstance.InputManager.LeftMouseButtonPressed)
            {
                TryAttack = true;
            }
            else
            {
                TryAttack = false;
            }
            if (GameInstance.InputManager.isKeyHolding(Keys.D))
            {
                VelocityX = _sideSpeed;
                Mirrored = false;
            }
            else if (GameInstance.InputManager.isKeyHolding(Keys.A))
            {
                VelocityX = -_sideSpeed;
                Mirrored = true;
            }
            else
            {
                VelocityX = 0;
            }
            //_canJump is a variable that allows for doubleJumps
            if (GameInstance.InputManager.isKeyPressed(Keys.Space) && (!InAir || _canJump))
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
            if (GameInstance.InputManager.isKeyPressed(Keys.R))
            {
                SuperJump();               
            }
            if (GameInstance.InputManager.isKeyPressed(Keys.E))
            {
                _isSuperJumping = false;
                _weapon2.Visible = false;
            }
        }
        #endregion

        private void SuperJump()
        {
            Velocity = new Vector2(VelocityX, -550 * 10);
            _isSuperJumping = true;
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

        public override void OnDamaged(int damage)
        {
            base.OnDamaged(damage);
            Content.HighScoreManager.IncrementTotalDamageTaken = damage;
        }
        #endregion
    }
}