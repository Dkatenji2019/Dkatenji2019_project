using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class B : MonoBehaviour {

    [SerializeField] int testB;
    public GameObject a;
    A ClassA = new A();

    // Use this for initialization
    void Start () {
        ClassA = a.GetComponent<A>();
    }

    // Update is called once per frame
    void Update () {
        testB = ClassA.testA;
    }
}
