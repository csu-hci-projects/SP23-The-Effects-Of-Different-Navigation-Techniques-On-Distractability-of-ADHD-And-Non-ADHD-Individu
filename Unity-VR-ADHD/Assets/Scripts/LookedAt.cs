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

    private StreamWriter streamWriter;
    

    public void Start() {
        render = GetComponent<Renderer>();
        distractionTransform = GetComponent<Transform>();
        InvokeRepeating("PlayerIsLooking", 0, 1.0f); // Runs PlayerIsLookign every half second
        streamWriter = File.CreateText(NewFileName());
    }

    void OnApplicationQuit(){
        streamWriter.Close();
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
                Log(distance.ToString());
            }
        }
    }

    private void Log(string data){
        string toLog = string.Format("Object: {0} Time: {1} Distance: {2} ", gameObject.name, Time.time, data);
        streamWriter.WriteLine(toLog);
    }

    private string NewFileName(){
        string name = gameObject.name;
        string fileName = "./Logs/UserData1-" + name + ".log";
        int count = 2;
        while(File.Exists(fileName)){
            fileName = "./Logs/UserData" + count + "-" + name + ".log";
            count += 1;
        }
        return fileName;
    }
    
}
