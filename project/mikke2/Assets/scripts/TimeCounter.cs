using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class TimeCounter : MonoBehaviour {

    private ScoreCounter sc = null;
    private float gameTime;

    /// <summary>
    /// 何秒でゲームが終わるか
    /// </summary>
    private  float timeOut;

 //   public float timeOutValue = 360.0f;


    public float timeOutValue = 5.0f;
    /// <summary>
    /// ゲームがスタートしてから終わるまでの経過時間を0～１の範囲で返す
    /// </summary>
    public float GameTimeRangeZeroToOne { get { return _gameTimeRangeZeroToOne; } }
    [SerializeField] private  float _gameTimeRangeZeroToOne;


    /// <summary>
    /// ゲーム開始時のフラグ
    /// </summary>
    public bool GameStartTrigger { set { _gameStartTrigger = value; } }
    [SerializeField]private  bool _gameStartTrigger;


    /// <summary>
    /// ゲーム終了時のフラグ
    /// </summary>
    public bool GameEndTrigger { get { return this._gameEndTrigger; } }
    private bool _gameEndTrigger;

    // Use this for initialization
    private void Start() {

        StartSetting();

        // イベントにイベントハンドラーを追加
        SceneManager.sceneLoaded += SceneLoaded;
    }

        // イベントハンドラー（イベント発生時に動かしたい処理）
        void SceneLoaded(Scene nextScene, LoadSceneMode mode)
        {
            Debug.Log(nextScene.name);
            Debug.Log(mode);
        }

    // Update is called once per frame
    private void Update () {

        trrigerUpdate();

    }

    private void StartSetting()
    {
        gameTime = 0.0f;
        timeOut = timeOutValue;
        _gameStartTrigger = true;
        _gameEndTrigger = false;
    }

    private void trrigerUpdate()
    {
        if (_gameEndTrigger)
        {
            GameEnd();
            return;
        }

        else if (_gameStartTrigger)
        {
            Timer();
            Caluculate_GameTimeRangeZeroToOne();
        }

        else if (gameTime >= timeOut)
        {
            gameTime = 0.0f;
            _gameEndTrigger = true;
        }
    }

    private void Timer()
    {
        gameTime += Time.deltaTime;
    }

    private void Caluculate_GameTimeRangeZeroToOne()
    {
        if(gameTime == 0)
        {
            _gameTimeRangeZeroToOne = 0;
        }
        else if(timeOutValue - gameTime > 0)
        {
            _gameTimeRangeZeroToOne =  1 - ((timeOutValue - gameTime) / timeOutValue);
        }
        else if(gameTime - timeOutValue >= 0)
        {
            _gameTimeRangeZeroToOne = 1;
        }
    }

    private void GameEnd()
    {
        sc = GameObject.FindGameObjectWithTag("ScoreCounter").GetComponent<ScoreCounter>();
        DontDestroyOnLoad(sc);
        SceneManager.LoadScene("Start");
    }
}
