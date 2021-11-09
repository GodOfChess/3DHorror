using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lightning : MonoBehaviour
{
    private new Light light;
    private Color previousColor;
    public AudioSource audioLightning;
    void Start()
    {
        light = GetComponent<Light>();
        previousColor = light.color;
        StartCoroutine(StartLightning());
    }

    void Update()
    {
        
    }

    private IEnumerator StartLightning()
    {
        yield return new WaitForSeconds(8f);
        light.color = Color.white;
        audioLightning.Play();
        yield return new WaitForSeconds(0.2f);
        light.color = previousColor;
        yield return new WaitForSeconds(0.1f);
        light.color = Color.white;
        yield return new WaitForSeconds(0.2f);
        light.color = previousColor;
        StartCoroutine(StartLightning());
    }
}
