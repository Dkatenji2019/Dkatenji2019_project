using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreCounter : MonoBehaviour
{
    public static int scoreValue;

    void Awake()
    {
        SetScoreValueToZero();
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
