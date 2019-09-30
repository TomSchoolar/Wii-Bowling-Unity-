using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class WaitForInput : MonoBehaviour {

    public UnityEvent onInput;

    public KeyCode key = KeyCode.Space;

    // Update is called once per frame
    void Update () {
        if (GetComponent<Camera>().enabled)
        {
            if (Input.GetKeyDown(key))
            {
                onInput.Invoke();
            }
        }
	}
}
