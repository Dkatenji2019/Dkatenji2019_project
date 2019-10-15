using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemRegistrator : MonoBehaviour {

    [SerializeField]public Queue<ItemInformation> ItemInformationQ = new Queue<ItemInformation>();

    void Awake()
    {
        ItemLoadToQueue_BeforeStartGame();
    }

    private void ItemLoadToQueue_BeforeStartGame()
    {
        //Scriptableobjectsを一元管理しているクラスからの情報を格納
        var FindScriptableobject = this.GetComponent<FindScriptableobjects>();

        for(int i = 0; i< FindScriptableobject.ItemsList.Count; i++)
        {
            //アイテム情報を格納するItemInformationCreate(scriptableobject)に名前が記述されていなかった場合
            if (FindScriptableobject.ItemsList[i].ItemName.Length == 0)
            {
                ItemInformationQ.Enqueue(new ItemInformation("☆---名前を追加してください---☆", FindScriptableobject.ItemsList[i].ItemObject, i));
            }
            else
            {
                ItemInformationQ.Enqueue(new ItemInformation(FindScriptableobject.ItemsList[i].ItemName, FindScriptableobject.ItemsList[i].ItemObject, i));
            }
        }

        foreach(var q in ItemInformationQ)
        {
            Debug.Log("アイテム名:" + q.ItemName + "３Ｄオブジェクト名:" + q.ItemObject + "格納順:" + q.ItemNumber);
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
