using UnityEngine;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;

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
        /// This methods return a data reader from a querry in the form of a string.
        /// This method handles exceptions.
        /// </summary>
        /// <param name="query">The Query to be executed</param>
        /// <returns>A reader instance to be read from</returns>
        public static MySqlDataReader GetReaderFromQuery(string query)
        {
            cmd.CommandText = query;
            MySqlDataReader reader = null;

            try
            {
                reader = cmd.ExecuteReader();  // gets reader value from the querry sent
            }
            catch (Exception ex)
            {
                Debug.LogError($"Error Occured While Executing Query | {query} | {ex.Message}");
            }

            return reader;
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
        public static void InsertAccount(string username, string password)
        {
            ExecuteQuery($"INSERT INTO account VALUES('{username}', '{password}');");
        }


        public static void InsertPokemon(string pokemonName, string type1, string type2, int baseHP, int baseATK, int baseDEF, int baseSPD)
        {
            ExecuteQuery($"INSERT INTO pokemon VALUES('{pokemonName}', '{type1}', '{type2}', '{baseHP}', '{baseATK}', '{baseDEF}','{baseSPD}');");
        }

        public static void removePokemon(string pokemonName)
        {
           ExecuteQuery($"DELETE FROM pokemon WHERE pokemonName='{pokemonName}';");
        }

        public static void updatePokemon(string pokemonName, string type1, string type2, int baseHP, int baseATK, int baseDEF, int baseSPD)
        {
            ExecuteQuery($"UPDATE pokemon SET type1='{type1}', type2='{type2}', baseHP='{baseHP}', baseATK='{baseATK}', baseDEF='{baseDEF}', baseSPD='{baseSPD}' WHERE pokemonName='{pokemonName}'; ");
        }


        public static void InsertAbility(string abilityName, string abilityType)
        {
            ExecuteQuery($"INSERT INTO ability VALUES('{abilityName}', '{abilityType}');");
        }

        public static void InsertItems(string itemName, int itemPrice, string effect)
        {
            ExecuteQuery($"INSERT INTO items VALUES('{itemName}', '{itemPrice}','{effect}');");
        }
       
        public static void InsertTrainer(string trainerID, int level, string name)
        {
            ExecuteQuery($"INSERT INTO trainer VALUES('{trainerID}', '{level}');");
        }

        /// <summary>
        /// Gets a list of all the usernames in the table.
        /// </summary>
        /// <returns>A list of strings which are the existing usernames in the table.</returns>
        public static MySqlDataReader GetAccountReader(string username)
        {
            return GetReaderFromQuery($"SELECT * FROM account WHERE username='{username}';");
        }

        /// <summary>
        /// Gets a reader of all the usernames in the table.
        /// </summary>
        /// <returns>A Reader of allyyyy existing usernames in the table.</returns>
        public static MySqlDataReader GetAccountReader()
        {
            return GetReaderFromQuery($"SELECT * FROM account;");
        }

        /// <summary>
        /// Returns a reader of a pokemon
        /// </summary>
        /// <param name="pokemonName">The name of the pokemon to get data of.</param>
        /// <returns></returns>
        public static MySqlDataReader GetPokemonReader(string pokemonName)
        {
            return GetReaderFromQuery($"SELECT * FROM pokemon WHERE pokemonName='{pokemonName}';"); 
        }

        public static MySqlDataReader GetItemReader(string itemName)
        {
            return GetReaderFromQuery($"SELECT * FROM Item WHERE itemName='{itemName}';");
        }
        public static MySqlDataReader GetAbilityReader(string abilityName)
        {
            return GetReaderFromQuery($"SELECT * FROM Ability WHERE itemName='{abilityName}';");
        }

        public static MySqlDataReader GetRegionReader(string regionName)
        {
            return GetReaderFromQuery($"SELECT * FROM Region WHERE itemName='{regionName}';");
        }



        /// <summary>
        /// This method returns a null value for MySqlDataReader.
        /// </summary>
        /// <returns>null value for a MySqlDataReader placeholder.</returns>
        public static MySqlDataReader GetNullReader()
        {
            return null;
        }

        public static MySqlDataReader GetItemsOwnedReader(string username)
        {
            return null;
        }
    }
}
