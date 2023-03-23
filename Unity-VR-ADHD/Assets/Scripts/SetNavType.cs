using System.Net.Http.Headers;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
public class SetNavType : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject navigationPointer;
    public GameObject navigationLine;

    void Start()
    {
        
    }
    public void SetTypeFromIndexNav(int index)
    {
        if (index == 0)
        {
            navigationPointer.SetActive(false);
            navigationLine.SetActive(false);
        }
        else if (index == 1)
        {
            navigationPointer.SetActive(true);
            navigationLine.SetActive(false);
        }
        else if(index == 2)
        {
            navigationPointer.SetActive(false);
            navigationLine.SetActive(true);
        }
    }
}
