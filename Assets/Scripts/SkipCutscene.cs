using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkipCutscene : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GameObject camera1 = GameObject.Find("Camera1");
        camera1.SetActive(false);
        GameObject camera2 = GameObject.Find("Camera2");
        camera2.SetActive(false);
        GameObject mainCamera = GameObject.Find("PlayerCamera");
        mainCamera.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
