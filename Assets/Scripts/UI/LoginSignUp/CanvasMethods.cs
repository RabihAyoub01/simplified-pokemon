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

        public InputField inputUsernameLoginTF;
        public InputField inputPasswordLoginTF;

        public InputField inputUsernameSignUpTF;
        public InputField inputPasswordSignUpTF;
        public InputField inputPasswordConfirmSignUpTF;

        void Awake()
        {
            if (instance == null) { instance = this; }
            ShowLoginScreen();
            new SQLConnector();  // Creates SQLConnector instance to open connection to DB.
        }

        void Start()
        {

        }

        void Update()
        {

        }

        public void ShowLoginScreen()
        {
            loginPanel.SetActive(true);
            signUpPanel.SetActive(false);
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

