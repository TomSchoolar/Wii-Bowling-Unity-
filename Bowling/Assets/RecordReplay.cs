using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RecordReplay : MonoBehaviour {

    public Transform BallRefrence;

    Transform LastBall;
    Vector3 LastBallForce = Vector3.zero;

	public void OnRelease(Vector3 forceApplied)
    {
        LastBall = BallRefrence;
        LastBallForce = forceApplied;
    }

    public void Replay()
    {

    }
}
