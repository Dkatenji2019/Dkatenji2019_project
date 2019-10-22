﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemRegistrator : MonoBehaviour {


    private FindScriptableobjects findScriptableObject;

    private Queue<GameObject> _itemQ = new Queue<GameObject>();
    public Queue<GameObject> ItemQ
    {
        get { return this._itemQ; }
        set { this._itemQ = value; }
    }

    private string _odaiName;
    public string OdaiName
    {
        get { return _odaiName; }
    }
    private string _odaiHint;
    public string OdaiHint
    {
        get { return _odaiHint; }
    }

    void Awake()
    {
        InstanceItemGameObjects();
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
        findScriptableObject = this.GetComponent<FindScriptableobjects>();

        //お題を混ぜる
        queue_shuffle();


        for (int i = 0; i < findScriptableObject.ItemsList.Count; i++)
        {
            if (findScriptableObject.ItemsList[i].ItemObject == null)
            {
                continue;
            }
            else
            {
                    GameObject instancedgameObject = Instantiate(findScriptableObject.ItemsList[i].ItemObject);
                    var ig = instancedgameObject.AddComponent<ItemInformation>();

                        //アイテム情報を格納するItemInformationCreate(scriptableobject)に名前が記述されていなかった場合
                        if (findScriptableObject.ItemsList[i].ItemName.Length == 0)
                        {

                    if (findScriptableObject.ItemsList[i].ItemHint.Length == 0)
                    {
                        ig.itemInformation("☆---名前を追加してください---☆", findScriptableObject.ItemsList[i].ItemObject, i, "ヒントはないよ！");
                    }
                    else
                    {
                        ig.itemInformation("☆---名前を追加してください---☆", findScriptableObject.ItemsList[i].ItemObject, i, findScriptableObject.ItemsList[i].ItemHint);
                    }
                        

                        }
                        else if(findScriptableObject.ItemsList[i].ItemHint.Length == 0)
                        {
                            ig.itemInformation(findScriptableObject.ItemsList[i].ItemName, findScriptableObject.ItemsList[i].ItemObject, i, "ヒントはないよ！");
                        }
                        else
                        {
                            ig.itemInformation(findScriptableObject.ItemsList[i].ItemName, findScriptableObject.ItemsList[i].ItemObject, i, findScriptableObject.ItemsList[i].ItemHint);
                        }

                _itemQ.Enqueue(instancedgameObject);
                    // Debug.Log(instancedgameObject.GetComponent<ItemInformation>().ItemName);
            }

        }
        UIOdaiUpadte();

        foreach (var q in _itemQ)
        {
            Debug.Log("アイテム名:" + q.GetComponent<ItemInformation>().ItemName + "３Ｄオブジェクト名:" + q.GetComponent<ItemInformation>().ItemObject + "格納順:" + q.GetComponent<ItemInformation>().ItemNumber + "ヒント:" + q.GetComponent<ItemInformation>().ItemHint);
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

        int n = findScriptableObject.ItemsList.Count;

        List<int> numbers = new List<int>();

        for (int i = 0; i < findScriptableObject.ItemsList.Count; i++)
        {
            numbers.Add(i);
        }

        for (int i = 0; i < n; i++)
        {
            int index = Random.Range(0, numbers.Count);

            int ransu = numbers[index];

            numbers.RemoveAt(index);

            int r = ransu;

            var rand = findScriptableObject.ItemsList[r];
            findScriptableObject.ItemsList[r] = findScriptableObject.ItemsList[i];
            findScriptableObject.ItemsList[i] = rand;
        }

    }

    public void DestroyItem(int grabbedItemNumber)
    {
        if(grabbedItemNumber == NowOdaiNumber)
        {
            Destroy(_itemQ.Peek());
            _itemQ.Dequeue();
            UIOdaiUpadte();
            NowOdaiNumber++;
        }
        else
        {
            NowOdaiNumber+=0;
        }

        //Debug.Log(NowOdaiNumber);
    }

    private void UIOdaiUpadte()
    {
        _odaiName = _itemQ.Peek().GetComponent<ItemInformation>().ItemName;
        _odaiHint = _itemQ.Peek().GetComponent<ItemInformation>().ItemHint;
    }
}

