using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpreadItemOnForrest : MonoBehaviour
{
    [SerializeField] private int area;
    [SerializeField] private ItemRegistrator itemRegistrator;
    [SerializeField] private Transform CenterTransform;

    public List<GameObject> colliderArray;
    // Use this for initialization
    void Start()
    {
        putItemSpread();
        SearchColliderObjects();
    }


    private void SearchColliderObjects()
    {
        foreach (Transform child in this.transform)
        {
            if (child.gameObject.tag == "Collider")
            {
                colliderArray.Add(child.gameObject);
            }
        }
    }
    private void putItemSpread()
    {
        while (itemRegistrator.ItemQ == null);

        foreach (var Q in itemRegistrator.ItemQ)
        {
            if (Q.gameObject.GetComponent<ItemInformation>().ItemRespawnPosition != 0)
            {
                continue;
            }
            bool flag = true;
            Q.transform.position = ItemArrage();

            //while(flag)
            //{
            //    foreach (var elm in colliderArray)
            //    {
            //        if (!elm.GetComponent<CheckObjectRapWithCollider>().IsRapWithObject)
            //        {
            //            flag = false;
            //            continue;
            //        }
            //        else if (elm.GetComponent<CheckObjectRapWithCollider>().IsRapWithObject == true)
            //        {
            //            flag = true;
            //            elm.GetComponent<CheckObjectRapWithCollider>().IsRapWithObject = false;
            //            break;
            //        }
            //    }

            //    if (flag == false)
            //    {
            //        break;
            //    }
            //    else if (flag == true)
            //    {
            //        Q.transform.position = ItemArrage();
            //    }

            //}


        }

    }

    private Vector3 ItemArrage()
    {
        float x = Random.Range(CenterTransform.position.x - area, CenterTransform.position.x +  area);
        float z = Random.Range(CenterTransform.position.z - area, CenterTransform.position.z + area);

        return new Vector3(x, CenterTransform.position.y, z);
    }
}


