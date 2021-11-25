using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using SQLHelper;
using UICanvas;

public class LoginWindow : MonoBehaviour
{
    /// <summary>
    /// This method changes the view from Login to Signup Panel and clears the inputs.
    /// </summary>
    public void NoAccountPressed()
    {
        CanvasMethods.instance.inputUsernameLoginTF.text = "";
        CanvasMethods.instance.inputPasswordLoginTF.text = "";
        CanvasMethods.instance.ShowSignUpScreen();
    }

    /// <summary>
    /// This method runs when the Login Button is pressed in the login screen.
    /// </summary>
    public void LoginPressed()
    {
        SceneManager.LoadScene("Game");
    }
}
