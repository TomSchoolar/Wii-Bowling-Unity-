using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PinChecker : MonoBehaviour
{
    public GameObject pinHandler;

    public float angleOfDown = 30;

    Vector3 originalPosition;

    bool communicated = false;

    bool down = false;

    private void Start()
    {
        originalPosition = transform.position;
        pinHandler = GameObject.Find("PinHandler");
    }

    private void FixedUpdate()
    {
        if (!down && !communicated)
        {

            down = CheckIfDown();
             
            if (down)
            {
                pinHandler.SendMessage("onDown", originalPosition);
                communicated = true;
            }
        }
    }

    private bool CheckIfDown()
    {
        if(transform.rotation.x > Quaternion.Euler(angleOfDown,0,0).x || transform.rotation.x < -(Quaternion.Euler(angleOfDown, 0, 0).x))
        {
            return true;
        }
        if (transform.rotation.z > Quaternion.Euler(0, 0, angleOfDown).z || transform.rotation.z < -(Quaternion.Euler(0, 0, angleOfDown).z))
        {
            return true;
        }
        return false;
    }
}
