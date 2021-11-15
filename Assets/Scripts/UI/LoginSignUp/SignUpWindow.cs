using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using SQLHelper;

public class SignUpWindow : MonoBehaviour
{
    public InputField inputUsernameTF;
    public InputField inputPasswordTF;
    public InputField inputConfirmPasswordTF;

    public GameObject loginPanel;
    public GameObject signUpPanel;

    private void Awake()
    {

    }

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    /// <summary>
    /// This method runs when the create button is pressed in the SignUp Window.
    /// It inserts the new account in the database if the passwords and confirm passwords match.
    /// </summary>
    public void CreateAccountCheck()
    {
        string inputUsername = inputUsernameTF.text;  // string of username input in SignUpWindow.
        string inputPassword = inputPasswordTF.text;  // string of password input in SignUpWindow.
        string inputConfirmPassword = inputConfirmPasswordTF.text;  // string of password confirm input in SignUpWindow.

        // TODO: Fill the rest of the method. 
    }

    /// <summary>
    /// This method changes the view from SignUp to Login Panel and clears the inputs.
    /// </summary>
    public void goBackToLoginScreen()
    {
        // TODO: Fill in the method. Hint: similar to LoginWindow.NoAccountPressed()
    }

    private void OnApplicationQuit()
    {
        SQLConnector.CloseConnection();
        Debug.Log("Connection Closed.");
    }
}
