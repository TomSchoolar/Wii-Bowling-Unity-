using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Follow : MonoBehaviour {

    public Transform BallPosition;
    public Vector3 cameraOffset = new Vector3(0, 3, -6);
    Vector3 cameraPosition = Vector3.zero;
    Vector3 originalCameraPosition = new Vector3(0, 2, -17);
    Vector3 stoppingPosition = new Vector3(0, 0, -10);
    public float smoothSpeed = 0.15f;

    public bool isTracking = false;

    // Use this for initialization
    void Start () {
        BallPosition = GetComponent<Transform>();
        Reset();
    }

    public void Reset()
    {
        transform.position = originalCameraPosition;
        isTracking = false;
    }

    public void StartTracking()
    {
        isTracking = true;
    }

    private void FixedUpdate()
    {
        if (!isTracking)
        {
            transform.position = originalCameraPosition;
        }
        else
        {
            if (transform.position.z < stoppingPosition.z)
            {
                transform.LookAt(BallPosition);
                cameraPosition = BallPosition.position - cameraOffset;
                cameraPosition.y = cameraOffset.y;
                transform.position = Vector3.Lerp(transform.position, cameraPosition, smoothSpeed * Time.fixedDeltaTime);
            }
        }
    }
}
