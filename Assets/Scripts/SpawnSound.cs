using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(AudioSource))]

public class SpawnSound : MonoBehaviour {

	void Start () 
    {
        AudioSource spawnSound = GetComponent<AudioSource>();
        spawnSound.Play();
	}	
}
