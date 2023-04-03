using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class LookedAt : MonoBehaviour
{

    public Transform cameraTransform;
    public float distractionDistance = 5.0f;
    public int distractionAngle = 30;
    private Renderer render;
    private Transform distractionTransform;
    private Logger logger = null;    

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
            if(angle < distractionAngle && distance < distractionDistance){
                int time = (int) Time.time;
                if(logger == null){
                    logger = new Logger(gameObject.name); // Creates logger object only when player first looks at it
                }
                logger.Log(time.ToString(), distance.ToString());
            }
        }
    }


    
}
