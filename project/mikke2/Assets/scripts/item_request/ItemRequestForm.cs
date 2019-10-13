using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemRequestForm : MonoBehaviour {

    // Use this for initialization

    [SerializeField] private List<string> items_name = new List<string>();

    void awake()
    {
        var Find_GameObject = GameObject.Find("FIND_OBJECT_MANAGER");
        var tmp_FS = Find_GameObject.GetComponent<FindScriptableobjects>();
        foreach (var element in tmp_FS.ItemsList)
        {
            if (element.ItemName.Length != 0)
            {
                items_name.Add(element.ItemName);
            }
        }
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
