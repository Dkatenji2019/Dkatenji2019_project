﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

////VRTKが配布している物体判定処理
//[RequireComponent(typeof(VRTK.VRTK_InteractableObject))]
//VRTK_InteractableObjectを返すための処理
[RequireComponent(typeof(GrabItemEvent))]
[RequireComponent(typeof(Rigidbody))]

public class ItemInformation : MonoBehaviour
{
    /// <summary>
    /// アイテムの名前
    /// </summary>
    public string ItemName { get; set; }
    /// <summary>
    /// アイテムの3Dオブジェクト(prefab)データ
    /// </summary>
    public GameObject ItemObject { get; set; }

    /// <summary>
    /// アイテムの格納順を記述
    /// </summary>
    public int ItemNumber { get; set; }

    /// <summary>
    /// アイテムのヒントを記述
    /// </summary>
    public string ItemHint { get; set; }


    /// <summary>
    /// アイテム一つ当たりのポイントを記述
    /// </summary>
    public int ItemPoint { get; set; }

    public ItemInformation itemInformation(string _itemName, GameObject _itemObject, int _itemNumber, int _itemPoint, string _itemHint = "ヒントはないよ！")
    {
        this.ItemName = _itemName;
        this.ItemObject = _itemObject;
        this.ItemNumber = _itemNumber;
        this.ItemPoint = _itemPoint;
        this.ItemHint = _itemHint;
        return this;
    }
}
