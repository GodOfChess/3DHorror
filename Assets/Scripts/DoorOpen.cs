using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityStandardAssets.Characters.FirstPerson;

public class DoorOpen : MonoBehaviour
{
    // Smoothly open a door
    public AnimationCurve openSpeedCurve = new AnimationCurve(new Keyframe[] { new Keyframe(0, 1, 0, 0), new Keyframe(0.8f, 1, 0, 0), new Keyframe(1, 0, 0, 0) }); //Contols the open speed at a specific time (ex. the door opens fast at the start then slows down at the end)
    public float openSpeedMultiplier = 2.0f; //Increasing this value will make the door open faster
    public float doorOpenAngle = 90.0f; //Global door open speed that will multiply the openSpeedCurve
    public string keyName = "NO_KEY";

    bool open = false;
    bool enter = false;
    bool final = false;

    float defaultRotationAngle;
    float currentRotationAngle;
    float openTime = 0;

    public GameObject player;
    private SkinnedMeshRenderer ghost;
    private Animator anim;
    private PlayerInventory inventory;
    private FirstPersonController controller;
    // Start is called before the first frame update
    void Start()
    {
        defaultRotationAngle = transform.localEulerAngles.y;
        currentRotationAngle = transform.localEulerAngles.y;
        //Set Collider as trigger
        GetComponent<Collider>().isTrigger = true;
        inventory = player.GetComponent<PlayerInventory>();
        anim = GameObject.Find("FinalGhost").GetComponent<Animator>();
        ghost = GameObject.Find("FinalWhiteClown").GetComponent<SkinnedMeshRenderer>();
        controller = player.GetComponent<FirstPersonController>();
    }

    void Update()
    {

        if (openTime < 1)
        {
            openTime += Time.deltaTime * openSpeedMultiplier * openSpeedCurve.Evaluate(openTime);
        }
        transform.localEulerAngles = new Vector3(transform.localEulerAngles.x, Mathf.LerpAngle(currentRotationAngle, defaultRotationAngle + (open ? doorOpenAngle : 0), openTime), transform.localEulerAngles.z);

        if (Input.GetKeyDown(KeyCode.E) && enter)
        {
            bool hasKey = inventory.CheckInventoryFor(keyName);

            if (hasKey == true)
            {

                open = !open;
                currentRotationAngle = transform.localEulerAngles.y;
                openTime = 0;
            }
        }
    }

    // Display a simple info message when player is inside the trigger area (This is for testing purposes only so you can remove it)
    void OnGUI()
    {
        bool hasKey = inventory.CheckInventoryFor(keyName);
        if (enter && hasKey && final == false)
        {
            GUI.Label(new Rect(Screen.width / 2 - 75, Screen.height - 100, 155, 40), "Нажмите 'E', чтобы " + (open ? "закрыть" : "открыть") + " дверь");
        }
    }
    //

    // Activate the Main function when Player enter the trigger area
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("player");
            enter = true;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (Input.GetKeyDown(KeyCode.E) && gameObject.tag == "LastTag" && inventory.CheckInventoryFor("последний ключ"))
            {
                final = true;
                ghost.enabled = true;
                controller.m_WalkSpeed = 0;
                controller.m_RunSpeed = 0;
                controller.m_JumpSpeed = 0;
                anim.SetTrigger("Final");
                Invoke("ToMenu", 6f);
            }
        }
    }

    private void ToMenu()
    {
        SceneManager.LoadScene(0);
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
