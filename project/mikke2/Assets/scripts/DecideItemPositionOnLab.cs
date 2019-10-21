using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DecideItemPositionOnLab : MonoBehaviour {

    [SerializeField] FindScriptableobjects FS = new FindScriptableobjects();


    // Use this for initialization
    void Start()
    {
        putItemDecided();

    }

    // Update is called once per frame
    void Update()
    {
    }

    private void putItemDecided()
    {

        GameObject Obj;
        //var childTransform = GameObject.Find("").GetComponentsInChildren<Transform>();
        int i = 0;

        foreach (Transform child in transform)
        {
            if (i > FS.ItemsList.Count - 1) i = 0;
            Obj = (GameObject)Instantiate(FS.ItemsList[i].ItemObject, this.transform.position, Quaternion.identity);

            Obj.transform.parent = child.transform;
            i++;
        }

        }

    }

