using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIDisplayOnGameFinish : MonoBehaviour {

    public Text ScoreText;

    void Start()
    {
        ScoreDisplay();
    }
    private void ScoreDisplay()
    {
        ScoreText.text = ScoreCounter.scoreValue.ToString();
    }
}
