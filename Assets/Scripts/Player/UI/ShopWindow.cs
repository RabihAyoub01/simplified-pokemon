using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using SQLHelper;

public class ShopWindow : MonoBehaviour
{
    public GameObject shopContent;
    public GameObject shopPanel;
    public Text walletText;
    public string shopID;
    public ShopRowPrefabScript rowPrefab;

    public static ShopWindow instance;

    private void Awake()
    {
        Debug.Log("Shop initiated");
        if (instance == null) { instance = this; }
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public static void createInstance()
    {

    }

    public void OnShopWindowPanel()
    {
        shopPanel.SetActive(true);
        DestroyChildren(shopContent);
        LoadItems();
        LoadWallet();
    }

    public void closeShopPanel()
    {
        shopPanel.SetActive(false);
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
        using (var reader = SQLConnector.GetItemsInShop(shopID))
        {
            while (reader.Read())
            {
                AddShopRow(reader.GetString("ItemName"), reader.GetString("ItemPrice"));
            }
        }
    }

    public void LoadWallet()
    {
        string username = PlayerController.GetInstanceUsername();

        using (var reader = SQLConnector.GetAccountReader(username))
        {
            if (reader.Read())
            {
                walletText.text = $"{reader.GetInt16("coins")}";
            }
        }
    }

    public void BuyButtonPressed()
    {
        string username = PlayerController.GetInstanceUsername();

        ShopRowPrefabScript[] rows = shopContent.GetComponentsInChildren<ShopRowPrefabScript>();
        int sum = 0;
        foreach (ShopRowPrefabScript row in rows)
        {
            int amountToBuy = int.Parse(row.GetComponentInChildren<InputField>().text);
            if (amountToBuy > 0) {
                Text[] textLabels = row.GetComponentsInChildren<Text>();

                sum += amountToBuy * int.Parse(textLabels[1].text);
                GiveUsernameItems(textLabels[0].text, amountToBuy);
            }
        }
        SQLConnector.updateBalance(username, int.Parse(walletText.text) - sum);
        LoadWallet();
    }

    private void GiveUsernameItems(string itemName, int amountToBuy)
    {
        string username = PlayerController.GetInstanceUsername();

        int amountInBag = 0;

        using (var reader = SQLConnector.GetItemsOwnedReader(username))
        {
            while (reader.Read())
            {
                if (reader.GetString("itemName") == itemName)
                {
                    amountInBag = int.Parse(reader.GetString("quantity"));
                }
            }
        }

        if (amountInBag > 0)
        {
            Debug.Log("ran");
            SQLConnector.updateItemOwned(username, itemName, amountInBag + amountToBuy);
        }
        else 
        {
            SQLConnector.InsertItemToPlayer(username, itemName, amountToBuy);
        }
    }   

    private void AddShopRow(string itemName, string itemPrice)
    {
        ShopRowPrefabScript row = Instantiate(rowPrefab);
        row.Setup(itemName, itemPrice);
        row.transform.SetParent(shopContent.transform, false);
    }
}
