using System.Collections.Generic;
using System.Collections;
using UnityEngine;

public class DecideItemPositionOnField : MonoBehaviour
{

    [SerializeField] private ItemRegistrator itemRegistrator;



    //private Dictionary<int, Transform> itemResponePositionDictionary = new Dictionary<int,Transform>();

    // Use this for initialization
    private void Start()
    {
        //while(itemRegistrator.ItemQ == null)
        //{
        //    StartCoroutine(WaitItemObjectsInclude());
        //}
       putItemDecidedPosition();
    }

    private IEnumerator WaitItemObjectsInclude()
    {
        yield return null;
    }

    private struct ComplexTypeTransform
    {
        public Transform transform;
        public int counter;
        public ComplexTypeTransform(Transform _transform, int _counter)
        {
            transform = _transform;
            counter = _counter;
        }
            
    }
    private void putItemDecidedPosition()
    {

        List<ComplexTypeTransform> tablePosition = new List<ComplexTypeTransform>();
        List<ComplexTypeTransform> shelfPosition = new List<ComplexTypeTransform>();
        List<ComplexTypeTransform> drawerPosition = new List<ComplexTypeTransform>();

        int shelfNumberCounter = 0;
        int drawerNumberCounter = 0;

        foreach (Transform childTransform in this.transform)
        {
            //itemResponePositionDictionary.Add(childTransform.gameObject.GetComponent<PositionEnumForResponObject>().RespawnPosition,childTransform);
            switch(childTransform.gameObject.GetComponent<PositionEnumForResponObject>().RespawnPosition)
            {
                case 1:
                    tablePosition.Add(new ComplexTypeTransform(childTransform,0));
                    break;
                case 2:
                    shelfPosition.Add(new ComplexTypeTransform(childTransform, 0));
                    break;
                case 3:
                    drawerPosition.Add(new ComplexTypeTransform(childTransform, 0));
                    break;
            }
        }

        foreach (var instancedGameObject in itemRegistrator.ItemQ)
        {
            if(itemRegistrator.ItemQ == null)
            {
                continue;
            }

            var itemResponeKey = instancedGameObject.GetComponent<ItemInformation>().ItemRespawnPosition;

            if(itemResponeKey <= 0)
            {
                /*
                    例外処理についてここに処理を書く
                    */
                continue;
            }
            //var c = new System.Comparison<ComplexTypeTransform>(Compare);
            switch (itemResponeKey)
            {
                //机の上に散らばらせる場合　 :　1
                case 1:

                    instancedGameObject.transform.position = ArrageOnTable(tablePosition[ReturnRandomValue(tablePosition.Count)]);
                    //tablePosition.Sort((a, b) => a.counter - b.counter);

                    break;
                //棚の中にちらばらせる場合　 :　2
                case 2:
                    instancedGameObject.transform.position = ArrageinDrawer(shelfPosition[shelfNumberCounter]);
                    shelfNumberCounter++;
                    if (shelfNumberCounter >= shelfPosition.Count)
                    {
                        shelfNumberCounter = 0;
                    }
                    break;
                //引き出しの中に格納する場合 :　3
                case 3:

                    instancedGameObject.transform.position = ArrageOnShelf(drawerPosition[drawerNumberCounter]);
                    drawerNumberCounter++;
                    if (drawerNumberCounter >= drawerPosition.Count)
                    {
                        drawerNumberCounter = 0;
                    }
                    break;
            }

        }

    }

    private Vector3 ArrageOnTable(ComplexTypeTransform pos)
    {
        /*
            ここに処理を書く
         */
        pos.counter += 1;
        return pos.transform.position;
    }
    private Vector3 ArrageinDrawer(ComplexTypeTransform pos)
    {

        /*
            ここに処理を書く
         */
        pos.counter += 1;
        return pos.transform.position;
    }
    private Vector3 ArrageOnShelf(ComplexTypeTransform pos)
    {
        pos.counter += 1;
        Vector3 vec;
        vec = new Vector3(Random.Range(pos.transform.position.x- pos.transform.localScale.x,
                        pos.transform.position.x + pos.transform.localScale.x), pos.transform.position.y,
                        Random.Range(pos.transform.position.z - pos.transform.localScale.z,
                        pos.transform.position.z + pos.transform.localScale.z));
        return vec;
    }
    private int Compare(ComplexTypeTransform a, ComplexTypeTransform b)
    {
        return a.counter - b.counter;
    }

    private int ReturnRandomValue(int value)
    {
        value = Random.Range(0 , value);
        return value;
    }
}
