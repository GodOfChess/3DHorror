using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    static public void Transition()
    {
        GameObject camera1 = GameObject.Find("Camera1");
        camera1.SetActive(false);
        GameObject camera2 = GameObject.Find("Camera2");
        camera2.SetActive(false);
        GameObject mainCamera = GameObject.Find("PlayerCamera");
        mainCamera.SetActive(true);

        GameObject fpc = GameObject.Find("FirstPersonController");
        fpc.transform.position = new Vector3(27, 1, 386);

        Quaternion rotation = Quaternion.identity;
        rotation.eulerAngles = new Vector3(166, 0, 0);
        fpc.transform.rotation = rotation;
    }
}
