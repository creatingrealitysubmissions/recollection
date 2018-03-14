using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleDisabler : MonoBehaviour 
{
    // Start screen black and fade into title 
    public float FadeDelay;
    public float FadeTime;
    float t = 0f;


    IEnumerator Start()
    {
        // Wait for suspense 
        yield return new WaitForSeconds(FadeDelay);

        this.gameObject.SetActive(false);
    }
}
