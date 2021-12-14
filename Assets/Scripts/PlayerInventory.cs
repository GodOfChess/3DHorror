using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    public GameObject flashLight;
    public List<string> Keys;
    private void Start()
    {
        Keys.Add("NO_KEY");
    }
    public void PlaceIntoInventory(string itemName)
    {
        Keys.Add(itemName);
        Debug.Log(Keys);

        if (itemName == "FlashLight")
        {
            flashLight.SetActive(true);
        }
    }

    public bool CheckInventoryFor(string itemName)
    {
        bool item = Keys.Contains(itemName);
        return item;
    }
}
