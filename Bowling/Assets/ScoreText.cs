using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Text))]
public class ScoreText : MonoBehaviour {

    Text text;

    private int nextTurnNumber = 0;

	// Use this for initialization
	void Start () {
        text = GetComponent<Text>();
        nextTurnNumber = 0;
	}

    public void UpdateText(int[] scoreArray)
    {
        string divider = "\n_\n \n";

        if (nextTurnNumber % 2 == 0)
        {
            text.text = (nextTurnNumber + 1).ToString() + divider + scoreArray[nextTurnNumber] + divider + scoreArray[nextTurnNumber + 1];
        }
        else
        {
            text.text = (nextTurnNumber + 1).ToString() + divider + scoreArray[nextTurnNumber - 1] + divider + scoreArray[nextTurnNumber];
        }

        if (scoreArray[nextTurnNumber] == 10)
        {
            nextTurnNumber++;
        }
        nextTurnNumber++;
    }
}
