using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mikke : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject[] objects;

    public string FilePath;

    List<int> numbers = new List<int>();

    Queue<GameObject> Obje = new Queue<GameObject>();
    Queue<GameObject> Find = new Queue<GameObject>();

    [SerializeField] private List<GameObject> items_GameObjct = new List<GameObject>();
    [SerializeField] private List<string> items_name = new List<string>();

    void Awake()
    {

        ///適当にスクリプトを綺麗にまとめてほしい
        ///こちらからRIgidBodyとCollidrは勝手につけるようにした

        var Find_GameObject = GameObject.Find("FIND_OBJECT_MANAGER");
        var tmp_FS = Find_GameObject.GetComponent<FindScriptableobjects>();
        foreach (var element in tmp_FS.ItemsList)
        {
            items_GameObjct.Add(element.ItemObject);

            if (element.ItemName.Length == 0)
            {
                items_name.Add("☆---名前を追加してください---☆");
            }
            else
            {
                items_name.Add(element.ItemName);
            }

           // element.ItemObject.AddComponent<CapsuleCollider>();
           // element.ItemObject.AddComponent<Rigidbody>();

            System.Array.Resize(ref objects, objects.Length + 1);
            objects[objects.Length - 1] = element.ItemObject;

            //byte[] data = System.Text.Encoding.ASCII.GetBytes(element.ItemName);
            //string hoge = null;
            //for (int i = 0; i < data.Length; i++)
            //{
            //    Debug.Log(Convert.ToString(data[i], 16) + " - ");
            //}
            //Debug.Log("-------------------------------------------");

        }
    }

    //    private void Awake()
    //{
    //    //for(int i = 0; i< 5; i++)
    //    //{
    //    //    hoge.Add(this.GetComponent<FindScriptableobjects>().ItemsList.ItemObject);
    //    //}
    //}

    void Start()
    {
        FilePath = Application.dataPath + "/objects/Test";
        Object[] gameObjectArray = Resources.LoadAll(FilePath, typeof(GameObject));

        //Place and Enqueue objects
        for (int i = 0; i < objects.Length; i++)
        {
           // objects[i] = gameObjectArray[i];
            numbers.Add(i);
            
        }
        //while (numbers.Count > 0)
        for(int i = 0; i < 300; i ++)
        {

            int index = Random.Range(0, numbers.Count);

            int ransu = numbers[index];

            float x = Random.Range(-5.0f, 5.0f);
            float y = Random.Range(0, 30.0f);
            float z = Random.Range(-5.0f, 5.0f);
            Instantiate(objects[index], new Vector3(x, y, z), transform.rotation);

            Obje.Enqueue(objects[index]);

           // numbers.RemoveAt(index);
        }

        //Enqueue Looking objects 
        for (int i = 0; i < objects.Length; i++)
        {
            numbers.Add(i);
        }

        while (numbers.Count > 0)
        {

            int index = Random.Range(0, numbers.Count);

            int ransu = numbers[index];

            Find.Enqueue(objects[ransu]);

            numbers.RemoveAt(index);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("object"))
        {
            float x = Random.Range(-5.0f, 5.0f);
            float z = Random.Range(-5.0f, 5.0f);
            transform.position = new Vector3(x, 5, z);
        }


    }
}
