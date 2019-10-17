using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeCounter : MonoBehaviour {



    private float gameTime;

    /// <summary>
    /// 何秒でゲームが終わるか
    /// </summary>
    private  float timeOut;
    [SerializeField] private float timeOutValue = 720.0f;


    /// <summary>
    /// ゲームがスタートしてから終わるまでの経過時間を0～１の範囲で返す
    /// </summary>
    public float GameTimeRangeZeroToOne { get { return _gameTimeRangeZeroToOne; } }
    private  float _gameTimeRangeZeroToOne;


    /// <summary>
    /// ゲーム開始時のフラグ
    /// </summary>
    public bool GameStartTrigger { set { _gameStartTrigger = value; } }
    private  bool _gameStartTrigger;


    /// <summary>
    /// ゲーム終了時のフラグ
    /// </summary>
    public bool GameEndTrigger { get { return this._gameEndTrigger; } }
    private bool _gameEndTrigger;

    // Use this for initialization
    void Start () {
        gameTime = 0.0f;
        timeOut = timeOutValue;
        _gameStartTrigger = false;
        _gameEndTrigger = false;
    }
	
	// Update is called once per frame
	void Update () {

        if(_gameEndTrigger)
        {
            return;
        }

        else if(_gameStartTrigger)
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
            _gameTimeRangeZeroToOne = 1;
        }
        else if(timeOutValue - gameTime > 0)
        {
            _gameTimeRangeZeroToOne = (timeOutValue - gameTime) / timeOutValue;
        }
        else if(gameTime - timeOutValue >= 0)
        {
            _gameTimeRangeZeroToOne = 0;
        }
    }
}
