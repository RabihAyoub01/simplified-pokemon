using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using SQLHelper;


public class BagWindow : MonoBehaviour
{
    string username = "";
    public GameObject rowPrefab;
    public GameObject bagContent;
       
    // Use this for initialization
    void Start()
    {
        string username = PlayerController.GetInstanceUsername();
        //ShowBag();
        AddItemToDisplay("hello", "world", "ge");
        AddItemToDisplay("hello", "world", "ge");
        AddItemToDisplay("hello", "world", "ge");
        AddItemToDisplay("hello", "world", "ge");
        AddItemToDisplay("hello", "world", "ge");
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void ShowBag()
    {
        using (var reader = SQLConnector.GetItemsOwnedReader(username))
        {
            while (reader.Read())
            {
                AddItemToDisplay(reader.GetString("itemName"), reader.GetString("quantity"), "");
            }
        }
    }

    private void AddItemToDisplay(string itemName, string quantity, string description)
    {
        GameObject go = Instantiate(rowPrefab);
        
        Text[] inputfields =  go.GetComponentsInChildren<Text>();

        inputfields[0].text = itemName;
        inputfields[1].text = quantity;
        inputfields[2].text = description;

        go.transform.SetParent(bagContent.transform, false);
    } 
}
