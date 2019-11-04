using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class TimeCounter : MonoBehaviour {

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
    public bool _gameEndTrigger;

    // Use this for initialization
    private void Start() {

        StartSetting();

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
            return;
        }
        else if (gameTime >= timeOut)
        {
            _gameEndTrigger = true;
            gameTime = 0.0f;
        }
        else if (_gameStartTrigger)
        {
            Timer();
            Caluculate_GameTimeRangeZeroToOne();
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
}
