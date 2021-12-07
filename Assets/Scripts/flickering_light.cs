using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class flickering_light : MonoBehaviour
{
    public bool isFlick = false;
    public float timeDelay;

    // Update is called once per frame
    void Update()
    {
        if (isFlick == false)
        {
            StartCoroutine(flick_Light());
        }
    }
    IEnumerator flick_Light()
    {
        isFlick = true;
        this.gameObject.GetComponent<Light>().enabled = false;
        timeDelay = Random.Range(0.01f, 0.2f);
        yield return new WaitForSeconds(timeDelay);
        this.gameObject.GetComponent<Light>().enabled = true;
        timeDelay = Random.Range(0.01f, 0.2f);
        yield return new WaitForSeconds(timeDelay);
        isFlick = false;
    }
}
