using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mikke : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject[] objects;

    List<int> numbers = new List<int>();

    Queue<GameObject> Obje = new Queue<GameObject>();
    Queue<GameObject> Find = new Queue<GameObject>();


    void Start()
    {
        //Place and Enqueue objects
        for (int i = 0; i < objects.Length-1; i++)
        {
            numbers.Add(i);
            
        }
        while (numbers.Count > 0)
        {

            int index = Random.Range(0, numbers.Count);

            int ransu = numbers[index];

            float x = Random.Range(-25.0f, 25.0f);
            float z = Random.Range(-25.0f, 25.0f);
            Instantiate(objects[ransu], new Vector3(x, 5, z), transform.rotation);

            Obje.Enqueue(objects[ransu]);

            numbers.RemoveAt(index);
        }

        //Enqueue Looking objects 
        for (int i = 0; i <= objects.Length-1; i++)
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

    
}
