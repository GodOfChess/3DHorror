using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupItem : MonoBehaviour
{
    public string ItemName;

    bool enter = false;

    public GameObject player;
    private PlayerInventory inventory;

    void Start()
    {
        inventory = player.GetComponent<PlayerInventory>();
    }


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && enter)
        {
            inventory.PlaceIntoInventory(ItemName);
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        
        if (other.CompareTag("Player"))
        {
            //Debug.Log("player");
            enter = true;
        }

    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            enter = false;
        }
    }

    void OnGUI()
    {
        if (enter)
        {
            Debug.Log("rect");
            GUI.Label(new Rect(Screen.width / 2 - 75, Screen.height - 100, 155, 40), "Press 'E' to pick up the " + ItemName);
        }
    }
}
