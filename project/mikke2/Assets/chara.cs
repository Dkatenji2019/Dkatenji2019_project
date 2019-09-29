using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class chara : MonoBehaviour
{
    // Start is called before the first frame update

    public float speed;
    public float inputHorizontal;
    public float inputVertical;

    public Rigidbody rb;

    private void movePlayer()
    {
        inputHorizontal = Input.GetAxisRaw("Horizontal");
        inputVertical = Input.GetAxisRaw("Vertical");

        Vector3 Direct = Vector3.Scale(Camera.main.transform.forward, new Vector3(1, 0, 1)).normalized;

        Vector3 Forward = Direct * inputVertical + Camera.main.transform.right * inputHorizontal;

        rb.velocity = Forward * speed + new Vector3(0, rb.velocity.y, 0);

    }
    void Start()
    {
        rb = GetComponent<Rigidbody>();

        speed = 8.0f;
        transform.position = new Vector3(0, 10, 0);
    }
    
    // Update is called once per frame
    void Update()
    {

        movePlayer();

    }
}
