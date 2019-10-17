using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GrabItemEvent : MonoBehaviour {

    ////ちょっと借りるな。いつか書き直す…はず

    ////circleGagescript内で取っている時間の処理をここでとることができれば、getcomponentの処理が減る
    ////　[至急]　ifの入れ子を急いで解消しなければ
    ////とても汚いので急いで書き直す

    //public Camera camera_object; //カメラを取得
    //private RaycastHit hit; //レイキャストが当たったものを取得する入れ物


    //[SerializeField] private GameObject Odai;
    //[SerializeField] private GameObject meter;//時間のメータをもっているUI(meter)


    //// Update is called once per frame
    //void Update()
    //{
    //    //マウスのポジションを取得してRayに代入
    //    Ray ray = camera_object.ScreenPointToRay(Input.mousePosition);

    //    //マウスのポジションからRayを投げて何かに当たったらhitに入れる
    //    if (Physics.Raycast(ray, out hit))
    //    {
    //        if (hit.collider.gameObject.name != "Floor")
    //        {
    //            meter.GetComponent<CircleGage>().OnTrigger = true;

    //            if (hit.collider.gameObject.GetComponent<ItemInformationOnPlaying>() != null)
    //            {
    //                Debug.Log("colliderhit:" + hit.collider.gameObject.GetComponent<ItemInformationOnPlaying>().MyItemName + ", OdaiQueue: " + Odai.GetComponent<OdaiList>()._itemsNameUiTexts.Peek());

    //                if (meter.GetComponent<Image>().fillAmount >= 1 && hit.collider.gameObject.GetComponent<ItemInformationOnPlaying>().MyItemName == Odai.GetComponent<OdaiList>()._itemsNameUiTexts.Peek())
    //                {
    //                    Destroy(hit.collider.gameObject);
    //                    Odai.GetComponent<OdaiList>()._itemsNameUiTexts.Dequeue();
    //                    Odai.GetComponent<OdaiList>().AddTextToCanvas(Odai.GetComponent<OdaiList>()._itemsNameUiTexts.Peek(), Odai.GetComponent<OdaiList>().textMain);
    //                }
    //            }


    //        }
    //        else
    //        {
    //            meter.GetComponent<CircleGage>().OnTrigger = false;
    //        }
    //    }
    //    else
    //    {
    //        meter.GetComponent<CircleGage>().OnTrigger = false;
    //    }


    //}



    public float GripTime { get; set; }
    readonly float DecideGripTime = 3.0f;

    public bool IsGripItem;


    public bool IsMatchedWithItem;


    private void Update()
    {
        if(IsGripItem)
        {
            if(GripTime > DecideGripTime && IsMatchedWithItem)
            {
                MatchedWithItem();
            }
        }
        else if(!IsGripItem)
        {
            NonGrabItem();
        }
    }

    private void destoyItem()
    {

    }

    private void GripTimeCounter()
    {
        GripTime += Time.deltaTime;
    }

    private void MatchedWithItem()
    {

    }
    private void NonGrabItem()
    {
        if (GripTime <= 0)
        {
            return;
        }
        GripTime -= Time.deltaTime;

    }

}
