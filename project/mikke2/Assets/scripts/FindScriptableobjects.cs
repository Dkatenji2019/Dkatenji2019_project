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
    private List<ItemInformationCreate> _itemsList = new List<ItemInformationCreate>();

    public List<ItemInformationCreate> ItemsList
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
            var element = AssetDatabase.LoadAssetAtPath<ItemInformationCreate>(Path.Combine("Assets/objects/scriptableobjects(sample)", f.Name));
            _itemsList.Add(element);
            //Debug.Log(f.Name);

        }
        queue_shuffle();
    }

    private void Awake()
    {
        queue_shuffle();

    }

    private void queue_shuffle()
    {

        int n = ItemsList.Count;

        List<int> numbers = new List<int>();

        for (int i = 0; i < ItemsList.Count; i++)
        {
            numbers.Add(i);
        }

        for (int i = 0; i < n; i++)
        {
            int index = Random.Range(0, numbers.Count);

            int ransu = numbers[index];

            numbers.RemoveAt(index);

            int r = ransu;

            var rand = ItemsList[r];
            ItemsList[r] = ItemsList[i];
            ItemsList[i] = rand;
        }

    }
}
