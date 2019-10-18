using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReturnGrabItemInformation : MonoBehaviour {

    private VRTK.VRTK_InteractableObject vrtk_InteractableObject = new VRTK.VRTK_InteractableObject();
    public bool IsItemGrabbed;
	
	// Update is called once per frame
	void Update () {
        AddedVrtk_InteractableObjectComponent();
        IsItemGrabbed = GameObjectGrabbedByController();
    }

    private bool tmp = false;

    private void AddedVrtk_InteractableObjectComponent()
    {
        if (tmp)
        {
            return;
        }
        if (this.GetComponent<VRTK.VRTK_InteractableObject>() != null)
        {
            tmp = true;
            return;
        }
        else if (this.GetComponent<VRTK.VRTK_InteractableObject>() == null)
        {
            //this.AddComponent<VRTK.VRTK_InteractableObject>();
            vrtk_InteractableObject = this.gameObject.AddComponent<VRTK.VRTK_InteractableObject>();
            vrtk_InteractableObject.isGrabbable = true;
            vrtk_InteractableObject.touchHighlightColor = Color.blue;
        }
    }

    private bool GameObjectGrabbedByController()
    {
        return vrtk_InteractableObject.isGrabbable;
    }
}
