using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreCounter : MonoBehaviour
{
    public static int scoreValue = 0;

    void Awake()
    {
    }

    public static void AddScoreValue(int _scoreValue)
    {
        scoreValue += _scoreValue;
    }

    public static void SetScoreValueToZero()
    {
        scoreValue = 0;
    }
}
