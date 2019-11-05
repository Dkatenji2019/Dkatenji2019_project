using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEditor;

public class FindSakuraObjects : MonoBehaviour {

    private List<GameObject> _sakuraitemsList = new List<GameObject>();

    public List<GameObject> SakuraItemsList
    {
        get { return _sakuraitemsList; }
        set { _sakuraitemsList = value; }
    }

    public int seiseisuu = 3;

    //Directory名は任意で変更可
    [Tooltip("\nディレクトリのパスを記入\n")]
    [Header("ディレクトリパスを記入")]
    [Multiline(3)]
    public string PathName;

    public void find_scriptableobjects_in_folda()
    {

        DirectoryInfo dir = new DirectoryInfo(PathName);
        FileInfo[] info = dir.GetFiles("*.prefab");


        if (info.Length == 0)
        {
            return;
        }

        if (_sakuraitemsList.Count != 0)
        {
            _sakuraitemsList.Clear();
        }


        foreach (FileInfo f in info)
        {
            var element = AssetDatabase.LoadAssetAtPath<GameObject>(Path.Combine(PathName, f.Name));
            _sakuraitemsList.Add(element);
            //Debug.Log(f.Name);

        }
    }

}
