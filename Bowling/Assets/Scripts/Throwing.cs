using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Rigidbody))]
public class Throwing : MonoBehaviour {

    public UnityEvent onReleased;

    public Camera mainCamera;
    public Camera closeCamera;

    Vector3 StartingPosition;

    Rigidbody rb;
    Vector3 forceVector = new Vector3(0,0,30);

	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody>();
        StartingPosition = transform.position;
    }
	
	// Update is called once per frame
	void Update () {
        if (mainCamera.enabled)
        {
            if (Input.GetKeyDown(KeyCode.Return))
            {
                rb.AddForce(forceVector, ForceMode.Impulse);
                onReleased.Invoke();
                closeCamera.SendMessage("OnRelease", forceVector);
            }
        }
	}

    public void Reset()
    {
        rb.angularVelocity = Vector3.zero;
        rb.velocity = Vector3.zero;
        transform.position = StartingPosition;
    }
}
