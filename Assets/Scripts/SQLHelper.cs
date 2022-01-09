using UnityEngine;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;

using Random = System.Random;

namespace SQLHelper
{
    class SQLConnector
    { 
        static MySqlConnection conn = new MySqlConnection();
        static MySqlCommand cmd = new MySqlCommand();  // this is a "cursor" that edits data
        
        /// <summary>
        /// In the constructor, the code calls ConnectDB() method.
        /// </summary>
        public SQLConnector()
        {
            if (conn.ConnectionString == "")  // checks if connection is not already established
                ConnectDB();
        }

        /// <summary>
        /// Connects the code to the database.
        /// </summary>
        private void ConnectDB()
        {
            string connectionPassword = Environment.GetEnvironmentVariable("SimplifiedPokemonDBpswd");
            string connectionString = $"server=remotemysql.com; uid=cII0ueGbDG;pwd={connectionPassword};database=cII0ueGbDG";

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
            ExecuteQuery($"INSERT INTO account VALUES('{username}', '{password}', {1000});");
        }


        public static void InsertPokemon(string pokemonName, string type1, string type2, int baseHP, int baseATK, int baseDEF, int baseSPD)
        {
            ExecuteQuery($"INSERT INTO pokemon VALUES('{pokemonName}', '{type1}', '{type2}', '{baseHP}', '{baseATK}', '{baseDEF}','{baseSPD}');");
        }

        public static void removePokemon(string pokemonName)
        {
           ExecuteQuery($"DELETE FROM pokemon WHERE pokemonName='{pokemonName}';");
        }

        public static void removeItem(string itemName)
        {
            ExecuteQuery($"DELETE FROM Items WHERE itemName='{itemName}';");
        }

        public static void updatePokemon(string pokemonName, string type1, string type2, int baseHP, int baseATK, int baseDEF, int baseSPD)
        {
            ExecuteQuery($"UPDATE pokemon SET type1='{type1}', type2='{type2}', baseHP='{baseHP}', baseATK='{baseATK}', baseDEF='{baseDEF}', baseSPD='{baseSPD}' WHERE pokemonName='{pokemonName}'; ");
        } // 

        public static void updateItems(string itemName, int itemPrice, string effect)
        {
            ExecuteQuery($"UPDATE pokemon SET itemPrice='{itemPrice}', effect='{effect}'; ");
        }

        public static void updateItemOwned(string username, string itemName, int newQuantity)
        {
            ExecuteQuery($"UPDATE hasItem SET quantity='{newQuantity}' WHERE username='{username}' AND itemName = '{itemName}' ;");
        }

        public static void updateAbility(string abilityName, string abilityType)
        {
            ExecuteQuery($"UPDATE Ability SET abilityName='{abilityName}', abilityType='{abilityType}'; ");
        }

        public static void updateBalance(string username, int coins)
        {
            ExecuteQuery($"UPDATE account SET coins='{coins}' WHERE username='{username}';");
        }

        public static void removeAbility(string abilityName)
        {
            ExecuteQuery($"DELETE FROM Ability WHERE abilityName='{abilityName}';");
        }

        public static void InsertAbility(string abilityName, string abilityType)
        {
            ExecuteQuery($"INSERT INTO ability VALUES('{abilityName}', '{abilityType}');");
        }

        public static void InsertRegion(string regionName, int minLevel, int maxLevel)
        {
            ExecuteQuery($"INSERT INTO Region VALUES('{regionName}', '{minLevel}', '{maxLevel}');");
        }

        public static void updateRegion(string regionName, int minLevel, int maxLevel)
        {
            ExecuteQuery($"UPDATE Region SET regionName='{regionName}', minLevel='{minLevel}', maxLevel = '{maxLevel}'; ");
        }
        public static void removeRegion(string regionName)
        {
            ExecuteQuery($"DELETE FROM Region WHERE regionName='{regionName}';");
        }

        public static void InsertPokemonCopy(string pokemonID, int pokemonLevel, int hitpoints, string pokemonName)
        {
            ExecuteQuery($"INSERT INTO pokemonCopy VALUES('{pokemonID}', {pokemonLevel}, {hitpoints}, '{pokemonName}');");
        }

        public static void updatePokemonCopy(string pokemonID, int pokemonLevel, int hitpoints, string pokemonName)
        {
            ExecuteQuery($"UPDATE pokemonCopy SET pokemonID='{pokemonID}', pokemonLevel={pokemonLevel}, hitpoints={hitpoints}, pokemonName='{pokemonName}'; ");
        }

