using System;
using System.Collections;
using UnityEngine;

public class Fade : MonoBehaviour 
{
    // Start screen black and fade into title 
    public Material StartMaterial;
    public Material EndMaterial;
    public Renderer rend;
    public float FadeDelay;
    public float FadeTime;
    float t = 0f;


    IEnumerator Start () 
    {
        rend.GetComponent<Renderer>();
        rend.material = StartMaterial;

        // Wait for suspense 
        yield return new WaitForSeconds(FadeDelay);

        // Begin fade
        while (t <= FadeTime) 
        {
            t += Time.deltaTime;
            rend.material.Lerp(StartMaterial, EndMaterial, t / FadeTime);
            yield return null;
        }

        rend.enabled = false;
        rend.gameObject.SetActive(false);
   	}
}
