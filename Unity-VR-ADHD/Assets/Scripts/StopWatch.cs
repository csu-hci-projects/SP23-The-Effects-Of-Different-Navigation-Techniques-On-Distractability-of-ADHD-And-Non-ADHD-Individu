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
                    #if UNITY_EDITOR
                        // Application.Quit() does not work in the editor so
                        // UnityEditor.EditorApplication.isPlaying need to be set to false to end the game
                        UnityEditor.EditorApplication.isPlaying = false;
                    #else
                        Application.Quit();
                    #endif
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
