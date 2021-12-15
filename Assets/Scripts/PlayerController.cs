using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private Animator door = null;
    
    public GameObject ghost;
    public GameObject rain;
    public static bool isInHouse = true;
    private Ghost ghostController;

    private void Start()
    {
        ghostController = ghost.GetComponent<Ghost>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "HouseHunt")
        {
            door.Play("doorClose", 0, 0.0f);
            isInHouse = false;
            rain.SetActive(false);
            other.gameObject.SetActive(false);
            StartCoroutine(ghostController.StartHunt());
        }
    }
}
