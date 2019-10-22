using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class SceneChangeToMiniture : MonoBehaviour
{

    public float GripTime;// { get; set; }
    readonly float DecideGripTime = 3.0f;

    public bool IsGripItem;
    public bool IsMatchedWithItem;

    private void Update()
    {
        if (IsGripItem)
        {
            GripTimeCounter();
        }
        else if (!IsGripItem)
        {
            NonGrabItem();
        }
    }

    private void GripTimeCounter()
    {
        GripTime += Time.deltaTime;

        if (GripTime > DecideGripTime && IsMatchedWithItem)
        {
            IsGripItem = false;
            GripTime = 0;
            SceneManager.LoadScene("Miniture");
        }
    }

    private void NonGrabItem()
    {
        if (GripTime == 0)
        {
            return;
        }

        else if (GripTime < 0)
        {
            GripTime = 0;
            return;
        }

        GripTime -= Time.deltaTime;
    }

}


