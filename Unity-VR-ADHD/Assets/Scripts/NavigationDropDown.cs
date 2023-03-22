using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NavigationDropDown : MonoBehaviour
{
    public TMPro.TMP_Dropdown navDrop;
    public GameObject pointerObj;
    // public GameObject lineNavObj;

    public void SetNavigaiton(){
        if(navDrop.value == 0){
            pointerObj.SetActive(false);
            Debug.Log("Clearing Navigation Techniques");
            // Uncoment line below when the line navigaiton thing is complete
            // lineNavObj.SetActive(false);
        }

        else if(navDrop.value == 1){
            pointerObj.SetActive(true);
            Debug.Log("Pointer");
            // Uncoment line below when the line navigaiton thing is complete
            // lineNavObj.SetActive(false);
        }
        
        else if(navDrop.value == 2){
            Debug.Log("We have not yet implemented this feature");
        }
    }
}
