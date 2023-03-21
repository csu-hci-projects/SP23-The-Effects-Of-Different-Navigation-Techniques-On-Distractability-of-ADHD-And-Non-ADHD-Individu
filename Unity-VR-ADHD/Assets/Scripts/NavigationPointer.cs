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
        float angle = Vector2.Angle(new Vector2(direction.x, direction.z), new Vector2(cameraObjectTransform.transform.forward.x, cameraObjectTransform.transform.forward.z));
        float compasPos = Mathf.Clamp(2 * angle / Camera.main.fieldOfView, -1, 1);
        markerTransform.anchoredPosition = new Vector2(compassBarTransform.rect.width / 2 * compasPos, 0);

        Debug.Log("Angle: " + angle);

    }
}
