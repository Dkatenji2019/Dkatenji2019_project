using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManagement:MonoBehaviour{

    [SerializeField] private GameObject UiUpdateObjectToGetComponent;
    private UIUpdate uiUpdate = new UIUpdate();

    public Text OdaiName_EditOnUnity;
    public Text OdaiHint_EditOnUnity;
    public Text GrabItemName_EditOnUnity;

    //デザイン案が決まり次第、以下のフィールドに対する処理を追加する
    //public Text IsMatchedWithOdai_EditOnUnity;
    ////public Image GameTimeFromStart_EditOnUnity;
    //public Image GrabbedTime_EditOnUnity;

    void awake()
    {
        uiUpdate = UiUpdateObjectToGetComponent.GetComponent<UIUpdate>();
        OdaiName_EditOnUnity.text = uiUpdate.OdaiName;
        OdaiHint_EditOnUnity.text = uiUpdate.OdaiHint;
        GrabItemName_EditOnUnity.text = uiUpdate.GrabItemName;
    }
}
