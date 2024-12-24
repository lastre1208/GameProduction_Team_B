using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//作成者:杉山
//形態変化
public class EnemyActionTypeMetamorphosis : EnemyActionTypeBase
{
    [Header("オブジェクトの表示状態を切り替える設定")]
    [Header("オーラの表示切替に使ってください")]
    [SerializeField] ChangeActiveOfObject _changeActive;
    [Header("アニメーションの設定")]
    [SerializeField] DelayAnimationTypeTrigger _animTrigger;
    [Header("行動時のエフェクト")]
    [SerializeField] GenerateEffect_Action _generateEffect;
    [Header("行動時の効果音")]
    [SerializeField] PlayAudio_Action _playAudio;

    public override void OnEnter(EnemyActionTypeBase[] beforeActionType)
    {
        _changeActive.Init();//オブジェクトの表示状態を切り替える初期化処理
        if (_generateEffect != null) _generateEffect.OnEnter();//エフェクトの初期化処理
        if (_playAudio != null) _playAudio.OnEnter();//効果音の初期化処理
        _animTrigger.Start();//モーションの再生処理の初期化
    }

    public override void OnUpdate()
    {
        _changeActive.UpdateActive();//オブジェクトの表示状態を切り替える更新処理
        if (_generateEffect != null) _generateEffect.OnUpdate();//エフェクトの更新処理
        if (_playAudio != null) _playAudio.OnUpdate();//効果音の更新処理
        _animTrigger.Update();//モーションの再生処理の更新
    }

    public override void OnExit(EnemyActionTypeBase[] nextActionType)
    {

    }
}
