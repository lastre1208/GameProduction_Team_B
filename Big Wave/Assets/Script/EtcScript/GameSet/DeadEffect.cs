using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using UnityEngine.Events;
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
    [SerializeField] ChargeTrickEffect_WhileCharge _chargeTrickEffect;
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
    [Header("表示状態を切り替えるオブジェクト")]
    [SerializeField] ChangeActiveOfObject _changeObjects;
    [Header("鳴らす効果音")]
    [SerializeField]AudioClip _audioClip;
    [Header("オーディオソース")]
    [SerializeField] AudioSource _source;
    [Header("死んでから何秒後にシーン遷移するか")]
    [SerializeField] float _changeSceneTime;//何秒後にシーン遷移するか
    [SerializeField] JudgeGameSet _judgeGameSet;
    float _currentChangeSceneTime = 0;
    bool _startEffect = false;//演出の開始状況
    const string _actionMapName = "Defeat";//プレイヤー死亡時にこのアクションマップに変更する

    public void Trigger()//演出開始
    {
        _startEffect = true;
        _player_HP.Fix = true;//プレイヤーのHPを固定
        _duringGame_UI.SetActive(false);//ゲームのUIの非表示
        _playerInput.SwitchCurrentActionMap(_actionMapName);//操作の変更
        _chargeTrickPoint.Switch = false;//チャージしないようにする
        //死亡時のカメラの移動を開始(実装予定)
        _playerDeadMotion.Trigger();//プレイヤーの死亡モーションの再生
        _timeLimit.enabled = false;//制限時間を止める
        _algorithmOfEnemy.enabled = false;//敵の行動を止める
        _ropeEffect.enabled = false;//縄を消す
        _chargeTrickEffect.Switch = false;//チャージのエフェクトは出さないようにする
        _source.PlayOneShot(_audioClip);
    }

    void Start()
    {
        _judgeGameSet.DeadAction += Trigger;
    }
    void Update()
    {
        UpdateChangeScene();
        UpdateChangeActive();
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

    void UpdateChangeActive()//オブジェクトのアクティブ状態を変更する時間の更新
    {
        if (!_startEffect) return;

        _changeObjects.UpdateActive();
    }
}
