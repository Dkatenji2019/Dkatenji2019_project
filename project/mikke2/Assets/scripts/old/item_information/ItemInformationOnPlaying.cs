using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemInformationOnPlaying : MonoBehaviour
{

    /// <summary>
    /// prefabにItemInformationOnPlayingをアタッチする際に名前を記入していないとうまくアイテムが消えてくれない
    /// </summary>
    [SerializeField]private string _myItemName;
   public string MyItemName
    {
        get
        { return _myItemName; }
        set
        {
            _myItemName = value;
        }
    }
}
