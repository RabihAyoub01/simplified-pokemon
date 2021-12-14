using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SQLHelper;
using MySql.Data.MySqlClient;

public class Pickup : MonoBehaviour, Interactable
{
    public string[] itemOwned;
    int i=0;

    public void Interact()
    {
        
        
        SQLConnector.PickUp(PlayerController.GetInstanceUsername(), gameObject.name, 1);
        Destroy(gameObject);
        
    }
}
