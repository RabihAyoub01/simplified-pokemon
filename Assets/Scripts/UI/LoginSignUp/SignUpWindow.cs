using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using SQLHelper;
using UICanvas;

public class SignUpWindow : MonoBehaviour
{
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
        string inputUsername = CanvasMethods.instance.inputUsernameSignUpTF.text;  // string of username input in SignUpWindow.
        string inputPassword = CanvasMethods.instance.inputPasswordSignUpTF.text;  // string of password input in SignUpWindow.
        string inputConfirmPassword = CanvasMethods.instance.inputPasswordConfirmSignUpTF.text;  // string of password confirm input in SignUpWindow.
               
        if(inputPassword == inputConfirmPassword)
        {
            SQLConnector.CreateAccount(inputUsername, inputPassword);
            Debug.Log("passwords match and account created");
        }
    }

    /// <summary>
    /// This method changes the view from SignUp to Login Panel and clears the inputs.
    /// </summary>
    public void goBackToLoginScreen()
    {
        CanvasMethods.instance.inputUsernameSignUpTF.text = "";
        CanvasMethods.instance.inputPasswordSignUpTF.text = "";
        CanvasMethods.instance.inputPasswordConfirmSignUpTF.text = "";
        CanvasMethods.instance.ShowLoginScreen();
    }
}
