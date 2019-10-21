using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemRegistrator : MonoBehaviour {

    private Queue<GameObject> _itemQ = new Queue<GameObject>();
    public Queue<GameObject> ItemQ
    {
        get { return this._itemQ; }
        set { this._itemQ = value; }
    }

    void Awake()
    {
        InstanceItemGameObjects();
        Debug.Log("Qの長さ" + _itemQ.Count);
    }

    //お題は常に番号で管理される。プレイヤーがお題を１クリアするごとに１繰り上がる。
    private int NowOdaiNumber = 0;

    /// <summary>
    /// ゲーム開始時にスクリプタブルオブジェクトから読み取ったアイテム情報をQueueに格納する。
    /// ここでいうアイテム情報とは、
    /// [1]ＵＩなどに表示するアイテムの名前
    /// [2]フィールドに配置するゲームオブジェクト（プレファブ）
    /// [3]格納する順番
    /// </summary>
    private void InstanceItemGameObjects()
    {
        //Scriptableobjectsを一元管理しているクラスからの情報を格納
        var FindScriptableobject = this.GetComponent<FindScriptableobjects>();

        for (int i = 0; i < FindScriptableobject.ItemsList.Count; i++)
        {
            GameObject instancedgameObject = Instantiate(FindScriptableobject.ItemsList[i].ItemObject);
            var ig = instancedgameObject.AddComponent<ItemInformation>();

            //アイテム情報を格納するItemInformationCreate(scriptableobject)に名前が記述されていなかった場合
            if (FindScriptableobject.ItemsList[i].ItemName.Length == 0)
            {
                ig.itemInformation("☆---名前を追加してください---☆", FindScriptableobject.ItemsList[i].ItemObject, i);
            }
            else
            {
                ig.itemInformation(FindScriptableobject.ItemsList[i].ItemName, FindScriptableobject.ItemsList[i].ItemObject, i);
            }
            _itemQ.Enqueue(instancedgameObject);
            // Debug.Log(instancedgameObject.GetComponent<ItemInformation>().ItemName);

            Debug.Log("リープ回数 : " + i);
        }



        foreach (var q in _itemQ)
        {
            Debug.Log("アイテム名:" + q.GetComponent<ItemInformation>().ItemName + "３Ｄオブジェクト名:" + q.GetComponent<ItemInformation>().ItemObject + "格納順:" + q.GetComponent<ItemInformation>().ItemNumber);
        }

        //byte[] data = System.Text.Encoding.ASCII.GetBytes(element.ItemName);
        //string hoge = null;
        //for (int i = 0; i < data.Length; i++)
        //{
        //    Debug.Log(Convert.ToString(data[i], 16) + " - ");
        //}
        //Debug.Log("-------------------------------------------");


        Debug.Log("リストの長さ" + FindScriptableobject.ItemsList.Count);

    }


    public void DestryItem(int grabbedItemNumber)
    {
        if(grabbedItemNumber == NowOdaiNumber)
        {
            Destroy(_itemQ.Peek());
            _itemQ.Dequeue();
            NowOdaiNumber++;
        }
        else
        {
            NowOdaiNumber+=0;
        }

        Debug.Log(NowOdaiNumber);
    }

}

