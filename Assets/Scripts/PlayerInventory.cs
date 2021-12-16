using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    public GameObject flashLight;
    public AudioSource screamer;
    public List<string> Keys;
    private void Start()
    {
        Keys.Add("NO_KEY");
    }
    public void PlaceIntoInventory(string itemName)
    {
        Keys.Add(itemName);

        if (itemName == "FlashLight")
        {
            flashLight.SetActive(true);
            screamer.Play();
        }
    }

    public bool CheckInventoryFor(string itemName)
    {
        bool item = Keys.Contains(itemName);
        return item;
    }
}
