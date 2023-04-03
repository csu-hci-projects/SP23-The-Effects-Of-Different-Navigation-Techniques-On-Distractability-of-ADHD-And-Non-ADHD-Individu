using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StopWatch : MonoBehaviour
{

    public GameObject obj;
    public void OnTriggerEnter(Collider other){
        if(Timer.IsTiming()){
            if(other.CompareTag("Player") && obj.GetComponent<Collider>().CompareTag("Goal")){
                Timer.StopTime();
                Debug.Log("Start");
            }
        }else{
            if(other.CompareTag("Player") && obj.GetComponent<Collider>().CompareTag("Start")){
                Timer.StartTime();
                Debug.Log("End");
            }
        }
    }
}
