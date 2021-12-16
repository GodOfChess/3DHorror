using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PickupItem : MonoBehaviour
{
    public string ItemName;

    bool enter = false;
    private int countKey;
    public Text countText;
    private bool isGet;

    public GameObject player;
    private PlayerInventory inventory;

    void Start()
    {
        inventory = player.GetComponent<PlayerInventory>();
    }


    void Update()
    {
    }

    private void OnTriggerEnter(Collider other)
    {
        isGet = false;
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

    private void OnTriggerStay(Collider other)
    {
        if (isGet == false && Input.GetKeyDown(KeyCode.E) && enter)
        {
            isGet = true;
            inventory.PlaceIntoInventory(ItemName);
            Destroy(gameObject);
            countText.text = $"Собрано ключей: {countKey}";
            countKey++;
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
