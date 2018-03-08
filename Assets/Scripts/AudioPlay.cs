using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioPlay : MonoBehaviour {
    public AudioClip otherClip;
	// Use this for initialization
	void Start () {
        AudioSource audio = GetComponent<AudioSource>();
        audio.clip = otherClip;
        audio.Play();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
