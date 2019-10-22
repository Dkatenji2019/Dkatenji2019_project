using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreCounter : MonoBehaviour
{
    [SerializeField] ItemRegistrator itemRegistrator;
    public int ScoreValue { get; set; }
    public static int _scoreValue;


    // Use this for initialization
    void Update()
    {
        ScoreValue = _scoreValue;
    }

}
