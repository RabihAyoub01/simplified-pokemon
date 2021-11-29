using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameUICanvas;

public class PauseWindow : MonoBehaviour
{
    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void PausePressed()
    {
        GameCanvas.instance.ShowPausePanel();
    }

    public void ShowBagPressed()
    {
        GameCanvas.instance.ShowBagPanel();
    }
    public void ShowPokemonPressed()
    {
        GameCanvas.instance.ShowPokemonPanel();
    }

    public void ResumePressed()
    {
        GameCanvas.instance.HideAllPanels();
    }
}