        public static void removePokemonCopy(string pokemonID)
        {
            ExecuteQuery($"DELETE FROM pokemonCopy WHERE pokemonID='{pokemonID}';");
        }

        public static void InsertItems(string itemName, int itemPrice, string effect)
        {
            ExecuteQuery($"INSERT INTO Items VALUES('{itemName}', '{itemPrice}','{effect}');");
        }

        public static void InsertItemToPlayer(string username, string itemName, int quantity)
        {
            ExecuteQuery($"INSERT INTO hasItem VALUES('{username}', '{itemName}','{quantity}');");
        }

        public static void InsertTrainer(string trainerID, int level, string name)
        {
            ExecuteQuery($"INSERT INTO trainer VALUES('{trainerID}', '{level}', '{name}');");
        }

        public static void updateTrainer(string trainerID, string trainerName, int trainerLevel, string pokemonID)
        {
            ExecuteQuery($"UPDATE Trainer SET trainerID='{trainerID}', trainerName='{trainerName}', trainerLevel = '{trainerLevel}', pokemonID = '{pokemonID}'; ");
        }
        public static void removeTrainer(string trainerID)
        {
            ExecuteQuery($"DELETE FROM Trainer WHERE trainerID='{trainerID}';");
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

        public static MySqlDataReader GetPokemonCopyReader(string pokemonID)
        {
            return GetReaderFromQuery($"SELECT * FROM pokemonCopy WHERE pokemonID='{pokemonID}';");
        }

        public static MySqlDataReader GetItemReader(string itemName)
        {
            return GetReaderFromQuery($"SELECT * FROM Items WHERE ItemName='{itemName}';"); 
        }

        public static MySqlDataReader GetAbilityReader(string abilityName)
        {
            return GetReaderFromQuery($"SELECT * FROM Ability WHERE abilityName='{abilityName}';");
        }

        public static MySqlDataReader GetRegionReader(string regionName)
        {
            return GetReaderFromQuery($"SELECT * FROM Region WHERE regionName='{regionName}' ;");
        }
        public static MySqlDataReader GetTrainerReader(string trainerID)
        {
            return GetReaderFromQuery($"SELECT * FROM Trainer WHERE trainerID='{trainerID}' ;");
        }

        public static MySqlDataReader GetShopReader(string shopID)
        {
            return GetReaderFromQuery($"SELECT * FROM Shop WHERE shopID='{shopID}' ;");
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
            return GetReaderFromQuery($"SELECT ItemName, quantity, ItemDescription  FROM Items NATURAL JOIN hasItem WHERE username='{username}';");
        }
        public static MySqlDataReader GetLevel(string region)
        {
            return GetReaderFromQuery($"SELECT minLevel, maxLevel FROM Region regionName='{region}';");
        }

        public static MySqlDataReader GetPokemonIDReader(string region)
        {
            return GetReaderFromQuery($"SELECT pokemonID FROM hasPokemon NATURAL JOIN Region NATURAL JOIN pokemonCopy WHERE Region.regionName='{region}' ORDER BY RAND() lIMIT 1;");
        }

        public static MySqlDataReader CheckIfOwnedReader(string username)
        {
            return GetReaderFromQuery($"SELECT ItemName  FROM Items NATURAL JOIN hasItem WHERE username='{username}';");
        }

        public static MySqlDataReader GetItemsInShop(string shopID)
        {
            return GetReaderFromQuery($"SELECT T.* FROM itemSoldIn S NATURAL JOIN Items T WHERE shopID='{shopID}'");
        }

        public static MySqlDataReader GetPokemonOwnedBy(string username)
        {
            return GetReaderFromQuery($"SELECT * FROM pokemonCopy S NATURAL JOIN pokemon T WHERE username='{username}'");
        }

        public static void InsertShop(string shopID)
        {
             ExecuteQuery($"INSERT INTO Shop VALUES('{shopID}');");
        }

        public static void updateShop(string shopID)
        {
            ExecuteQuery($"UPDATE Shop SET shopID='{shopID}'; ");
        }
        public static void removeShop(string shopID)
        {
            ExecuteQuery($"DELETE FROM Shop WHERE shopID='{shopID}';");
        }

        }

    }
