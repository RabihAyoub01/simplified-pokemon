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
        ClearInputFields();
        CanvasMethods.instance.ShowSignUpScreen();
    }

    /// <summary>
    /// This method runs when the Login Button is pressed in the login screen.
    /// </summary>
    public void LoginPressed()
    {
        if (CanvasMethods.instance.inputUsernameLoginTF.text == "admin" && CanvasMethods.instance.inputPasswordLoginTF.text == "admin")
        {
            ClearInputFields();
            CanvasMethods.instance.ShowAdminScreen();
        }

        using (var reader = SQLConnector.GetAccountReader(CanvasMethods.instance.inputUsernameLoginTF.text))
        {
            if (reader.Read() && reader.GetString("password") == CanvasMethods.instance.inputPasswordLoginTF.text )
            {
                PlayerController.SetInstanceUsername(CanvasMethods.instance.inputUsernameLoginTF.text);
                SceneManager.LoadScene("Game");
            } else
            {
                Debug.Log("Account not Found");
            }
        }
    }

    private void ClearInputFields()
    {
        CanvasMethods.instance.inputUsernameLoginTF.text = "";
        CanvasMethods.instance.inputPasswordLoginTF.text = "";
    }
}

