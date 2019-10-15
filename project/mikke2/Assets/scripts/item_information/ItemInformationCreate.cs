using UnityEngine;
using UnityEditor;
using System.Linq;

[CreateAssetMenu(menuName = "アイテムを生成する！")]
public class ItemInformationCreate : ScriptableObject
{
    [SerializeField] private string _itemName;
    public string ItemName
    {
        get
        {return _itemName;}
        set
        {
             _itemName = value;
        }
    }
    [SerializeField] private GameObject _itemObject;
    public GameObject ItemObject
    {
        get
        {return _itemObject;}
        set
        {_itemObject = value;}
    }

    [SerializeField] private bool _onTheDesk;
    public bool OnTheDesk
    {
        get
        {return _onTheDesk;}
        set
        {_onTheDesk = value;}
    }

    [SerializeField] private bool _inTheDrawer;
    public bool InTheDrawer
    {
        get { return _inTheDrawer; }
        set { _inTheDrawer = value; }
    }
    [SerializeField] private bool _onTheFloor;
    public bool OnTheFloor
    {
        get { return _onTheFloor; }
        set { _onTheFloor = value; }
    }

    [SerializeField] private bool _atOneFloor;
    public  bool AtOneFloor
    {
        get { return _atOneFloor; }
        set { _atOneFloor = value; }
    }
    [SerializeField] private bool _atTwoFloor;
    public bool AtTwoFloor
    {
        get { return _atTwoFloor; }
        set { _atTwoFloor = value; }
    }

    void OnValidate()
    {
        if (_atTwoFloor)
        {
            _atOneFloor = false;
            _atTwoFloor = true;
            return;
        }
        if (_atOneFloor)
        {
           _atTwoFloor = false;
            _atOneFloor = true;
            return;
        }

    }
}
