using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PokemonRowPrefab : MonoBehaviour
{
    public Text pokemonName;
    public Text pokemonLevel;
    public Slider hpSlider;
    public Text type1;
    public Text type2;
    public Text pokemonHP;
    public Text pokemonATK;
    public Text pokemonDEF;
    public Text pokemonSPD;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //
    }
    public void Setup(string pokemonName, string pokemonLevel, int currentHP, int baseHP, string type1,
        string type2, int baseATK, int baseDEF, int baseSPD)
    {
        this.pokemonName.text = pokemonName;
        this.pokemonLevel.text = pokemonLevel;
        hpSlider.value = ((float) currentHP) / baseHP;
        this.type1.text = type1;
        this.type2.text = type2;
        pokemonHP.text = $"{currentHP} / {baseHP}";
        pokemonATK.text = baseATK + "";
        pokemonDEF.text = baseDEF + "";
        pokemonSPD.text = baseDEF + "";
    }
}
