using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SQLHelper;
using UnityEngine.UI;

public class AdminWindow : MonoBehaviour
{

    public GameObject attributePanel;
     void Awake()
    {
        Debug.Log("nabolsi");   
    }
     void Start()
    {
        InputField[] inputFields = attributePanel.GetComponents<InputField>();
        for(int i = 0; i < inputFields.Length; i++)
        {
            inputFields[i].text=i+1+"";
        }

    }
}
