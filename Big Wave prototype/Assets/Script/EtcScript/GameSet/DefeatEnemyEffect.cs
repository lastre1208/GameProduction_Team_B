using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

//作成者:杉山
//敵を倒したときの演出(シーン遷移も含めて)
public class DefeatEnemyEffect : MonoBehaviour
{
    [Header("クリア時のカメラ")]
    [SerializeField] CinemachineBlendListCamera _clearCamera;
    [Header("トリックのチャージ")]
    [SerializeField] ChargeTrickPoint _chargeTrickPoint;
    [Header("プレイヤーのHP")]
    [SerializeField] HP _player_HP;
    [Header("操作変更")]
    [SerializeField] PlayerInput _playerInput;
    [Header("敵の死亡モーション")]
    [SerializeField] EnemyDeadMotion _enemyDeadMotion;
    [Header("プレイヤーの死亡モーション")]
    [SerializeField] PlayerWinMotion _playerWinMotion;
    [Header("内側の波の生成")]
    [SerializeField] InstantiateWave inWave;
    [Header("外側の波の生成")]
    [SerializeField] InstantiateWave outWave;
    [Header("ロープ")]
    [SerializeField] RopeEffect _ropeEffect;
    [Header("制限時間")]
    [SerializeField] TimeLimit _timeLimit;
    [Header("敵の行動")]
    [SerializeField] AlgorithmOfEnemy _algorithmOfEnemy;
    [Header("ゲーム中のUI")]
    [SerializeField] GameObject _duringGame_UI;
    [Header("シーン移行コンポーネント")]
    [SerializeField] SceneController _controller;
    [Header("敵を倒してから何秒後にシーン遷移するか")]
    [SerializeField] float _changeSceneTime;//何秒後にシーン遷移するか
    [SerializeField] JudgeGameSet _judgeGameSet;
    [SerializeField] UnityEvent _clearEvent;
    float _currentChangeSceneTime=0;
    bool _startEffect=false;//演出の開始状況

    public void Trigger()//演出開始
    {
        _startEffect = true;
        _player_HP.Fix = true;//プレイヤーのHPを固定
        _duringGame_UI.SetActive(false);//ゲームのUIの非表示
        _playerInput.SwitchCurrentActionMap("Win");//操作の変更
        _chargeTrickPoint.Switch = false;//チャージしないようにする
        _clearCamera.enabled = true;//クリア時のカメラの移動を開始(実装予定)
        _enemyDeadMotion.Trigger();//敵の撃破モーションの再生
        _playerWinMotion.Trigger();//プレイヤーの勝利モーションの再生
        _timeLimit.Switch = false;//制限時間を止める
        _algorithmOfEnemy.Switch = false;//敵の行動を止める
        _ropeEffect.Switch = false;//縄を消す
        //波の生成を止める
        inWave.Switch = false;
        outWave.Switch = false;
        _clearEvent.Invoke();
    }

    void Start()
    {
        _judgeGameSet.GameClearAction += Trigger;
    }

    void Update()
    {
        UpdateChangeScene();
    }

    void UpdateChangeScene()//シーン移行の処理
    {
        if (!_startEffect) return;
        _currentChangeSceneTime += Time.deltaTime;

        if(_currentChangeSceneTime>=_changeSceneTime)
        {
            _controller.ClearScene();//クリアシーンに移行する
        }
    }
}
