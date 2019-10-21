using System.Collections;
using System.Collections.Generic;
using UnityEngine;

////VRTKが配布している物体判定処理
//[RequireComponent(typeof(VRTK.VRTK_InteractableObject))]
//VRTK_InteractableObjectを返すための処理
[RequireComponent(typeof(ReturnGrabItemInformation))]

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

    public string ItemHint { get; set; }

    public int _ItemNumber;

    public ItemInformation itemInformation(string _itemName, GameObject _itemObject, int _itemNumber, string _itemHint = "ヒントはないよ！")
    {
        this.ItemName = _itemName;
        this.ItemObject = _itemObject;
        this.ItemNumber = _itemNumber;
        this.ItemHint = _itemHint;
        this._ItemNumber = _itemNumber;

        return this;
    }
}
