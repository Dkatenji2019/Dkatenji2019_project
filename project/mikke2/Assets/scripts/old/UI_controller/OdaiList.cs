using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OdaiList : MonoBehaviour {


    //改善の余地ありあり
    //Start()内の処理を別のスクリプトに移動する。つまりゲームオブジェクトの名前を取りたいだけなので一括して他のスクリプトにまとめるべき

    [SerializeField] public Queue<string> _itemsNameUiTexts = new Queue<string>();
    public Queue<string> ItemsNameUiTexts
    {
        get { return _itemsNameUiTexts; }
        set { _itemsNameUiTexts = value; }
    }



    public GameObject textMain;
    [SerializeField]private GameObject textSub;

    void Start()
    {
        ItemRegistrator i = new ItemRegistrator();

        var Find_GameObject = GameObject.Find("FIND_OBJECT_MANAGER");
        var tmp_FS = Find_GameObject.GetComponent<FindScriptableobjects>();
        foreach (var element in tmp_FS.ItemsList)
        {
            if (element.ItemName.Length != 0)
            {
                _itemsNameUiTexts.Enqueue(element.ItemName);
            }
        }


        ChangeContainsAndDisplayOdai();
    }

    public /*static*/ Text AddTextToCanvas(string textString, GameObject canvasGameObject)
    {

        Text text = canvasGameObject.GetComponent<Text>();
        text.text = textString;

        Font ArialFont = (Font)Resources.GetBuiltinResource(typeof(Font), "Arial.ttf");
        text.font = ArialFont;
        text.material = ArialFont.material;

        return text;
    }

    public void ChangeContainsAndDisplayOdai()
    {

        ////最初のお題
        //AddTextToCanvas(_itemsNameUiTexts.Dequeue(), textMain);
        ////次のお題
        ////AddTextToCanvas(_itemsNameUiTexts.Peek(), textSub);
        ///
       AddTextToCanvas(_itemsNameUiTexts.Peek(), textMain);// _itemsNameUiTexts.Peek()
       // AddTextToCanvas("本当はここに次のお題が入るよ", textSub);

    }

}
