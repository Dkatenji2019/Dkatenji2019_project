using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class UIDisplayOnGameFinish : MonoBehaviour {

    public Text ScoreText;

    [SerializeField]public Text[] RankingText = new Text[10];

    void Start()
    {
        ScoreDisplay();
        RankingDisplay();
    }
    private void ScoreDisplay()
    {
        ScoreText.text = ScoreCounter.scoreValue.ToString();
    }

    private void RankingDisplay()
    {
        var toQueueRankingValue = new Queue<int>();
        toQueueRankingValue.Enqueue(0);

        if (ScoreCounter.ScoreRanking != null)
        {
            ScoreCounter.ScoreRanking.Sort((a, b) => b - a);
            toQueueRankingValue = new Queue<int>(ScoreCounter.ScoreRanking);
        }

        foreach (var elm in RankingText)
        {
            if(toQueueRankingValue.Count == 0)
            {
                elm.text = "0";
                continue;
            }

            elm.text = toQueueRankingValue.Peek().ToString();
            toQueueRankingValue.Dequeue();
        }
    }
}
