using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//作成者:杉山
//ゲーム開始時に呼ぶ処理をここで一括で登録する
public class GameStartEvent : MonoBehaviour
{
    [Header("スタート時にアクティブにするオブジェクト")]
    [SerializeField] GameObject[] _activeObjects;
    [Header("ゲームの開始を判断するコンポーネント")]
    [SerializeField] JudgeGameStart _judgeGameStart;
    [Header("内側の波の生成")]
    [SerializeField] InstantiateWave _inWave;
    [Header("外側の波の生成")]
    [SerializeField] InstantiateWave _outWave;
    [Header("敵の行動")]
    [SerializeField] AlgorithmOfEnemy _algorithmOfEnemy;
    [Header("制限時間")]
    [SerializeField] TimeLimit _timeLimit;
    [Header("BGM")]
    [SerializeField] AudioSource _bgm;
    void Start()
    {
        _judgeGameStart.StartGameAction += Event;
    }

    public void Event()
    {
        //登録されたオブジェクトをアクティブにする
        for(int i=0;i<_activeObjects.Length ;i++)
        {
            _activeObjects[i].SetActive(true);
        }
        //波を生成し始める
        _inWave.Switch = true;
        _outWave.Switch = true;
        //敵が行動し始める
        _algorithmOfEnemy.Switch = true;
        //時間制限が減り始める
        _timeLimit.Switch = true;
        //BGMを流し始める
        _bgm.Play();
    }
}
