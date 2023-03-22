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
        Debug.Log(other.gameObject.tag);
        if(other.CompareTag("Player")){
            source.Play();
        }
    }

    public void OnTriggerExit(Collider other){
        if(other.CompareTag("Player")){
            source.Stop();
        }
    }
}
