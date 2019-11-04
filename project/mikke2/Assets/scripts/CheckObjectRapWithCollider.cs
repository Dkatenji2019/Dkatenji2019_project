using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckObjectRapWithCollider : MonoBehaviour {

    public bool IsRapWithObject { get; set; }


    void OnTriggerEnter(Collider other)
    {
        IsRapWithObject = true;
        Debug.Log("huga");
    }

    void OnCollisionExit(Collision other)
    {
        IsRapWithObject = false;
    }

}
