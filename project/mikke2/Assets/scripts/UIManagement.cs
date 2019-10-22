using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManagement:MonoBehaviour{


    [SerializeField] private ItemRegistrator ir;

    //public Text OdaiName_EditOnUnity;
    //public Text OdaiHint_EditOnUnity;
    public Text GrabItemName_EditOnUnity;
    public Slider GrabbedItemTime_EditOnUnity;

    //デザイン案が決まり次第、以下のフィールドに対する処理を追加する
    //public Text IsMatchedWithOdai_EditOnUnity;
    ////public Image GameTimeFromStart_EditOnUnity;
    //public Image GrabbedTime_EditOnUnity;

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
    public string GrabItemName { get; set; }//ok
    /// <summary>
    /// つかんだアイテムがお題と一致しているか
    /// </summary>
    public bool IsMatchedWithOdai { get; set; }
    ///// <summary>
    ///// ゲームの経過時間
    ///// </summary>
    //public float GameTimeFromStart { get; set; }

    /// <summary>
    /// アイテムを掴んでいる時間
    /// </summary>
    public float GrabbedItemTime { get; set; }//ok
    public float _GrabbedItemTime;
    public string _GrabItemName;

    private void Update()
    {

        //OdaiName_EditOnUnity.text = OdaiName;
        //OdaiHint_EditOnUnity.text = OdaiHint;
        GrabItemName_EditOnUnity.text = GrabItemName;
        GrabbedItemTime_EditOnUnity.value = GrabbedItemTime;
        _GrabbedItemTime = GrabbedItemTime;
        _GrabItemName = GrabItemName;

    }
}
