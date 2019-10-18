using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemInformation
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

    public string ItemHint { get; set; }

    public ItemInformation(string _itemName, GameObject _itemObject, int _itemNumber, string _itemHint = "ヒントはないよ！")
    {
        this.ItemName = _itemName;
        this.ItemObject = _itemObject;
        this.ItemNumber = _itemNumber;
        this.ItemHint = _itemHint;
    }
}
