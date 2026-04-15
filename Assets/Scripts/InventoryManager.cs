using System;
using UnityEngine;
using System.IO;
using TMPro;

[Serializable]
public struct ItemProfile 
{
    public int balance;
    public string item1Name;
    public int item1Quantity;
    public int item1Price;
    public string item2Name;
    public int item2Quantity;
    public int item2Price;
    public string item3Name;
    public int item3Quantity;
    public int item3Price;
    public string item4Name;
    public int item4Quantity;
    public int item4Price;
    public string item5Name;
    public int item5Quantity;
    public int item5Price;
    public string item6Name;
    public int item6Quantity;
    public int item6Price;
    public string item7Name;
    public int item7Quantity;
    public int item7Price;
    public string item8Name;
    public int item8Quantity;
    public int item8Price;
}
public class InventoryManager : MonoBehaviour
{
    public int startingBalance;
    public string item1StartName;
    public int item1StartQuantity;
    public int item1StartPrice;
    public string item2StartName;
    public int item2StartQuantity;
    public int item2StartPrice;
    public string item3StartName;
    public int item3StartQuantity;
    public int item3StartPrice;
    public string item4StartName;
    public int item4StartQuantity;
    public int item4StartPrice;
    public string item5StartName;
    public int item5StartQuantity;
    public int item5StartPrice;
    public string item6StartName;
    public int item6StartQuantity;
    public int item6StartPrice;
    public string item7StartName;
    public int item7StartQuantity;
    public int item7StartPrice;
    public string item8StartName;
    public int item8StartQuantity;
    public int item8StartPrice;

    public TextMeshProUGUI item1ShopText;
    public TextMeshProUGUI item2ShopText;
    public TextMeshProUGUI item3ShopText;
    public TextMeshProUGUI item4ShopText;
    public TextMeshProUGUI item5ShopText;
    public TextMeshProUGUI item6ShopText;
    public TextMeshProUGUI item7ShopText;
    public TextMeshProUGUI item8ShopText;

    public TextMeshProUGUI item1OwnedText;
    public TextMeshProUGUI item2OwnedText;
    public TextMeshProUGUI item3OwnedText;
    public TextMeshProUGUI item4OwnedText;
    public TextMeshProUGUI item5OwnedText;
    public TextMeshProUGUI item6OwnedText;
    public TextMeshProUGUI item7OwnedText;
    public TextMeshProUGUI item8OwnedText;

    public TextMeshProUGUI BalanceText;

