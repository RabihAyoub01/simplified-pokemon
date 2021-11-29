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
    InputField inputEntityNameTF = null;
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
        inputEntityNameTF = CanvasMethods.instance.inputEntityNameTF;
        inputFields = attributePanel.GetComponentsInChildren<InputField>();

        for (int i = 0; i < inputFields.Length; i++)  // u can remove that
        {
            inputFields[i].text = i + 1 + "";
        }
    }

    /// <summary>
    /// Method runs when the Magnifier is pressed.
    /// This method will create an instance of MySqlReader, initialized to null.
    /// Then, depending on the case, it will give the reader the output of the 
    /// relevant SELECT querry.
    /// To change the input fields, we construct a string[] array where we store all
    /// the attributes, which will later be passed on to the SetInputFields(string[]) method.
    /// </summary>
    public void MagnifierPressed()
    {
        if (updateToggle.isOn)  // Makes sure that the update is chosen.
        {
            int numOfAttributes = 0;  // The number of columns in the table we're fetching from.
            string entityName = inputEntityNameTF.text;  // The name of the entity we will be looking for.

            var reader = SQLConnector.GetNullReader();  // The MySqlReader instance.

            switch (entityDropdown.options[entityDropdown.value].text)
            {
                case "Pokemon":
                    // TODO 4. Set the `reader` var to be the pokemon reader associated to `entityName`.
                    // Means you have to get the reader using the method you created in TODO 3.

                    // TODO 5. Set the `numOfAttributes` variable to be equal to the number of variable in the pokemon table, 7.
                    // Yes, you just need to do `numOfAttributes = 7`.
                    break;

                case "Item":
                    break;

                case "Ability":
                    break;

                case "Region":
                    break;

                default:
                    break;
            }

            string[] attributes = new string[numOfAttributes];  // This is the attributes string[] array that will hold all
                                                                // attributes values of the entity instance we found.
                                                                // That's why `attributes.Length` = `numOfAttributes` obviously.
            
            if (reader.Read())  // checks if there is at least 1 row in the reader, and reads it if there is.
            {
                for (int i = 0; i < numOfAttributes; i++)
                {
                    // TODO 6. fill in attributes[i] with each `reader.GetString(i)`.
                }
            } 
            else  // if there are 0 rows in the reader, means no output rows were returned from the Query.
            {
                Debug.Log("No Entity Found");
            }

            reader.Close();  // closes reader connection.

            // TODO 7. Call the SetInputFields(string[]) function and pass attributes as argument.
        }
    }

    /// <summary>
    /// Method runs when the commit button is pressed.
    /// The method will insert, update, or delete to the database depending 
    /// on the option of the Toggle. Moreover, it will target many tables, 
    /// depending on the option chosen from the dropdown box.
    /// </summary>
    public void CommitPressed()
    {
        switch (entityDropdown.options[entityDropdown.value].text)  // passes the value of the dropdown to a switch
        {
            case "Pokemon":
                // TODO 9. Fill in the "Pokemon" case of the switch statement.
                // Don't forget to use `inputFields[].text` to get the attributes.
                if (insertToggle.isOn)  // tests if the insert Toggle is selected
                {
                    Debug.Log("Tried to insert Pokemon");
                    // Call insert for pokemon.
                } 
                else if (updateToggle.isOn)  // tests if the update Toggle is selected
                {
                    Debug.Log("Trid to update Pokemon");
                    // Call update for pokemon.
                }
                else  // means Delete is selected
                {
                    Debug.Log("Trid to delete Pokemon");
                    // Call remove for pokemon.
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

    /// <summary>
    /// This method takes in a string[] list as argument, and fills the first `attributes.Length`
    /// number of input fields with each attributes[i] for i going from 0 to attributes.Length- 1 inclusive.
    /// That's the method that displays the current values of Entities in the inputFields when we press on
    /// the Magnifier.
    /// </summary>
    /// <param name="attributes">The list of the attributes.</param>
    private void SetInputFields(string[] attributes)
    {
        for (int i = 0; i < attributes.Length; i++)
        {
            // TODO 8. use the `inputFields[]` and `attributes` arrays to complete the method.
        }
    }
}
