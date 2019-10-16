﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemRegistrator : MonoBehaviour {

    private Queue<ItemInformation> _itemInformationQ = new Queue<ItemInformation>();
    public Queue<ItemInformation> ItemInformationQ
    {
        get { return this._itemInformationQ; }
    }


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

        for(int i = 0; i< FindScriptableobject.ItemsList.Count; i++)
        {
            //アイテム情報を格納するItemInformationCreate(scriptableobject)に名前が記述されていなかった場合
            if (FindScriptableobject.ItemsList[i].ItemName.Length == 0)
            {
                _itemInformationQ.Enqueue(new ItemInformation("☆---名前を追加してください---☆", FindScriptableobject.ItemsList[i].ItemObject, i));
            }
            else
            {
                _itemInformationQ.Enqueue(new ItemInformation(FindScriptableobject.ItemsList[i].ItemName, FindScriptableobject.ItemsList[i].ItemObject, i));
            }
        }

        queue_shuffle();

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
        _itemInformationQ = _itemInformationQ.;
    }

}
