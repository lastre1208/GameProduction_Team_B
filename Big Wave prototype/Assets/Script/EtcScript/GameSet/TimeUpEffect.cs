using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

//作成者:杉山
//タイムアップ時の演出(シーン遷移も含めて)
public class TimeUpEffect : MonoBehaviour
{
    [Header("トリックのチャージ")]
    [SerializeField] ChargeTrickPoint _chargeTrickPoint;
    [Header("プレイヤーのHP")]
    [SerializeField] HP _player_HP;
    [Header("操作変更")]
    [SerializeField] PlayerInput _playerInput;
    [Header("制限時間")]
    [SerializeField] TimeLimit _timeLimit;
    [Header("敵の行動")]
    [SerializeField] AlgorithmOfEnemy _algorithmOfEnemy;
    [Header("ゲーム中のUI")]
    [SerializeField] GameObject _duringGame_UI;
    [Header("シーン移行コンポーネント")]
    [SerializeField] SceneController _controller;
    [Header("タイムアップしてから何秒後にシーン遷移するか")]
    [SerializeField] float _changeSceneTime;//何秒後にシーン遷移するか
    float _currentChangeSceneTime = 0;
    bool _startEffect = false;//演出の開始状況

    public void Trigger()//演出開始
    {
        _startEffect = true;
        _player_HP.Fix = true;//プレイヤーのHPを固定
        _duringGame_UI.SetActive(false);//ゲームのUIの非表示
        _chargeTrickPoint.Switch = false;//チャージしないようにする
        _playerInput.SwitchCurrentActionMap("Defeat");//操作の変更
        _timeLimit.Switch = false;//制限時間を止める
        _algorithmOfEnemy.Switch = false;//敵の行動を止める
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
