using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkipCutscene : MonoBehaviour
{
    public GameObject camera1, camera2, mainCamera;
    void Start()
    {
        camera1.SetActive(false);
        camera2.SetActive(false);
        mainCamera.SetActive(true);
    }
}
