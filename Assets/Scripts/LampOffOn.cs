using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LampOffOn : MonoBehaviour
{
    private new Light light;
    // Start is called before the first frame update
    void Start()
    {
        light = GetComponent<Light>();
        StartCoroutine(LampOnOffCycle());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private IEnumerator LampOnOffCycle()
    {
        yield return new WaitForSeconds(3f);
        light.enabled = false;
        yield return new WaitForSeconds(0.4f);
        light.enabled = true;
        yield return new WaitForSeconds(0.1f);
        light.enabled = false;
        yield return new WaitForSeconds(0.7f);
        light.enabled = true;
        StartCoroutine(LampOnOffCycle());
    }
}
