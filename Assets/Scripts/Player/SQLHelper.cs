using UnityEngine;
using MySql.Data.MySqlClient;
using System;

namespace SQLHelper
{
    class SQLConnector
    {
        static string connectionString = "server=remotemysql.com; uid=cII0ueGbDG;pwd=ryECGbgBjf;database=cII0ueGbDG";
        static MySqlConnection conn = new MySqlConnection();
        static MySqlCommand cmd = new MySqlCommand();  // this is a "cursor" that edits data
        
        public SQLConnector()
        {
            conn.ConnectionString = connectionString;
            cmd.Connection = conn;  // connects this cmd instance to the connectino we've established
            try
            {
                conn.Open();  // this is what opens the connection!!
                Debug.Log("Database Connected!");
            }
            catch (Exception ex)
            {
                Debug.LogError("Error Occured While Connecting to Database: " + ex.Message);
            }
        }

        public static void onPokemonCaught(string pokemonName, int pokemonLevel,
            int rarity, string kek)  // this method executes when "pokemonCaught" event is fired AKA when a pokemon is caught in game.
        {
            string query = "INSERT INTO Pokemon VALUES('" + pokemonName +
                "', " + pokemonLevel + ", " + rarity + ", '" + kek + "')";
            ExecuteQuery(query);
        }

        static void ExecuteQuery(string query)
        {
            cmd.CommandText = query;

            try
            {
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Console.WriteLine("An Error occured: " + ex.Message);
            }
        }
    }
}
