﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorOpen : MonoBehaviour
{
    // Smoothly open a door
    public AnimationCurve openSpeedCurve = new AnimationCurve(new Keyframe[] { new Keyframe(0, 1, 0, 0), new Keyframe(0.8f, 1, 0, 0), new Keyframe(1, 0, 0, 0) }); //Contols the open speed at a specific time (ex. the door opens fast at the start then slows down at the end)
    public float openSpeedMultiplier = 2.0f; //Increasing this value will make the door open faster
    public float doorOpenAngle = 90.0f; //Global door open speed that will multiply the openSpeedCurve
    public string keyName = "NO_KEY";

    bool open = false;
    bool enter = false;

    float defaultRotationAngle;
    float currentRotationAngle;
    float openTime = 0;

    GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        defaultRotationAngle = transform.localEulerAngles.y;
        currentRotationAngle = transform.localEulerAngles.y;

        //Set Collider as trigger
        GetComponent<Collider>().isTrigger = true;
    }

    // Update is called once per frame
    void Update()
    {

        if (openTime < 1)
        {
            openTime += Time.deltaTime * openSpeedMultiplier * openSpeedCurve.Evaluate(openTime);
        }
        transform.localEulerAngles = new Vector3(transform.localEulerAngles.x, Mathf.LerpAngle(currentRotationAngle, defaultRotationAngle + (open ? doorOpenAngle : 0), openTime), transform.localEulerAngles.z);

        if (Input.GetKeyDown(KeyCode.F) && enter)
        {
            player = GameObject.Find("Player");
            bool hasKey = player.GetComponent<PlayerInventory>().CheckInventoryFor(keyName); //requires player inventory to work

            if (hasKey == true)
            {
                Debug.Log("F");
                open = !open;
                currentRotationAngle = transform.localEulerAngles.y;
                openTime = 0;
            }
        }
    }

    // Display a simple info message when player is inside the trigger area (This is for testing purposes only so you can remove it)
    void OnGUI()
    {
        if (enter)
        {
            Debug.Log("rect");
            GUI.Label(new Rect(Screen.width / 2 - 75, Screen.height - 100, 155, 30), "Press 'F' to " + (open ? "close" : "open") + " the door");
        }
    }
    //

    // Activate the Main function when Player enter the trigger area
    void OnTriggerEnter(Collider other)
    {
        
        
        Debug.Log("asdf");
        if (other.CompareTag("Player"))
        {
            Debug.Log("player");
            enter = true;
        }
    }

    // Deactivate the Main function when Player exit the trigger area
    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            enter = false;
        }
    }
}
