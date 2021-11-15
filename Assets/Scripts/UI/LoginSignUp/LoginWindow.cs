using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using SQLHelper;

public class LoginWindow : MonoBehaviour
{
    public GameObject signUpPanel;
    public GameObject loginPanel;

    public InputField inputUsernameTF;
    public InputField inputPasswordTF;

    private void Awake()
    {
        new SQLConnector();
    }

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    /// <summary>
    /// This method changes the view from Login to Signup Panel and clears the inputs.
    /// </summary>
    public void NoAccountPressed()
    {
        inputUsernameTF.text = "";
        inputPasswordTF.text = "";
        loginPanel.SetActive(false);
        signUpPanel.SetActive(true);
    }

    /// <summary>
    /// Ignore that for now.
    /// </summary>
    private void OnApplicationQuit()
    {
        SQLConnector.CloseConnection();
        Debug.Log("Connection Closed.");
    }
}
