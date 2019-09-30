using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GameController : MonoBehaviour {

    public UnityEvent onStart;

	// Use this for initialization
	void Start () {
        onStart.Invoke();
	}
}
