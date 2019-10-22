using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class move : MonoBehaviour
{
    // Start is called before the first frame update

    private const int ROTATE_BUTTON = 0;
    private const float ANGLE_LIMIT_UP = 60f;
    private const float ANGLE_LIMIT_DOWN = -60f;

    public float rotate_speed = 7.0f;

    public GameObject player;

    private void rotateCameraAngle()
    {
        Vector3 angle = new Vector3(
        Input.GetAxis("Mouse X") * rotate_speed,
        Input.GetAxis("Mouse Y") * -1 * rotate_speed,
        0
    );

        transform.eulerAngles += new Vector3(angle.y, angle.x);
    }

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");

    }


    // Update is called once per frame
    void Update()
    {
        transform.position = player.transform.position;

        if (Input.GetMouseButton(ROTATE_BUTTON))
        {
            rotateCameraAngle();
        }

        float angle_x = 180f <= transform.eulerAngles.x ? transform.eulerAngles.x - 360 : transform.eulerAngles.x;
        transform.eulerAngles = new Vector3(
            Mathf.Clamp(angle_x, ANGLE_LIMIT_DOWN, ANGLE_LIMIT_UP),
            transform.eulerAngles.y,
            transform.eulerAngles.z
        );
    }
}