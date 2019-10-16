using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIUpdate : MonoBehaviour {

    /// <summary>
    /// お題の名前
    /// </summary>
    public string OdaiName { get; set; }
    /// <summary>
    /// お題のヒント
    /// </summary>
    public string OdaiHint { get; set; }
    /// <summary>
    /// 掴んでいるアイテムの名前
    /// </summary>
    public string GrabItemName { get; set; }
    /// <summary>
    /// つかんだアイテムがお題と一致しているか
    /// </summary>
    public bool IsMatchedWithOdai { get; set; }
    /// <summary>
    /// ゲームの経過時間
    /// </summary>
    public float GameTimeFromStart { get; set; }

    /// <summary>
    /// アイテムを掴んでいる時間
    /// </summary>
    public float GrabbedItemTime { get; set; }

	
	// Update is called once per frame
	void Update () {
		
	}

    private void meterChanger()
    {

    }

}
