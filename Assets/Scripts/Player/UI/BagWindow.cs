using System.Collections;

using UnityEngine;
using UnityEngine.UI;
using SQLHelper;
using MySql.Data.MySqlClient;



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
        getItem();
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
                AddBagRow(reader.GetString("itemName"), reader.GetString("quantity"), "");
            }
        }
    }

    private void AddBagRow(string itemName, string quantity, string description)
    {
        GameObject go = Instantiate(rowPrefab);

        Text[] inputfields = go.GetComponentsInChildren<Text>();

        inputfields[0].text = itemName;
        inputfields[1].text = quantity;
        inputfields[2].text = description;

        go.transform.SetParent(bagContent.transform, false);
    }
    public void getItem()
    {
        
        MySqlDataReader reader = SQLConnector.GetItemsOwnedReader(PlayerController.GetInstanceUsername());
        while (reader.Read())  // checks if there is at least 1 row in the reader, and reads it if there is
        {
            AddBagRow(reader.GetString(0), reader.GetString(1), reader.GetString(2));
        }

        reader.Close();  // closes reader connection.
    }
}
