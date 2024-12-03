using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

//作成者:杉山
//プレイヤーが死んだときの演出(シーン遷移も含めて)
public class DeadEffect : MonoBehaviour
{
    [Header("トリックのチャージ")]
    [SerializeField] ChargeTrickPoint _chargeTrickPoint;
    [Header("プレイヤーのHP")]
    [SerializeField] HP _player_HP;
    [Header("プレイヤーの死亡モーション")]
    [SerializeField] PlayerDeadMotion _playerDeadMotion;
    [Header("チャージのエフェクト")]
    [SerializeField] ChargeTrickEffect _chargeTrickEffect;
    [Header("操作変更")]
    [SerializeField] PlayerInput _playerInput;
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
    [Header("死んでから何秒後にシーン遷移するか")]
    [SerializeField] float _changeSceneTime;//何秒後にシーン遷移するか
    [SerializeField] JudgeGameSet _judgeGameSet;
    float _currentChangeSceneTime = 0;
    bool _startEffect = false;//演出の開始状況

    public void Trigger()//演出開始
    {
        _startEffect = true;
        _player_HP.Fix = true;//プレイヤーのHPを固定
        _duringGame_UI.SetActive(false);//ゲームのUIの非表示
        _playerInput.SwitchCurrentActionMap("Defeat");//操作の変更
        _chargeTrickPoint.Switch = false;//チャージしないようにする
        //死亡時のカメラの移動を開始(実装予定)
        _playerDeadMotion.Trigger();//プレイヤーの死亡モーションの再生
        _timeLimit.Switch = false;//制限時間を止める
        _algorithmOfEnemy.Switch = false;//敵の行動を止める
        _ropeEffect.Switch = false;//縄を消す
        _chargeTrickEffect.Switch = false;//チャージのエフェクトは出さないようにする
    }

    void Start()
    {
        _judgeGameSet.DeadAction += Trigger;
    }
    void Update()
    {
        UpdateChangeScene();
    }

    void UpdateChangeScene()//シーン移行の処理
    {
        if (!_startEffect) return;
        _currentChangeSceneTime += Time.deltaTime;

        if (_currentChangeSceneTime >= _changeSceneTime)
        {
            _controller.GameOverScene();//クリアシーンに移行する
        }
    }
}
