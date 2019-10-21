using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GrabItemEvent : MonoBehaviour
{

    [SerializeField]private ItemRegistrator IR;

    public float GripTime;// { get; set; }
    readonly float DecideGripTime = 3.0f;

    public bool IsGripItem;
    public bool IsMatchedWithItem;

    private void Update()
    {
        /*--------------------------*/
        //Correctの場合はC
        //Gripの場合はG
        //controllerが実装できるまでキーで代用

        if (Input.GetKey(KeyCode.G))
        {
            IsGripItem = true;
        }
        else
        {
            IsGripItem = false;
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            IsMatchedWithItem = true;
        }
        else if((Input.GetKeyUp(KeyCode.Space)))
        {
            IsMatchedWithItem = false;
        }
        /*---------------------------*/

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
        }
    }

    private void NonGrabItem()
    {
        if(GripTime == 0)
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

