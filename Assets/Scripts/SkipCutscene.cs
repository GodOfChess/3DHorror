using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkipCutscene : MonoBehaviour
{
    public GameObject cameraFirst, cameraSecond, mainCamera;

    void Start()
    {
        cameraFirst.SetActive(false);
        cameraSecond.SetActive(false);
        mainCamera.SetActive(true);
    }
}
