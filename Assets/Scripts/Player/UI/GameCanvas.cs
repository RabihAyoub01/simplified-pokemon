using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace GameUICanvas
{
    public class GameCanvas : MonoBehaviour
    {

        public static GameCanvas instance;

        public GameObject pausePanel;
        public GameObject bagPanel;
        public GameObject pokemonPanel;

        public GameObject bagScrollView;
        public GameObject pokemonScrollView;

        public TextMeshProUGUI menuLabel;

        private void Awake()
        {
            if (instance == null) { instance = this; }
            HideAllPanels();
        }

        void Start()
        {
            menuLabel.text = $"{PlayerController.GetInstanceUsername()}'s Menu";
        }

        void Update()
        {

        }

        public void ShowBagPanel()
        {
            bagPanel.SetActive(true);
            pokemonPanel.SetActive(false);
        }

        public void ShowPokemonPanel()
        {
            bagPanel.SetActive(false);
            pokemonPanel.SetActive(true);
        }

        public void ShowPausePanel()
        {
            bagPanel.SetActive(false);
            pokemonPanel.SetActive(false);
            pausePanel.SetActive(true);
        }

        public void HideAllPanels()
        {
            bagPanel.SetActive(false);
            pokemonPanel.SetActive(false);
            pausePanel.SetActive(false);
        }
    }
}

