using System.Collections;
using UnityEngine;

public class Narration : MonoBehaviour 
{
    
    public AudioSource NarrationClip;

    void Start ()
    {
        // Wait for spawn noise to complete (in Audio Source Componenet) ...
        StartCoroutine(Wait());

        // ... before playing the narration
        NarrationClip.Play();
    }

    IEnumerator Wait ()
    {
        yield return new WaitForSeconds(2.5f);
	}

}
