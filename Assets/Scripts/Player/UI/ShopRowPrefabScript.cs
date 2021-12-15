using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopRowPrefabScript : MonoBehaviour
{

    public Text itemName;
    public Text itemPrice; 
    public Button decrementQtyBtn; 
    public Button incrementQtyBtn;
    public InputField qtyTF;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Setup(string itemName, string itemPrice)
    {
        this.itemName.text = itemName;
        this.itemPrice.text = itemPrice;
        qtyTF.text = "0";
    }

    public void IncrementTF()
    {
        qtyTF.text = int.Parse(qtyTF.text) + 1 + "";
    }

    public void DecrementTF()
    {
        if (int.Parse(qtyTF.text) > 0)
            qtyTF.text = int.Parse(qtyTF.text) - 1 + "";
    }
}
