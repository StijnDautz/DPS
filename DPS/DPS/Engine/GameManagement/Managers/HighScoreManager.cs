﻿using System;
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
        private static int _totalDamageTaken, _totalDamageDealt;
        private static string _userName;

        public static int HighScore
        {
            get { return _highScore; }
        }

        public static int IncrementTotalDamageTaken
        {
            get { return _totalDamageTaken; }
            set { _totalDamageTaken = value; }
        }

        public static int IncrementTotalDamageDealt
        {
            get { return _totalDamageDealt; }
            set { _totalDamageDealt += value; }
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

            dbConn = new MySqlConnection(connString);
        }

        public static bool IsAccountValid(string username, string password)
        {
            InitializeDatabase();
            string hashedpassword = HashSHA1(password);

            string query = string.Format("SELECT username FROM `users` WHERE username = '{0}' AND hashedpassword = '{1}'", username, hashedpassword);


            MySqlCommand cmd = new MySqlCommand(query, dbConn);

            try {
                dbConn.Open();

                MySqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    dbConn.Close();

                    //if account information was valid, player is logged in and the used username is saved
                    _userName = username;
                    return true;
                }
                else
                {
                    dbConn.Close();
                    return false;
                }
            }
            catch
            {
                return false;
            }
            
        }

        //username is opgeslagen in class, nadat account info valid is verklaard in IsAccountValid
        public static void GetHighscore()//werkt alleen als de persoon ingelogd is lijkt me, daarom ook geen ww nodig.
        {
            _highScore = 5000;
            InitializeDatabase();
            string query = string.Format("SELECT score FROM `highscore` WHERE username = '{0}'", _userName);

            MySqlCommand cmd = new MySqlCommand(query, dbConn);

            try
            {
                dbConn.Open();

                MySqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    if (int.Parse(reader["score"].ToString()) >= _highScore)
                    {
                        _highScore = int.Parse(reader["score"].ToString());
                    }
                }

                dbConn.Close();
            }
            catch
            {

            }
        }

        public static void uploadHighscore(int score)
        {
            InitializeDatabase();
            string query = string.Format("INSERT INTO highscore(username,score) VALUES ('{0}','{1}')", _userName, score);


            MySqlCommand cmd = new MySqlCommand(query, dbConn);

            try
            {

                dbConn.Open();

                MySqlDataReader reader = cmd.ExecuteReader();

                dbConn.Close();
            }
            catch
            {

            }
        }
        
        public static int CalculateNewHighScore(int timeInSeconds, bool finished)
        {
            float highScoreModf = (float)_highScore / 50000;
            float damageTakenScore = _totalDamageTaken * -(1 - highScoreModf);
            float damageDealtScore = _totalDamageDealt * highScoreModf;
            float timeScore = finished ? ((3000 - timeInSeconds) / (1 - highScoreModf)) * 2.5f : 0;
            float finishingScore = finished ? 5000 : 0;
            return (int)(damageTakenScore + damageDealtScore + finishingScore + timeScore);
        }
    }
}
