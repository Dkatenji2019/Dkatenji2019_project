using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnvironmentLitingManager : MonoBehaviour {

    [SerializeField]private  Material sky;
    // Use this for initialization

    Color32 firstSkyboxColor = new Color32(141, 189, 255, 1);
    Color32 endSkyboxColor = new Color32(208, 110, 87, 1);

    TimeCounter timeCounter;

    void Start () {
        RenderSettings.skybox = sky;
        //firstSkyboxColor = new Color(141, 189, 255);
        //endSkyboxColor = new Color(152, 44, 19);
        timeCounter = this.GetComponent<TimeCounter>();
        RenderSettings.skybox.SetColor("_Tint", firstSkyboxColor);
        RenderSettings.skybox.SetFloat("_Exposure", 1.0f);
    }
	
	// Update is called once per frame
	void Update () {
        //var c = sky.GetColor("_Tint");
        //c.r -= 0.03F;
        //c.g -= 0.03F;
        //c.b -= 0.03F;
        //sky.SetColor("_Tint", c);

        Color32 lerpedColor = Color32.Lerp(firstSkyboxColor, endSkyboxColor,timeCounter.GameTimeRangeZeroToOne);
        sky.SetColor("_Tint", lerpedColor);

        float lerpedExposureValue = Mathf.Lerp(1.0f, 0.8f, timeCounter.GameTimeRangeZeroToOne);
        Debug.Log(lerpedExposureValue);
        RenderSettings.skybox.SetFloat("_Exposure", lerpedExposureValue);
    }

    void OnApplicationQuit()
    {
        RenderSettings.skybox.SetColor("_Tint", firstSkyboxColor);
        RenderSettings.skybox.SetFloat("_Exposure", 1.0f);
    }
}
