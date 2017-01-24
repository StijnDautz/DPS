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
        private Weapon _weapon1, _weapon2;
        private SpriteSheet _spriteSheetSmall, _spriteSheetBig;
        private float _walkSpeed;
        private float _runSpeed;

        private bool _isSuperJumping;
     
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
            _walkSpeed = 400;
            _runSpeed = 600;
            Health = 500;
            Damage = 100;
            _weapon1 = new Content.WeaponPlayer("sword", World, new SpriteSheet("Hud/TimerFrame"), this, Damage);
            _weapon1.Visible = false;
            _weapon2 = new Content.WeaponSuperJump("superJump", World, new Engine.SpriteSheet("Hud/TimerFrame - kopie"), this, 1);
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
                }
            }
            else
            {
                if(SpriteSheet != _spriteSheetBig)
                {
                    SpriteSheet = _spriteSheetBig;
                }
            }
        }

        #region InputHandling
        /*TODO Improve this method look at UpdateMovementState <3*/
        public virtual void HandleInput(GameTime gameTime)
        {
            if (!Death)
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
                Velocity = new Vector2(VelocityX, -550);
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
        protected override void UpdateCombat(float elapsedTime)
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