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
    }

    /// <summary>
    /// Runs when the log out button is pressed on the admin window.
    /// </summary>
    public void LogOutPressed()
    {
        CanvasMethods.instance.ShowLoginScreen();
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
        int numOfAttributes = 0;  // The number of columns in the table we're fetching from.
        string entityName = inputEntityNameTF.text;  // The name of the entity we will be looking for.

        var reader = SQLConnector.GetNullReader();  // The MySqlReader instance.

        switch (entityDropdown.options[entityDropdown.value].text)
        {
            case "Pokemon":
                reader = SQLConnector.GetPokemonReader(entityName);

                numOfAttributes = 7;
                break;

            case "PokemonCopy":
                reader = SQLConnector.GetPokemonCopyReader(entityName);

                numOfAttributes = 4;
                break;

            case "Item":
                reader = SQLConnector.GetItemReader(entityName);

                numOfAttributes = 3;
                break;

            case "Ability":
                reader = SQLConnector.GetAbilityReader(entityName);

                numOfAttributes = 2;
                break;

            case "Region":
                reader = SQLConnector.GetRegionReader(entityName);

                numOfAttributes = 3;
                break;

            case "Trainer":
                reader = SQLConnector.GetTrainerReader(entityName);

                numOfAttributes = 4;
                break;

            case "Shop":
                reader = SQLConnector.GetShopReader(entityName);

                numOfAttributes = 1;
                break;

            default:
                return;
        }

        string[] attributes = new string[numOfAttributes];  // This is the attributes string[] array that will hold all
                                                            // attributes values of the entity instance we found.
                                                            // That's why `attributes.Length` = `numOfAttributes` obviously.
            
        if (reader.Read())  // checks if there is at least 1 row in the reader, and reads it if there is.
        {
            for (int i = 0; i < numOfAttributes; i++)
            {
                attributes[i]=reader.GetString(i);
            }
        } 
        else  // if there are 0 rows in the reader, means no output rows were returned from the Query.
        {
            Debug.Log("No Entity Found");
        }

        reader.Close();  // closes reader connection.

        SetInputFields(attributes);
            
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
                if (insertToggle.isOn)  // tests if the insert Toggle is selected
                {
                    Debug.Log("Tried to insert Pokemon");
                    SQLConnector.InsertPokemon(inputFields[0].text, inputFields[1].text, inputFields[2].text, int.Parse(inputFields[3].text), int.Parse(inputFields[4].text), int.Parse(inputFields[5].text), int.Parse(inputFields[6].text));
                } 
                else if (updateToggle.isOn)  // tests if the update Toggle is selected
                {
                    Debug.Log("Tried to update Pokemon");
                    SQLConnector.updatePokemon(inputFields[0].text, inputFields[1].text, inputFields[2].text, int.Parse(inputFields[3].text), int.Parse(inputFields[4].text), int.Parse(inputFields[5].text), int.Parse(inputFields[6].text));
                }
                else  // means Delete is selected
                {
                    Debug.Log("Tried to delete Pokemon");
                    SQLConnector.removePokemon(inputFields[0].text);
                }

                break;

            case "PokemonCopy":
                if (insertToggle.isOn)  // tests if the insert Toggle is selected
                {
                    Debug.Log("Tried to insert PokemonCopy");
                    SQLConnector.InsertPokemonCopy(inputFields[0].text, int.Parse(inputFields[1].text), int.Parse(inputFields[2].text), inputFields[3].text);
                }
                else if (updateToggle.isOn)  // tests if the update Toggle is selected
                {
                    Debug.Log("Tried to update PokemonCopy");
                    SQLConnector.updatePokemonCopy(inputFields[0].text, int.Parse(inputFields[1].text), int.Parse(inputFields[2].text), inputFields[3].text);
                }
                else  // means Delete is selected
                {
                    Debug.Log("Tried to delete PokemonCopy");
                    SQLConnector.removePokemonCopy(inputFields[0].text);
                }

                break;

            case "Item":
                if (insertToggle.isOn)  // tests if the insert Toggle is selected
                {
                    Debug.Log("Tried to insert Item");
                    SQLConnector.InsertItems(inputFields[0].text, int.Parse(inputFields[1].text), inputFields[2].text);
                } 
                else if (updateToggle.isOn)  // tests if the update Toggle is selected
                {
                    Debug.Log("Tried to update Item");
                    SQLConnector.updateItems(inputFields[0].text, int.Parse(inputFields[1].text), inputFields[2].text);
                }
                else  // means Delete is selected
                {
                    Debug.Log("Tried to delete Item");
                    SQLConnector.removeItem(inputFields[0].text);
                }
                break;

            case "Ability":
                if (insertToggle.isOn)  // tests if the insert Toggle is selected
                {
                    Debug.Log("Tried to insert Ability");
                    SQLConnector.InsertAbility(inputFields[0].text, inputFields[1].text);
                }
                else if (updateToggle.isOn)  // tests if the update Toggle is selected
                {
                    Debug.Log("Tried to update Ability");
                    SQLConnector.updateAbility(inputFields[0].text, inputFields[1].text);
                }
                else  // means Delete is selected
                {
                    Debug.Log("Tried to delete Ability");
                    SQLConnector.removeAbility(inputFields[0].text);
                }
                break;

            case "Region":
                if (insertToggle.isOn)  // tests if the insert Toggle is selected
                {
                    Debug.Log("Tried to insert Region");
                    SQLConnector.InsertRegion(inputFields[0].text, int.Parse(inputFields[1].text), int.Parse(inputFields[2].text));
                }
                else if (updateToggle.isOn)  // tests if the update Toggle is selected
                {
                    Debug.Log("Tried to update Region");
                    SQLConnector.updateRegion(inputFields[0].text, int.Parse(inputFields[1].text), int.Parse(inputFields[2].text));
                }
                else  // means Delete is selected
                {
                    Debug.Log("Tried to delete Region");
                    SQLConnector.removeRegion(inputFields[0].text);
                }
                break;

            case "Trainer":
                if (insertToggle.isOn)  // tests if the insert Toggle is selected
                {
                    Debug.Log("Tried to insert Trainer");
                    SQLConnector.InsertTrainer(inputFields[0].text, int.Parse(inputFields[2].text), inputFields[3].text);
                }
                else if (updateToggle.isOn)  // tests if the update Toggle is selected
                {
                    Debug.Log("Tried to update Trainer");
                    SQLConnector.updateTrainer(inputFields[0].text, inputFields[1].text, int.Parse(inputFields[2].text), inputFields[3].text);
                }
                else  // means Delete is selected
                {
                    Debug.Log("Tried to delete Trainer");
                    SQLConnector.removeTrainer(inputFields[0].text);
                }
                break;

            case "Shop":
                if (insertToggle.isOn)  // tests if the insert Toggle is selected
                {
                    Debug.Log("Tried to insert Shop");
                    SQLConnector.InsertShop(inputFields[0].text);
                }
                else if (updateToggle.isOn)  // tests if the update Toggle is selected
                {
                    Debug.Log("Tried to update Shop");
                    SQLConnector.updateShop(inputFields[0].text);
                }
                else  // means Delete is selected
                {
                    Debug.Log("Tried to delete Shop");
                    SQLConnector.removeShop(inputFields[0].text);
                }
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
            inputFields[i].text = attributes[i];
        }
    }
}
