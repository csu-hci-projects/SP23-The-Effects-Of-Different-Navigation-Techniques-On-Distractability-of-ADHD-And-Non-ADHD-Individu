using System.Net.Http.Headers;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
public class SetNavType : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject navigationPointer;
    public LineRenderer navigationLine;

    void Start()
    {
        
    }
    public void SetTypeFromIndexNav(int index)
    {
        if (index == 0)
        {
            navigationPointer.SetActive(false);
            navigationLine.enabled = false;
        }
        else if (index == 1)
        {
            navigationPointer.SetActive(true);
            navigationLine.enabled = false;
        }
        else if(index == 2)
        {
            navigationPointer.SetActive(false);
            navigationLine.enabled = true;
        }
    }
}
