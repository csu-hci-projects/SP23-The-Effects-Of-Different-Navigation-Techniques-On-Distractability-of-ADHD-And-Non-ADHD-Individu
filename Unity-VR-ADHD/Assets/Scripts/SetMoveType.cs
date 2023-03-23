using System.Net.Http.Headers;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class SetMoveType : MonoBehaviour
{
    // Start is called before the first frame update
    public ActionBasedContinuousTurnProvider contTurnProvider;
    public ActionBasedSnapTurnProvider snapTurnProvider;

    public GameObject leftTeleportation;
    public GameObject rightTeleportation;

    public ActivateTeleportationRay teleportationRay;
    public ActionBasedContinuousMoveProvider moveProvider;

    void Start()
    {
        
    }
    public void SetTypeFromIndexTurn(int index)
    {
        if(index == 0)
        {
            contTurnProvider.enabled = true;
            snapTurnProvider.enabled = false;
        }
        else if(index == 1)
        {
            contTurnProvider.enabled = false;
            snapTurnProvider.enabled = true;
        }
    }

    public void SetTypeFromIndexMove(int index)
    {
        if(index == 0)
        {
            moveProvider.enabled = true;
            // leftTeleportation.SetActive(false);
            // rightTeleportation.SetActive(false);
            teleportationRay.enabled = false;
        }
        else if(index == 1)
        {
            moveProvider.enabled = false;
            // leftTeleportation.SetActive(true);
            // rightTeleportation.SetActive(true);
            teleportationRay.enabled = true;
        }
    }

}
