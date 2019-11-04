﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManagement:MonoBehaviour{

    /// <summary>
    /// お題の名前
    /// </summary>
    public Text OdaiName_EditOnUnity;

    /// <summary>
    /// お題のヒント
    /// </summary>
    public Text OdaiHint_EditOnUnity;

    /// <summary>
    /// アイテムの残り数
    /// </summary>
    public Text ItemLeftAmount;

    /// <summary>
    /// 掴んでいるアイテムの名前
    /// </summary>
    //public Text GrabItemName_EditOnUnity;
    //public string GrabItemName { get; set; }//ok

    /// <summary>
    /// アイテムを掴んでいる時間
    /// </summary>
    //public Slider GrabbedItemTime_EditOnUnity;
    public Image GrabbedItemTime_EditOnUnity;
    public float GrabbedItemTime { get; set; }//ok

    /// <summary>
    /// ゲーム時間：開始から終了まで
    /// </summary>
    public Text GameTimeFromStart_EditOnUnity;

    [SerializeField]private ItemRegistrator ItemRegistrator;
    [SerializeField]private TimeCounter timeCounter;


    //デザイン案が決まり次第、以下のフィールドに対する処理を追加する
    //public Text IsMatchedWithOdai_EditOnUnity;
    //public Image GrabbedTime_EditOnUnity;


    /// <summary>
    /// つかんだアイテムがお題と一致しているか
    /// </summary>
    public bool IsMatchedWithOdai { get; set; }
    ///// <summary>
    ///// ゲームの経過時間
    ///// </summary>
    //public float GameTimeFromStart { get; set; }



    private void Update()
    {
        //GrabItemName_EditOnUnity.text = GrabItemName;
        GrabbedItemTime_EditOnUnity.fillAmount = GrabbedItemTime;
        GameTimeFromStart_EditOnUnity.text = (timeCounter.GameTimeRangeZeroToOne * timeCounter.timeOutValue).ToString();
        UITextUpdate();
    }

    public void UITextUpdate()
    {
        OdaiName_EditOnUnity.text = ItemRegistrator.OdaiName;
        OdaiHint_EditOnUnity.text = ItemRegistrator.OdaiHint;
       // ItemLeftAmount.text = ItemRegistrator.OdaiLeftAmount.ToString();
    }
}
