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

    private void AddedVrtk_InteractableObjectComponent()
    {
        if (this.GetComponent<VRTK.VRTK_InteractableObject>() != null)
        {
            return;
        }
        else if (this.GetComponent<VRTK.VRTK_InteractableObject>() == null)
        {
            vrtk_InteractableObject = this.GetComponent<VRTK.VRTK_InteractableObject>();
        }
    }

    private bool GameObjectGrabbedByController()
    {
        return vrtk_InteractableObject.isGrabbable;
    }
}
