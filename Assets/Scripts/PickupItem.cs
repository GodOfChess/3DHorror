using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PickupItem : MonoBehaviour
{
    public string ItemName;

    bool enter = false;
    private static int countKey = 0;
    public Text countText;

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
            if (ItemName != "FlashLight")
            {
                countKey += 1;
                countText.text = $"Собрано ключей: {countKey}/7";
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
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
            GUI.Label(new Rect(Screen.width / 2 - 75, Screen.height - 100, 155, 40), "Нажмите 'E', чтобы взять " + ItemName);
        }
    }
}
