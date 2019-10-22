using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrabItemEvent : MonoBehaviour {

    private VRTK.VRTK_InteractableObject vrtk_InteractableObject = new VRTK.VRTK_InteractableObject();
    private ItemInformation ii = null;
    private ItemRegistrator ir = null;
    private UIManagement um = null;

    private bool IsCompponentsAttached = false;
    private bool isItemGrabbed;

    private int _grabbedItemNumber = 0;
    public int GrabbedItemNumber
    {
        get
        {
            return _grabbedItemNumber;
        }
    }
    public float GripTime { get; set; }
    readonly float DecideGripTime = 3.0f;


    void Start()
    {
        ir = GameObject.FindGameObjectWithTag("ItemRegistrator").GetComponent<ItemRegistrator>();
        um = GameObject.FindGameObjectWithTag("UIUpdate").GetComponent<UIManagement>();
    }

    // Update is called once per frame
    void Update() {

        AddedVrtk_InteractableObjectComponent();
        getItem_InformationComponent();

        isItemGrabbed = GameObjectGrabbedByController();
        _grabbedItemNumber = ReturnItemNumber();

        GripTimeCounter();

        GrabTimeUIUpdate();
        GrabItemNameUIUpdate();
    }


    //---コンポーネントの追加---//
    private void AddedVrtk_InteractableObjectComponent()
    {
        if (IsCompponentsAttached)
        {
            return;
        }
        if (this.GetComponent<VRTK.VRTK_InteractableObject>() != null)
        {
            IsCompponentsAttached = true;
            return;
        }
        else if (this.GetComponent<VRTK.VRTK_InteractableObject>() == null)
        {
            vrtk_InteractableObject = this.gameObject.AddComponent<VRTK.VRTK_InteractableObject>();
            vrtk_InteractableObject.isGrabbable = true;
            vrtk_InteractableObject.touchHighlightColor = Color.blue;
        }
    }

    private void getItem_InformationComponent()
    {
        if (ii == null)
        {
            ii = this.GetComponent<ItemInformation>();
        }
    }

    //---グリップ時の処理---//
    private bool GameObjectGrabbedByController()
    {
        return vrtk_InteractableObject.isGrabbable;
    }

    private int ReturnItemNumber()
    {
        return (ii != null && isItemGrabbed == false) ? ii.ItemNumber : -1;
    }


    //---グリップ時間のカウント---//
    private void GripTimeCounter()
    {
        if (isItemGrabbed)
        {
            return;
        }
        else
        {
            GripTime += Time.deltaTime;

            if (GripTime > DecideGripTime)
            {
                GripTime = 0;
                ir.DestryItem(_grabbedItemNumber);
            }
        }
    }

    //---UI周りの処理---//
    private void GrabTimeUIUpdate() 
    {
        um.GrabbedItemTime = GripTime;
    }

    private void GrabItemNameUIUpdate()
    {
        um.GrabItemName = ReturnItemName();
    }

    private string ReturnItemName()
    {
        return (ii != null && isItemGrabbed == false) ? ii.ItemName : "Nothing";
    }

}
