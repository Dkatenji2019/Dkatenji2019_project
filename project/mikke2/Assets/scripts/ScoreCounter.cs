using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreCounter : MonoBehaviour
{

    public int ScoreValue { get; set; }

    // Use this for initialization
    void Start()
    {
        ScoreValue = 0;
    }

    private void addScore(int scoreValue)
    {
        ScoreValue += scoreValue;
    }
}
