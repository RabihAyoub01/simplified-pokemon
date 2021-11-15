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

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void NoAccountPressed()
    {
        inputUsernameTF.text = "";
        inputPasswordTF.text = "";
        loginPanel.SetActive(false);
        signUpPanel.SetActive(true);
    }

    private void OnApplicationQuit()
    {
        SQLConnector.CloseConnection();
        Debug.Log("Connection Closed.");
    }
}
