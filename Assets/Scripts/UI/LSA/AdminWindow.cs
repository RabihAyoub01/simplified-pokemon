using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UICanvas;
using SQLHelper;

public class AdminWindow : MonoBehaviour
{
    GameObject attributePanel = null;
    Dropdown entityDropdown = null;
    InputField[] inputFields = null;
    Toggle insertToggle = null;
    Toggle updateToggle = null;

    void Awake()
    {

    }

    void Start()
    {
        attributePanel = CanvasMethods.instance.attributePanel;
        entityDropdown = CanvasMethods.instance.entityDropdown;
        insertToggle = CanvasMethods.instance.insertToggle;
        updateToggle = CanvasMethods.instance.updateToggle;
        inputFields = attributePanel.GetComponentsInChildren<InputField>();

        for (int i = 0; i < inputFields.Length; i++)  // u can remove that
        {
            inputFields[i].text = i + 1 + "";
        }



    }

    /// <summary>
    /// Method runs when the Magnifier is pressed.
    /// </summary>
    public void MagnifierPressed()
    {
        if (updateToggle.isOn)  // Make sure that the update is chosen.
        {
            using (var reader = SQLConnector.GetReaderFromQuery(""))  // TODO: Third. Fill Query.
            {
                if (reader.Read())
                {

                }
            }
        }
    }

    /// <summary>
    /// Method runs when the commit button is pressed.
    /// </summary>
    public void CommitPressed()
    {
        using (var reader = SQLConnector.GetAccountReader())
        {
            int i = 0;
            while (reader.Read())  // goes row by row.
            {
                if (i==2)
                    Debug.Log($"User {i} has username {reader.GetString("username")} and password {reader.GetString("password")}");
                i++;
            }
        }

        switch (entityDropdown.options[entityDropdown.value].text)  // passes the value of the dropdown to a switch
        {
            case "Pokemon":
                //TODO Fourth. Fill in the "Pokemon" case of the switch statement.
                if (insertToggle.isOn)  // tests if the insert Toggle is selected
                {
                    Debug.Log("Tried to insert Pokemon");
                    // call insert for pokemon
                } 
                else if (updateToggle.isOn)  // tests if the update Toggle is selected
                {
                    Debug.Log("Trid to update Pokemon");
                    // call update for pokemon
                }
                else  // means Delete is selected
                {
                    Debug.Log("Trid to delete Pokemon");
                    // call remove for pokemon
                }

                break;

            case "Item":
                break;

            case "Ability":
                break;

            case "Region":
                break;

            default:
                Debug.Log($"Unrecognized type for Dropdown menu: '{entityDropdown.options[entityDropdown.value].text}'");
                break;
        }
    }
}
