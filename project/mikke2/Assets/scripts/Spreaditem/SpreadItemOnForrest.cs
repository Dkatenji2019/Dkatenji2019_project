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
            Q.transform.position = ItemArrage();
            Q.transform.rotation = Quaternion.Euler(ItemRandomRotation(Q.transform.rotation));
        }
    }

    private Vector3 ItemArrage()
    {
        float x = Random.Range(CenterTransform.position.x - area, CenterTransform.position.x +  area);
        float z = Random.Range(CenterTransform.position.z - area, CenterTransform.position.z + area);

        return new Vector3(x, CenterTransform.position.y, z);
    }

    private Vector3 ItemRandomRotation(Quaternion t)
    {
        return new Vector3(t.x, Random.Range(0,180), t.z);
    }
}


