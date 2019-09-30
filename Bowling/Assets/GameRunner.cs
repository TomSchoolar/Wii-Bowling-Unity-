using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GameRunner : MonoBehaviour {

    public UnityEvent onEndOfTurn;
    public UnityEvent onEndOfFirstTry;

    private int[] score;
    private int nextFreePointer = 0;

    private void Start()
    {
        score = new int[20];
    }

    public void ScoreFinalised(int _score)
    {
        if ((nextFreePointer % 2) != 0)
        {
            score[nextFreePointer] = score[nextFreePointer - 1] + _score;
        }
        else
        {
            score[nextFreePointer] = _score;
        }

        nextFreePointer++;

        if(_score == 10)
        {
            nextFreePointer++;
        }

        if((nextFreePointer % 2) == 0) // number is even therefore, end of turn
        {
            onEndOfTurn.Invoke();
        }
        else
        {
            onEndOfFirstTry.Invoke();
        }
    }
}
