using UnityEngine;
using UnityEngine.UI;

public class circle_gage : MonoBehaviour {

    public Image UIobj;
    public bool roop;
    private float x;

    // Update is called once per frame
    void Update () {
        if (roop)
        {
            x += Time.deltaTime;
            UIobj.fillAmount += x * x * 0.005f;

            if(UIobj.fillAmount >= 1)
            {
                x = 0;
            }
        }
        if(!roop)
        {
            if(UIobj.fillAmount >= 0)
            {
                UIobj.fillAmount -= Time.deltaTime;
                x = 0;
            }
        }
    }
}
