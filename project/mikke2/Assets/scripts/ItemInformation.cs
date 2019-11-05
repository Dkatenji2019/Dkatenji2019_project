using System.Collections;
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

    /// <summary>
    /// アイテム生成場所を記述
    /// </summary>
    public int ItemRespawnPosition { get; set; }

    public ItemInformation itemInformation(string itemName, GameObject itemObject, int itemNumber, int itemPoint, int itemRespawnPosition = 0, string itemHint = "ヒントはないよ！")
    {
        this.ItemName = itemName;
        this.ItemObject = itemObject;
        this.ItemNumber = itemNumber;
        this.ItemPoint = itemPoint;
        this.ItemRespawnPosition = itemRespawnPosition;
        this.ItemHint = itemHint;
        return this;
    }
}
