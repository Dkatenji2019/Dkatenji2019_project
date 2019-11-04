using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChangeToStart : MonoBehaviour {

    readonly string ScenenName = "Start";
    [SerializeField]private TimeCounter timeCounter;
	void Update () {
        if(timeCounter.GameEndTrigger)
        {
            SceneManager.LoadScene(ScenenName);
        }
    }
}
