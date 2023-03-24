using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class LookedAt : MonoBehaviour
{

    public Transform cameraTransform;
    public float distractionDistance = 5.0f;
    public int distractionAngle = 25;
    private Renderer render;
    private Transform distractionTransform;
    private Logger logger;    

    public void Start() {
        render = GetComponent<Renderer>();
        distractionTransform = GetComponent<Transform>();
        InvokeRepeating("PlayerIsLooking", 0, 1.0f); // Runs PlayerIsLookign every half second
        logger = new Logger(gameObject.name); // Creates logger object
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
                float time = Time.time;
                logger.Log(time.ToString(), distance.ToString());
            }
        }
    }


    
}
