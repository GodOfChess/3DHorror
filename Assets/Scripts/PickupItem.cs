﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupItem : MonoBehaviour
{
    public string ItemName;

    bool enter = false;

    GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && enter)
        {
            player = GameObject.Find("Player");
            player.GetComponent<PlayerInventory>().PlaceIntoInventory(ItemName);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        
        if (other.CompareTag("Player"))
        {
            Debug.Log("player");
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
            GUI.Label(new Rect(Screen.width / 2 - 75, Screen.height - 100, 155, 30), "Press 'E' to pick up the " + ItemName);
        }
    }
}