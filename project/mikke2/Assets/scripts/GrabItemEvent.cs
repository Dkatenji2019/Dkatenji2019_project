using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GrabItemEvent : MonoBehaviour {

    public float GripTime { get; set; }
    readonly float DecideGripTime = 3.0f;

    public bool IsGripItem;

    public bool IsMatchedWithItem;


    private void Update()
    {
        if(IsGripItem)
        {
            if(GripTime > DecideGripTime && IsMatchedWithItem)
            {
                MatchedWithItem();
            }
        }
        else if(!IsGripItem)
        {
            NonGrabItem();
        }
    }

    private void destoyItem()
    {

    }

    private void GripTimeCounter()
    {
        GripTime += Time.deltaTime;
    }

    private void MatchedWithItem()
    {

    }
    private void NonGrabItem()
    {
        if (GripTime <= 0)
        {
            return;
        }
        GripTime -= Time.deltaTime;

    }

}
