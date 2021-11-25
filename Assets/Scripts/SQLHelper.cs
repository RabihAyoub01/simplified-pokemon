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
        
        /// <summary>
        /// In the constructor, the code calls ConnectDB() method.
        /// </summary>
        public SQLConnector()
        {
            ConnectDB();
        }

        /// <summary>
        /// Connects the code to the database.
        /// </summary>
        private void ConnectDB()
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
                Debug.LogError($"Error Occured While Connecting to Database: {ex.Message}");
            }
        }

        /// <summary>
        /// This method executes a querry in form of string. It handles Exceptions.'
        /// All the methods for the SQL querries will be using this method. 
        /// </summary>
        /// <param name="query">The Query to be executed.</param>
        static void ExecuteQuery(string query)
        {
            cmd.CommandText = query;

            try
            {
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Debug.LogError($"Error Occured While Executing Query | {query} | {ex.Message}");
            }
        }

        /// <summary>
        /// Closes connection.
        /// </summary>
        public static void CloseConnection()
        {
            conn.Close();
        }

        // <---- Start of methods for SQL querries ---->

        /// <summary>
        /// Inserts new Account to Database.
        /// </summary>
        /// <param name="username">Username String of the new account.</param>
        /// <param name="password">Password String of the new account.</param>
        public static void CreateAccount(string username, string password)
        {
            ExecuteQuery($"INSERT INTO account VALUES('{username}', '{password}');");
        }

        public static void InsertPokemon(string pokemonName, int pokemonLevel, string type1, string type2, int rarity)
        {
            ExecuteQuery($"INSERT INTO pokemon VALUES('{pokemonName}', '{pokemonLevel}','{type1}','{type2}','{rarity}');");
        }

        public static void removePokemon()
        {
           
        }

        public static void updatePokemon(string pokemonName, int pokemonLevel, string type1, string type2, int rarity)
        {
            
        }
        
        public static void InsertAbility(string abilityName, string abilityType)
        {
            ExecuteQuery($"INSERT INTO pokemon VALUES('{abilityName}', '{abilityType}');");
        }

        public static void InsertItems(string itemName, int itemPrice, string effect)
        {
            ExecuteQuery($"INSERT INTO pokemon VALUES('{itemName}', '{itemPrice}','{effect}');");
        }
        
        public static void InsertAccount(string username, string password)
        {
            ExecuteQuery($"INSERT INTO pokemon VALUES('{username}', '{password}');");
        }
        
        public static void InsertTrainer(string trainerID, int level, string name)
        {
            ExecuteQuery($"INSERT INTO pokemon VALUES('{trainerID}', '{level}');");
        }

    }
}
