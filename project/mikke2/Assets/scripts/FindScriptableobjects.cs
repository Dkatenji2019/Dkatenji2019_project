using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEditor;

public class FindScriptableobjects : MonoBehaviour
{
    [Tooltip("\n☆使い方☆\n" +
        "1,今回だけobjects/scriptableobjects(sample)ディレクトリ上で右クリックで[create]=>[アイテムを生成する！]" +
        "2,scriptableobjectをobjectsディレクトリ上に置く\n" +
        "3,ヒエラルキー上のFIND_OBJECT_MANAGERのインスペクタに飛び適用ボタンを押す\n\n")]
    [Header("scriptableobjects格納list")]
    [SerializeField]
    private List<ItemInformation> _itemsList = new List<ItemInformation>();

    public List<ItemInformation> ItemsList
    {
        get { return _itemsList; }
        set { _itemsList = value; }
    }


    //Directory名は任意で変更可
    [Tooltip("\nディレクトリのパスを記入\n")]
    [Header("ディレクトリパスを記入")]
    [Multiline(3)]
    public string PathName = "Assets/objects/scriptableobjects(sample)";

    public void find_scriptableobjects_in_folda()
    {

        DirectoryInfo dir = new DirectoryInfo(PathName);
        FileInfo[] info = dir.GetFiles("*.asset");


        if (info.Length == 0)
        {
            return;
        }

        if (_itemsList.Count != 0)
        {
            _itemsList.Clear();
        }


        foreach (FileInfo f in info)
        {
            var element = AssetDatabase.LoadAssetAtPath<ItemInformation>(Path.Combine("Assets/objects/scriptableobjects(sample)", f.Name));
            _itemsList.Add(element);
            //Debug.Log(f.Name);

        }
    }

}
