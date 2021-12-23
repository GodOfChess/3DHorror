using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private Animator door = null;
    
    public GameObject ghost;
    public GameObject rain;
    public static bool isInHouse = true;
    private Ghost ghostController;
    public AudioSource screamer, main;
    public GameObject count;

    private void Start()
    {
        ghostController = ghost.GetComponent<Ghost>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "HouseHunt")
        {
            door.Play("doorClose", 0, 0.0f);
            count.SetActive(true);
            screamer.Play();
            isInHouse = false;
            rain.SetActive(false);
            main.Play();
            other.gameObject.SetActive(false);
            StartCoroutine(ghostController.StartHunt());
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            PickupItem.countKey = 0;
            SceneManager.LoadScene(0);
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
    }
}
