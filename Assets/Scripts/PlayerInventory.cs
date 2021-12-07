using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    public List<string> InventoryList;
    private void Start()
    {
        InventoryList.Add("NO_KEY");
    }
    public void PlaceIntoInventory(string itemName)
    {
        InventoryList.Add(itemName);
        Debug.Log(InventoryList);
    }

    public bool CheckInventoryFor(string itemName)
    {
        bool item = InventoryList.Contains(itemName);
        return item;
    }
}
