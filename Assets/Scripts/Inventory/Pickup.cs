using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SQLHelper;
using MySql.Data.MySqlClient;

public class Pickup : MonoBehaviour, Interactable
{
    public string attribute;
    

    public void Interact()
    {
        MySqlDataReader reader = SQLConnector.GetItemsOwnedReader(PlayerController.GetInstanceUsername());
        while(reader.Read())
            attribute = reader.GetString(1);
        reader.Close();
        Debug.Log(attribute);

        SQLConnector.PickUp(PlayerController.GetInstanceUsername(), gameObject.name, 1);
        Destroy(gameObject);
        
    }
}
