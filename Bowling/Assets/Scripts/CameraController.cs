using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CameraController : MonoBehaviour {

    public Camera mainCamera;
    public Camera closeCamera;
    public Camera playerCamera;

	// Use this for initialization
	void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void MainCameraEnabled()
    {
        mainCamera.enabled = true;
        closeCamera.enabled = false;
        playerCamera.enabled = false;
    }

    public void CloseCameraEnabled()
    {
        mainCamera.enabled = false;
        closeCamera.enabled = true;
        playerCamera.enabled = false;
    }

    public void PlayerCameraEnabled()
    {
        mainCamera.enabled = false;
        closeCamera.enabled = false;
        playerCamera.enabled = true;
    }
}
