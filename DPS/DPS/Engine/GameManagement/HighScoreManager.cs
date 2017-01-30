using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Security.Cryptography;

namespace Content
{
    class HighScoreManager
    {
        private static MySqlConnection dbConn;
        private static int _highScore;

        public static int HighScore
        {
            get { return _highScore; }
        }
     
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

        static void InitializeDatabase()//kan denk ik het beste aangeroepen worden als het spel opgestart wordt
        {
            MySqlConnectionStringBuilder builder = new MySqlConnectionStringBuilder();

            builder.ConnectionString = "Server=dpstudios.nl;Database=u13357p9566_highscore;Uid=u13357p9566_dps;Password=toeganggeweigerd6;";

            String connString = builder.ToString();

            builder = null;

            Console.WriteLine(connString);

            dbConn = new MySqlConnection(connString);
        }

        public static bool IsAccountValid(string username, string password)
        {
            InitializeDatabase();
            string hashedpassword = HashSHA1(password);

            string query = string.Format("SELECT username FROM `users` WHERE username = '{0}' AND hashedpassword = '{1}'", username, hashedpassword);


            MySqlCommand cmd = new MySqlCommand(query, dbConn);

            dbConn.Open();

            MySqlDataReader reader = cmd.ExecuteReader();

            if (reader.Read())
            {
                dbConn.Close();
                return true;
            } else
            {
                dbConn.Close();
                return false;
            }
            
        }

        public int getHighscore(string username)//werkt alleen als de persoon ingelogd is lijkt me, daarom ook geen ww nodig.
        {
            return 99;
        }

        public void uploadHighscore(string username, int score)
        {
            InitializeDatabase();
            string query = string.Format("INSERT INTO highscore(username,score) VALUES ('{0}','{1}')", username, score);


            MySqlCommand cmd = new MySqlCommand(query, dbConn);

            dbConn.Open();

            MySqlDataReader reader = cmd.ExecuteReader();
            
            dbConn.Close();

        }



    }
}
