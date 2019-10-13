using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class sample : MonoBehaviour {

    [SerializeField]private List<GameObject> items_GameObjct = new List<GameObject>();
    [SerializeField]private List<string> items_name = new List<string>();


    //このソースコードはあくまでサンプルである。
    //別のソースコードに移すことを推奨する。
    //FIND_OBJECT_MANAGERを参考にしてくれ

    // Use this for initialization
    void Awake() {

        var tmp_FS = this.GetComponent<FindScriptableobjects>();
        foreach (var element in tmp_FS.ItemsList)
        {
            items_GameObjct.Add(element.ItemObject);

            if (element.ItemObject.GetComponent<ItemInformationOnPlaying>() == null)
            {
                element.ItemObject.AddComponent<ItemInformationOnPlaying>().MyItemName = element.ItemName;
            }

            if (element.ItemName.Length == 0)
            {
                items_name.Add("☆---名前を追加してください---☆");
            }
            else
            {
                items_name.Add(element.ItemName);
            }


            //byte[] data = System.Text.Encoding.ASCII.GetBytes(element.ItemName);
            //string hoge = null;
            //for (int i = 0; i < data.Length; i++)
            //{
            //    Debug.Log(Convert.ToString(data[i], 16) + " - ");
            //}
            //Debug.Log("-------------------------------------------");

        }

    }


}
