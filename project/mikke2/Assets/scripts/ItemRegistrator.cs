using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemRegistrator : MonoBehaviour {

    private Queue<ItemInformation> _itemInformationQ = new Queue<ItemInformation>();
    public Queue<ItemInformation> ItemInformationQ
    {
        get { return this._itemInformationQ; }
    }

    public string[] Name = new string[100];

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
        List<int> numbers = new List<int>();

        for (int i = 0; i < FindScriptableobject.ItemsList.Count; i++)
        {
            numbers.Add(i);
        }

        for (int i = 0; i< FindScriptableobject.ItemsList.Count; i++)
        {
            int r = queue_shuffle(numbers);

            //アイテム情報を格納するItemInformationCreate(scriptableobject)に名前が記述されていなかった場合
            if (FindScriptableobject.ItemsList[r].ItemName.Length == 0)
            {
                _itemInformationQ.Enqueue(new ItemInformation("☆---名前を追加してください---☆", FindScriptableobject.ItemsList[r].ItemObject, i));
                Name[i] = "☆---名前を追加してください---☆";
            }
            else
            {
                _itemInformationQ.Enqueue(new ItemInformation(FindScriptableobject.ItemsList[r].ItemName, FindScriptableobject.ItemsList[r].ItemObject, i));
                Name[i] = FindScriptableobject.ItemsList[r].ItemName;
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
    private int queue_shuffle(List<int> numbers)
    {

            int index = Random.Range(0, numbers.Count);

            int ransu = numbers[index];

            numbers.RemoveAt(index);

        return ransu;
    }

    public void DestryItem()
    {

        _itemInformationQ.Dequeue();

    }
    public void DisplayOdai()
    {
        OdaiList L = new OdaiList();

        L.AddTextToCanvas(_itemInformationQ.Peek().ItemName, L.textMain);// _itemsNameUiTexts.Peek()
        Debug.Log("名:" + _itemInformationQ.Peek().ItemName);
    }
}

