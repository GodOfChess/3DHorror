using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CutScene : MonoBehaviour
{
    [SerializeField] float speed = 15f;

    void Start()
    {

    }
    void Update()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }
}
