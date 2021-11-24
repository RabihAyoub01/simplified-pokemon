using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UICanvas;

public class AdminWindow : MonoBehaviour
{
    public GameObject attributePanel;

    private void Awake()
    {
        InputField[] inputFields = attributePanel.GetComponentsInChildren<InputField>();

        for (int i = 0; i < inputFields.Length; i++)
        {
            inputFields[i].text = i + 1 + "";
        }
    }

    private void Start()
    {

    }
}
