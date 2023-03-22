using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaySoundOnTrigger : MonoBehaviour
{
    AudioSource source;
    Collider soundTrigger;

    public void Awake(){
        source = GetComponent<AudioSource>();
        soundTrigger = GetComponent<BoxCollider>();
    }

    public void OnTriggerEnter(Collider other) {
        source.Play();
        Debug.Log("Playing");
    }
}
