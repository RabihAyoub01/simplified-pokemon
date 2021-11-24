using System.Collections;
using System.Collections.Generic;
using UnityEngine;
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
}
