using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIDisplayOnGameFinish : MonoBehaviour {

    [SerializeField] private TimeCounter timeCounter;

    // Use this for initialization
    void Start () {

    }
	
	// Update is called once per frame
	void Update () {
		
        
        if(timeCounter.GameEndTrigger)
        {

        }
	}
}
