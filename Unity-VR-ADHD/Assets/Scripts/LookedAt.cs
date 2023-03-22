using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookedAt : MonoBehaviour
{

    public Transform cameraTransform;
    private Renderer render;
    private Transform distractionTransform;
    public float distractionDistance = 5.0f;

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
            float distance = Vector3.Distance(distractionTransform.position, cameraTransform.position);
            if(angle < 15 && distance < distractionDistance){
                LogData(distance);
            }
        }
    }

    private void LogData(float distance){
        Debug.Log("Player is distracted");
        Debug.Log("Logging data");
        Debug.Log(distance);

        // This is where the data will be saved to the file
    }
    
}