    const string INVENTORY_FILE = "Inventory.json";
    string filePath;
    public ItemProfile itemList;
    void Start()
    {
        filePath = Application.persistentDataPath;
        itemList = new ItemProfile();
        Debug.Log(filePath);
        loadInventory();
        item1ShopText.text = $"€{itemList.item1Price}";
        item2ShopText.text = $"€{itemList.item2Price}";
        item3ShopText.text = $"€{itemList.item3Price}";
        item4ShopText.text = $"€{itemList.item4Price}";
        item5ShopText.text = $"€{itemList.item5Price}";
        item6ShopText.text = $"€{itemList.item6Price}";
        item7ShopText.text = $"€{itemList.item7Price}";
        item8ShopText.text = $"€{itemList.item8Price}";
    }
    private void Update()
    {
        BalanceText.text = $"Balance: {itemList.balance}";

        item1OwnedText.text = $"{itemList.item1Name}: ({itemList.item1Quantity})";
        item2OwnedText.text = $"{itemList.item2Name}: ({itemList.item2Quantity})";
        item3OwnedText.text = $"{itemList.item3Name}: ({itemList.item3Quantity})";
        item4OwnedText.text = $"{itemList.item4Name}: ({itemList.item4Quantity})";
        item5OwnedText.text = $"{itemList.item5Name}: ({itemList.item5Quantity})";
        item6OwnedText.text = $"{itemList.item6Name}: ({itemList.item6Quantity})";
        item7OwnedText.text = $"{itemList.item7Name}: ({itemList.item7Quantity})";
        item8OwnedText.text = $"{itemList.item8Name}: ({itemList.item8Quantity})";
    }
    public void loadInventory()
    {
        if(File.Exists (filePath + "/" + INVENTORY_FILE)) { 

            //Code from here to the next note makes inventory status save between each run

            //string loadedJson = File.ReadAllText (filePath + "/" + INVENTORY_FILE);
            //itemList = JsonUtility.FromJson<ItemProfile> (loadedJson);
            //Debug.Log("File Loaded");
        //}
        //else
        //{

            //Uncomment code above to make inventory save between runs

            itemList.balance = startingBalance;
            itemList.item1Name = item1StartName;
            itemList.item1Quantity = item1StartQuantity;
            itemList.item1Price = item1StartPrice;
            itemList.item2Name = item2StartName;
            itemList.item2Quantity = item1StartQuantity;
            itemList.item2Price = item2StartPrice;
            itemList.item3Name = item3StartName;
            itemList.item3Quantity = item3StartQuantity;
            itemList.item3Price = item3StartPrice;
            itemList.item4Name = item4StartName;
            itemList.item4Quantity = item4StartQuantity;
            itemList.item4Price = item4StartPrice;
            itemList.item5Name = item5StartName;
            itemList.item5Quantity = item5StartQuantity;
            itemList.item5Price = item5StartPrice;
            itemList.item6Name = item6StartName;
            itemList.item6Quantity = item6StartQuantity;
            itemList.item6Price = item6StartPrice;
            itemList.item7Name = item7StartName;
            itemList.item7Quantity = item7StartQuantity;
            itemList.item7Price = item7StartPrice;
            itemList.item8Name = item8StartName;
            itemList.item8Quantity = item8StartQuantity;
            itemList.item8Price = item8StartPrice;
            Debug.Log("No File Found");
        }
    }
    public void saveInventory()
    {
        string item1Json = JsonUtility.ToJson (itemList);
        File.WriteAllText (filePath + "/" + INVENTORY_FILE, item1Json);
        Debug.Log("Saved item to file");
    }

    public void purchaseItem(int itemIndex)
    {
        if (itemIndex == 1 && itemList.balance >= itemList.item1Price)
        {
            itemList.item1Quantity++;
            itemList.balance = itemList.balance - itemList.item1Price;
        }
        else if (itemIndex == 2 && itemList.balance >= itemList.item2Price)
        {
            itemList.item2Quantity++;
            itemList.balance = itemList.balance - itemList.item2Price;
        }
        else if (itemIndex == 3 && itemList.balance >= itemList.item3Price)
        {
            itemList.item3Quantity++;
            itemList.balance = itemList.balance - itemList.item3Price;
        }
        else if (itemIndex == 4 && itemList.balance >= itemList.item4Price)
        {
            itemList.item4Quantity++;
            itemList.balance = itemList.balance - itemList.item4Price;
        }
        else if (itemIndex == 5 && itemList.balance >= itemList.item5Price)
        {
            itemList.item5Quantity++;
            itemList.balance = itemList.balance - itemList.item5Price;
        }
        else if (itemIndex == 6 && itemList.balance >= itemList.item6Price)
        {
            itemList.item6Quantity++;
            itemList.balance = itemList.balance - itemList.item6Price;
        }
        else if (itemIndex == 7 && itemList.balance >= itemList.item7Price)
        {
            itemList.item7Quantity++;
            itemList.balance = itemList.balance - itemList.item7Price;
        }
        else if (itemIndex == 8 && itemList.balance >= itemList.item8Price)
        {
            itemList.item8Quantity++;
            itemList.balance = itemList.balance - itemList.item8Price;
        }
        saveInventory();
    }

    public void addIncome(int addAmount)
    {
        itemList.balance += addAmount;
    }
}
