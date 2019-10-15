using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemManagement
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
}
