using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mapping : MonoBehaviour
{

    // Use this for initialization

    GameObject player;



    // Use this for initialization

    void Start()
    {

        player = GameObject.Find("[CameraRig]/Camera (eye)");

    }



    // Update is called once per frame

    void Update()
    {

        // レーダをくるくる回す

        transform.rotation = Quaternion.Euler(new Vector3(90f, player.transform.eulerAngles.y, 0));

        // 自分をレーダの中心にする

        transform.position = new Vector3(player.transform.position.x, 30f, player.transform.position.z);

    }
}