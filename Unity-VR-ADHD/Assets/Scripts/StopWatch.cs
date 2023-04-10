using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class StopWatch : MonoBehaviour
{

    public GameObject obj;
    public void OnTriggerEnter(Collider other){
        if(Timer.IsTiming()){
            if(other.CompareTag("Player") && obj.GetComponent<Collider>().CompareTag("Goal")){
                Timer.StopTime();
                Debug.Log("Goal");
                if(SceneManager.GetActiveScene().buildIndex != 1){
                    StartCoroutine(SwitchScene());
                }else{
                    Application.Quit();
                }
            }
        }else{
            if(other.CompareTag("Player") && obj.GetComponent<Collider>().CompareTag("Start")){
                Timer.StartTime();
                Debug.Log("Start");
                Debug.Log(Timer.IsTiming());
            }
        }
    }

    IEnumerator SwitchScene(){
        Debug.Log("Switching Scene");
        yield return new WaitForSeconds(2);
        SceneManager.LoadScene(1);
    }
}
