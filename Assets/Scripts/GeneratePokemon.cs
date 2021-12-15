using MySql.Data.MySqlClient;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using random = System.Random;


public class GeneratePokemon : MonoBehaviour
{
    random ran= new random();

    static void Generate()
    {
        string attribute;
        MySqlDataReader reader = SQLHelper.SQLConnector.GetPokemonIDReader("Vermitown");
        while (reader.Read())
            attribute = reader.GetString(0);

    }






}
