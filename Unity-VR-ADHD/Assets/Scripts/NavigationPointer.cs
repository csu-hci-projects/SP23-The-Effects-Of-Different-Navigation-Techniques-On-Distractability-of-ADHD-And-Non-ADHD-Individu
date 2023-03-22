using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NavigationPointer : MonoBehaviour
{

    public RectTransform objectiveMarkerTransform;

    public RectTransform compassBarTransform;

    public Transform objectiveObjectTransform;
    public Transform cameraObjectTransform;


    // Update is called once per frame
    void Update()
    {
        SetMarkerPosition(objectiveMarkerTransform, objectiveObjectTransform.position);
    }

    private void SetMarkerPosition(RectTransform markerTransform, Vector3 worldPos){

        Vector3 direction = worldPos - cameraObjectTransform.position;
        float angle = Vector2.SignedAngle(new Vector2(direction.x, direction.z), new Vector2(cameraObjectTransform.transform.forward.x, cameraObjectTransform.transform.forward.z));
        float compasPos = Mathf.Clamp(2 * angle / Camera.main.fieldOfView, -1, 1);
        markerTransform.anchoredPosition = new Vector2(compassBarTransform.rect.width / 2 * compasPos, 0);


    }

//     private void MovePointerToGoodPosition(){ // Currently used for nothing but may be useful in the future
//         canvas.transform.position = cameraObjectTransform.position + new Vector3(cameraObjectTransform.forward.x, 0, cameraObjectTransform.forward.z).normalized;
//         canvas.transform.LookAt(new Vector3(cameraObjectTransform.position.x, canvas.transform.position.y, cameraObjectTransform.position.z));
//         canvas.transform.forward *= -1;
//     }
 }
