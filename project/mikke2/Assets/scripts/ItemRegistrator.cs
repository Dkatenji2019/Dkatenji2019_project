using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemRegistrator : MonoBehaviour {

    private Queue<ItemInformation> _itemInformationQ = new Queue<ItemInformation>();
    public Queue<ItemInformation> ItemInformationQ
    {
        get { return this._itemInformationQ; }
    }

    public string[] Name;

    void Awake()
    {
        ItemLoadToQueue_BeforeStartGame();
    }

    /// <summary>
    /// ゲーム開始時にスクリプタブルオブジェクトから読み取ったアイテム情報をQueueに格納する。
    /// ここでいうアイテム情報とは、
    /// [1]ＵＩなどに表示するアイテムの名前
    /// [2]フィールドに配置するゲームオブジェクト（プレファブ）
    /// [3]格納する順番
    /// </summary>
    private void ItemLoadToQueue_BeforeStartGame()
    {
        //Scriptableobjectsを一元管理しているクラスからの情報を格納
        var FindScriptableobject = this.GetComponent<FindScriptableobjects>();

        for (int i = 0; i< FindScriptableobject.ItemsList.Count; i++)
        {
            queue_shuffle();

            //アイテム情報を格納するItemInformationCreate(scriptableobject)に名前が記述されていなかった場合
            if (FindScriptableobject.ItemsList[i].ItemName.Length == 0)
            {
                _itemInformationQ.Enqueue(new ItemInformation("☆---名前を追加してください---☆", FindScriptableobject.ItemsList[i].ItemObject, i));
                Name[i] = "☆---名前を追加してください---☆";
            }
            else
            {
                _itemInformationQ.Enqueue(new ItemInformation(FindScriptableobject.ItemsList[i].ItemName, FindScriptableobject.ItemsList[i].ItemObject, i));
                Name[i] = FindScriptableobject.ItemsList[i].ItemName;
            }
        }

        

        foreach(var q in _itemInformationQ)
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
    private void queue_shuffle()
    {

        var FindScriptableobject = this.GetComponent<FindScriptableobjects>();
        int n = FindScriptableobject.ItemsList.Count;

        List<int> numbers = new List<int>();

        for (int i = 0; i < FindScriptableobject.ItemsList.Count; i++)
        {
            numbers.Add(i);
        }

        for (int i = 0; i < n; i++)
        {
            int index = Random.Range(0, numbers.Count);

            int ransu = numbers[index];

            numbers.RemoveAt(index);

            int r = ransu;

            var rand = FindScriptableobject.ItemsList[r];
            FindScriptableobject.ItemsList[r] = FindScriptableobject.ItemsList[i];
            FindScriptableobject.ItemsList[i] = rand;
        }

    }

    public void DestryItem()
    {

        _itemInformationQ.Dequeue();

    }

}

