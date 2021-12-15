using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SQLHelper;
using MySql.Data.MySqlClient;

public class Pickup : MonoBehaviour, Interactable
{
    

    private void GiveUsernameItems(string itemName, int amountToBuy)
    {
        string username = PlayerController.GetInstanceUsername();

        int amountInBag = 0;

        using (var reader = SQLConnector.GetItemsOwnedReader(username))
        {
            while (reader.Read())
                if (reader.GetString("itemName") == itemName)
                    amountInBag = int.Parse(reader.GetString("quantity"));
        }

        if (amountInBag > 0)
            SQLConnector.updateItemOwned(username, itemName, amountInBag + amountToBuy);
        else
            SQLConnector.InsertItemToPlayer(username, itemName, amountToBuy);
    }
    public void Interact()
    {
        GiveUsernameItems(gameObject.name, 1);
        Destroy(gameObject);
        
    }
}
