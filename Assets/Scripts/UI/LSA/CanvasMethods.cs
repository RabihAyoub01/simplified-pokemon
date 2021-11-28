using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using SQLHelper;

namespace UICanvas
{
    public class CanvasMethods : MonoBehaviour
    {
        public static CanvasMethods instance;

        public GameObject signUpPanel;
        public GameObject loginPanel;
        public GameObject adminPanel;

        public GameObject attributePanel;
        public Dropdown entityDropdown;
        public Toggle insertToggle;
        public Toggle updateToggle;

        public InputField inputUsernameLoginTF;
        public InputField inputPasswordLoginTF;

        public InputField inputUsernameSignUpTF;
        public InputField inputPasswordSignUpTF;
        public InputField inputPasswordConfirmSignUpTF;



        void Awake()
        {
            if (instance == null) { instance = this; }
            Debug.Log("Canvas Initiated");
            new SQLConnector();  // Creates SQLConnector instance to open connection to DB.
        }

        void Start()
        {
            ShowLoginScreen();
        }

        void Update()
        {

        }

        public void ShowLoginScreen()
        {
            loginPanel.SetActive(false);
            signUpPanel.SetActive(false);
            adminPanel.SetActive(true);
        }

        public void ShowSignUpScreen()
        {
            loginPanel.SetActive(false);
            signUpPanel.SetActive(true);
        }


        /// <summary>
        /// Closes Connection when Application Quits.
        /// </summary>
        private void OnApplicationQuit()
        {
            SQLConnector.CloseConnection();
            Debug.Log("Connection Closed. Called From Canvas.");
        }
    }
} 

