using UnityEngine;
using UnityEngine.UI;

public class CircleGage : MonoBehaviour {

    [SerializeField]private Image circleGage;

    public bool OnTrigger{ get;set; }

    private float x;

    // Update is called once per frame
    void Update () {
        if (OnTrigger)
        {
            x += Time.deltaTime;
            circleGage.fillAmount += x * x * 0.005f;

            if(circleGage.fillAmount >= 1)
            {
                x = 0;
            }
        }
        if(!OnTrigger)
        {
            if(circleGage.fillAmount >= 0)
            {
                circleGage.fillAmount -= Time.deltaTime;
                x = 0;
            }
        }
    }
}
