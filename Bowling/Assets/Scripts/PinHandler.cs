using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PinHandler : MonoBehaviour {

    public GameObject pinPrefab;

    public GameRunner gameRunner;

    public float timeOutTime = 6f;
    float currentTimeElapsed = 0f;
    bool timerEnabled = false;

    List<Vector3> pinsDown;
    int score;

    List<Vector3> pinLocations = new List<Vector3>() { new Vector3(3.5f,0.5f,18.5f),
                                                       new Vector3(-3.5f,0.5f,18.5f),
                                                       new Vector3(-2.5f,0.5f,17f),
                                                       new Vector3(2.5f,0.5f,17f),
                                                       new Vector3(0f,0.5f,17f),
                                                       new Vector3(-1.25f,0.5f,15.5f),
                                                       new Vector3(1.25f,0.5f,15.5f),
                                                       new Vector3(0f,0.5f,14f),
                                                       new Vector3(1.25f,0.5f,18.5f),
                                                       new Vector3(-1.25f,0.5f,18.5f)};

	// Use this for initialization
	void Start () {
        pinsDown = new List<Vector3>();
        score = 0;

        CreatePins(); // change this
	}
	
	public void CreatePins()
    {
        foreach(Vector3 pin in pinLocations)
        {
            Instantiate(pinPrefab, pin, Quaternion.identity);
        }
    }

    public void onDown(Vector3 position)
    {
        if (!pinsDown.Contains(position))
        {
            pinsDown.Add(position);
            score++;
        }
    }

    public void StartTimer()
    {
        score = 0;
        currentTimeElapsed = 0f;
        timerEnabled = true;
    }

    private void Update()
    {
        if (timerEnabled)
        {
            currentTimeElapsed = currentTimeElapsed + Time.deltaTime;

            if (currentTimeElapsed >= timeOutTime)
            {
                timerEnabled = false;
                gameRunner.SendMessage("ScoreFinalised", score);
            }
        }
    }

    public void DeletePins()
    {
        Collider[] colliders = Physics.OverlapSphere(Vector3.zero, 50f);
        foreach(Collider c in colliders)
        {
            if (c.name == "Pin Model")
            {
                Destroy(c.GetComponentInParent<PinChecker>().gameObject);
            }
        }

        CreatePins();
    }
}
