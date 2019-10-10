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

    [SerializeField]private List<GameObject> hoge = new List<GameObject>();

    private void Awake()
    {
        //for(int i = 0; i< 5; i++)
        //{
        //    hoge.Add(this.GetComponent<FindScriptableobjects>().ItemsList.ItemObject);
        //}
    }

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
        for (int i = 0; i <= objects.Length; i++)
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
