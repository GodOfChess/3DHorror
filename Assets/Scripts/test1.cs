using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test1 : MonoBehaviour
{

    public Rigidbody rigbody;
    float xInput;
    float zInput;

    public float moveSpeed;
    private void Awake()
    {
        rigbody = GetComponent<Rigidbody>();
    }
    // Start is called before the first frame update
    void Start()
    {

    }

    private void FixedUpdate()
    {
        float xV = xInput * moveSpeed;
        float zV = zInput * moveSpeed;
        rigbody.velocity = new Vector3(xV, rigbody.velocity.y, zV);
    }
    // Update is called once per frame
    void Update()
    {
        xInput = Input.GetAxis("Horizontal");
        zInput = Input.GetAxis("Vertical");
    }
}
