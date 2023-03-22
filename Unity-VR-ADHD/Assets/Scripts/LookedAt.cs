using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookedAt : MonoBehaviour
{

    public Transform cameraTransform;
    private Renderer render;
    private Transform distractionTransform;

    public void Start() {
        render = GetComponent<Renderer>();
        distractionTransform = GetComponent<Transform>();
        InvokeRepeating("PlayerIsLooking", 0, 1.0f); // Runs PlayerIsLookign every half second
    }

    private void PlayerIsLooking(){
        if(render.isVisible){ // minor 
            // Finds camera dir relative to distraction
            Vector3 direction = distractionTransform.position - cameraTransform.position;
            Vector3 camForward = cameraTransform.transform.forward;
            // Finds angle
            float angle = Vector2.Angle(new Vector2(direction.x, direction.z), new Vector2(camForward.x, camForward.z));

            if(angle < 15){
                LogData();
            }
        }
    }

    private void LogData(){
        Debug.Log("Player is distracted");
        Debug.Log("Logging data");

        // This is where the data will be saved to the file
    }
    
}
