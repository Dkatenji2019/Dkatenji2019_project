using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class TrackingMoving : MonoBehaviour {

    // Use this for initialization

    private Queue<Vector3> latestFramePos = new Queue<Vector3>();
    private Vector3 currentFramePos;
    public int delayTime = 200;
    public float moveMargin = 0.1f;


    // Update is called once per frame
    void Update () {

        //
        float currentFramePossqrt = Mathf.Sqrt((float)Math.Pow(Mathf.Abs(currentFramePos.x - this.transform.position.x),2) 
                                             + (float)Math.Pow(Mathf.Abs(currentFramePos.z - this.transform.position.z), 2));

        //
        float avaragelatestFramePosSqrt = 0;

        Queue<Vector3> latestFramePosCopy = new Queue<Vector3>(latestFramePos);
        while(latestFramePosCopy.Count != 0)
        {
            Vector3 first = latestFramePosCopy.Dequeue();
            if (latestFramePosCopy.Count == 0)
            {
                break;
            }

            Vector3 second = latestFramePosCopy.Peek();
            avaragelatestFramePosSqrt += Mathf.Sqrt((float)Math.Pow(Mathf.Abs(first.x - second.x), 2)
                                                  + (float)Math.Pow(Mathf.Abs(first.z - second.z), 2));
        }
        avaragelatestFramePosSqrt /= delayTime;

        //
        if(Mathf.Abs(currentFramePossqrt - avaragelatestFramePosSqrt) > moveMargin)
        {
            SoundManager.PlayfootstepsSound();
        }
        if(Mathf.Abs(currentFramePossqrt - avaragelatestFramePosSqrt)  <= moveMargin)
        {
            SoundManager.StopfootstepsSound();
        }

        //
        if (latestFramePos.Count > delayTime)
        {
            latestFramePos.Dequeue();
        }
        latestFramePos.Enqueue(this.transform.position);

        //
        currentFramePos = this.transform.position;
    }
}
