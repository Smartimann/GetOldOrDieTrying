using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine;
using System.Collections;

[RequireComponent(typeof(AudioSource))]
public class SoundManager : MonoBehaviour {
	// Use this for initialization
	void Start () {
        AudioSource audio = GetComponent<AudioSource>();
        wind.Play();
        wind.Play(44100);

    }

    // Update is called once per frame
    void Update () {
		
	}
}
