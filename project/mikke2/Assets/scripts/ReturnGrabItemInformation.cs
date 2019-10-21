using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReturnGrabItemInformation : MonoBehaviour {

    private VRTK.VRTK_InteractableObject vrtk_InteractableObject = new VRTK.VRTK_InteractableObject();
    private ItemInformation ii  = null;
    private ItemRegistrator ir = null;
    private bool IsCompponentsAttached = false;

    private bool _isItemGrabbed;
    public bool IsItemGrabbed
    {
        get
        {
            return _isItemGrabbed;
        }
    }
    [SerializeField]private int _grabbedItemNumber;
    public int GrabbedItemNumber
    {
        get
        {
            return _grabbedItemNumber;
        }
    }

    private void Awake()
    {
        ir = GameObject.FindGameObjectWithTag("ItemRegistrator").GetComponent<ItemRegistrator>(); ;
    }
    // Update is called once per frame
    void Update () {

        AddedVrtk_InteractableObjectComponent();
        getItem_InformationComponent();

        _isItemGrabbed = Func_GameObjectGrabbedByController();
        _grabbedItemNumber = Func_GameObjectNumber();

        ir.DestryItem(_grabbedItemNumber);
    }


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
        if(ii == null)
        {
            ii = this.GetComponent<ItemInformation>();
        }
    }

    private bool Func_GameObjectGrabbedByController()
    {
        return vrtk_InteractableObject.isGrabbable;
    }

    private int Func_GameObjectNumber()
    {
        return (ii != null && _isItemGrabbed  == false) ? ii.ItemNumber : -1 ;
    }
}
