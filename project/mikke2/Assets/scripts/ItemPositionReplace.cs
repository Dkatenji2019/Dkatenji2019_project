using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPositionReplace : MonoBehaviour {

    [SerializeField] private Transform rootTransform;
    [SerializeField] private ItemRegistrator ItemRegistrator;
	
	// Update is called once per frame
	void Update () {
        foreach(var element in ItemRegistrator.ItemQ)
        {
            if (element.transform.position.y >= rootTransform.position.y)
            {
                continue;
            }
            else if (element.transform.position.y < rootTransform.position.y)
            {
                element.transform.position = new Vector3(element.transform.position.x, rootTransform.position.y, element.transform.position.z);
            }
        }

    }
}
