using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemRegistrator : MonoBehaviour {

    ///<summary>
    ///Scriptableobjectsを一元管理しており、
    ///実際に使用するデータを格納したクラスが,
    ///FindScriptableObject
    ///</summary>
    private FindScriptableobjects findScriptableObject;

    private Queue<GameObject> _itemQ = new Queue<GameObject>();
    public Queue<GameObject> ItemQ
    {
        get { return this._itemQ; }
        set { this._itemQ = value; }
    }

     private string _odaiName;
    public string OdaiName
    {
        get { return _odaiName; }
    }
    private string _odaiHint;
    public string OdaiHint
    {
        get { return _odaiHint; }
    }
    private int _odaiLeftAmount;
    public int OdaiLeftAmount
    {
        get { return _odaiLeftAmount; }
    }

    ScoreCounter scoreCounter; 

    void Awake()
    {
        InstanceItemGameObjects();
    }


    //お題は常に番号で管理される。プレイヤーがお題を１クリアするごとに１繰り上がる。
    private int NowOdaiNumber = 0;

    /// <summary>
    /// ゲーム開始時にスクリプタブルオブジェクトから読み取ったアイテム情報をQueueに格納する。
    /// ここでいうアイテム情報とは、
    /// [1]ＵＩなどに表示するアイテムの名前
    /// [2]フィールドに配置するゲームオブジェクト（プレファブ)
    /// [3]格納する順番
    /// [4]アイテムのポイント
    /// [5]アイテムをどこに配置するか
    /// [6]アイテムのヒント
    /// である
    /// </summary>
    private void InstanceItemGameObjects()
    {
        
        findScriptableObject = this.GetComponent<FindScriptableobjects>();

        //お題を混ぜる
        queue_shuffle();

        //以下は元データ(scriptableobjects)の数だけカウントされる
        for (int i = 0; i < findScriptableObject.ItemsList.Count; i++)
        {
            //☆[重要]☆
            //ItemsList自体は生成するアイテム情報だけを持ったクラスである。
            //そのため、以下でgameObjectを生成する
            var sourceinformation = findScriptableObject.ItemsList[i];

            if (sourceinformation.ItemObject == null)
            {
                continue;
            }
            else
            {
                GameObject instancedGameObject = Instantiate(sourceinformation.ItemObject);
                var iteminformation = instancedGameObject.AddComponent<ItemInformation>();

                //実際にアイテムをＱに配置してよいか調べる変数
                //情報の記入漏れがあるとアイテムは格納されない
                bool itemGeneratedAlsoIsAllowedTo;
                itemGeneratedAlsoIsAllowedTo = CheckNoMissFromItemInformation(sourceinformation);

                if(itemGeneratedAlsoIsAllowedTo == false)
                {
                    Destroy(instancedGameObject);
                    continue;
                }
                else
                {
                 iteminformation.itemInformation(sourceinformation.ItemName,
                                                 sourceinformation.ItemObject, 
                                                 i,
                                                 sourceinformation.ItemPoint, 
                                                 (int)sourceinformation.positionEnumerate, 
                                                 sourceinformation.ItemHint
                                                );
                }
                //アイテムをＱに格納する
                _itemQ.Enqueue(instancedGameObject);
            }

        }
        _odaiLeftAmount = _itemQ.Count;
        OdaiUpadte();

        //byte[] data = System.Text.Encoding.ASCII.GetBytes(element.ItemName);
        //string hoge = null;
        //for (int i = 0; i < data.Length; i++)
        //{
        //    Debug.Log(Convert.ToString(data[i], 16) + " - ");
        //}
        //Debug.Log("-------------------------------------------");

    }

    private bool CheckNoMissFromItemInformation(ItemInformationCreate sourceinformation)
    {
        string errorMessage = "";

        if (sourceinformation.ItemName.Length == 0)
        {
            errorMessage += "名前,";
        }
        if (sourceinformation.ItemHint.Length == 0)
        {
            errorMessage += "ヒント,";
        }
        if (sourceinformation.ItemPoint == 0)
        {
            errorMessage += "ポイント";
        }

        if (errorMessage.Length != 0)
        {
            Debug.Log(errorMessage + "の情報を追加してください。" + sourceinformation.ItemObject.name);
        }

        return errorMessage.Length == 0 ? true : false;
    }

    private void queue_shuffle()
    {

        int n = findScriptableObject.ItemsList.Count;

        List<int> numbers = new List<int>();

        for (int i = 0; i < findScriptableObject.ItemsList.Count; i++)
        {
            numbers.Add(i);
        }

        for (int i = 0; i < n; i++)
        {
            int index = Random.Range(0, numbers.Count);

            int ransu = numbers[index];

            numbers.RemoveAt(index);

            int r = ransu;

            var rand = findScriptableObject.ItemsList[r];
            findScriptableObject.ItemsList[r] = findScriptableObject.ItemsList[i];
            findScriptableObject.ItemsList[i] = rand;
        }

    }

    void Update()
    {
        if(Input.GetKey(KeyCode.W))
        {
            DestroyItem(0);
        }
    }
    public void DestroyItem(int grabbedItemNumber)
    {
        if(grabbedItemNumber == NowOdaiNumber || Input.GetKeyDown(KeyCode.Space))
        {
            ScoreCounter.AddScoreValue(_itemQ.Peek().GetComponent<ItemInformation>().ItemPoint);
            Destroy(_itemQ.Peek());
            _itemQ.Dequeue();
            _odaiLeftAmount = _itemQ.Count;

            OdaiUpadte();
            NowOdaiNumber++;
        }
        else
        {
            NowOdaiNumber+=0;
        }

        //Debug.Log(NowOdaiNumber);
    }

    private void OdaiUpadte()
    {
        _odaiName = _itemQ.Peek().GetComponent<ItemInformation>().ItemName;
        _odaiHint = _itemQ.Peek().GetComponent<ItemInformation>().ItemHint;
    }
}

