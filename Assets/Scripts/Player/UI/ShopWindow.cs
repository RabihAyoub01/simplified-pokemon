using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SQLHelper;

public class ShopWindow : MonoBehaviour
{
    public GameObject shopContent;
    public string regionName;
    public ShopRowPrefabScript rowPrefab;
    // Start is called before the first frame update
    void Start()
    {
        OnShopWindowPanel();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnShopWindowPanel()
    {
        DestroyChildren(shopContent);
        LoadItems();
    }

    private void DestroyChildren(GameObject panel)
    {
        foreach (Transform child in panel.transform)
        {
            Destroy(child.gameObject);
        }
    }

    public void LoadItems()
    {
        using (var reader = SQLConnector.GetItemsInShop(regionName))
        {
            while (reader.Read())
            {
                AddShopRow(reader.GetString("ItemName"), reader.GetString("ItemPrice"));
            }
        }
    }

    private void AddShopRow(string itemName, string itemPrice)
    {
        ShopRowPrefabScript row =  Instantiate(rowPrefab);
        row.Setup(itemName, itemPrice);
        row.transform.SetParent(shopContent.transform, false);
    }
}
