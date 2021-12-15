using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SQLHelper;
using MySql.Data.MySqlClient;

public class PokemonWindow : MonoBehaviour
{
    string username = "";
    public PokemonRowPrefab rowPrefab;
    public GameObject pokemonContent;
    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    /// <summary>
    /// Runs when Bag Window is Shown.
    /// </summary>
    public void OnShowPokemonPanel()
    {
        username = PlayerController.GetInstanceUsername();

        DestroyChildren(pokemonContent);
        LoadPokemons();
    }

    /// <summary>
    /// Ruthlessly Kills all children of the gameobject
    /// </summary>
    private void DestroyChildren(GameObject panel)
    {
        foreach (Transform child in panel.transform)
        {
            Destroy(child.gameObject);
        }
    }

    private void LoadPokemons()
    {

        using (var reader = SQLConnector.GetPokemonOwnedBy(username))
        {
            while (reader.Read())
            {

                AddPokemonRow(
                    reader.GetString("pokemonName"),
                    reader.GetString("pokemonLevel"),
                    reader.GetInt16("hitpoints"),
                    reader.GetInt16("baseHP"),
                    reader.GetString("type1"),
                    reader.GetString("type2"),
                    reader.GetInt16("baseATK"),
                    reader.GetInt16("baseDEF"),
                    reader.GetInt16("baseSPD")
                    );
            }
        }
    }

    private void AddPokemonRow(string pokemonName, string pokemonLevel, int currentHP, int baseHP, string type1,
        string type2, int baseATK, int baseDEF, int baseSPD)
    {
        PokemonRowPrefab row = Instantiate(rowPrefab);
        row.Setup(
            pokemonName, pokemonLevel, currentHP, baseHP, type1 , type2, baseATK, baseDEF, baseSPD
            );
        row.transform.SetParent(pokemonContent.transform, false);
    }
}
